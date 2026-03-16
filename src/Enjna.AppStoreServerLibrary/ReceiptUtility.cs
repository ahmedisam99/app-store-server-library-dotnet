using System;
using System.Formats.Asn1;
using System.Text;
using System.Text.RegularExpressions;

namespace Enjna.AppStoreServerLibrary;

/// <summary>
/// A utility class for extracting transaction identifiers from App Store receipts.
/// </summary>
public class ReceiptUtility
{
    private const int InAppTypeId = 17;
    private const int TransactionIdentifierTypeId = 1703;
    private const int OriginalTransactionIdentifierTypeId = 1705;

    /// <summary>
    /// Extracts a transaction identifier from an encoded App Receipt.
    /// <b>No validation</b> is performed on the receipt, and any data returned should only be used to call the App Store Server API.
    /// </summary>
    /// <param name="appReceipt">The unmodified app receipt, base64 encoded.</param>
    /// <returns>A transaction identifier from the array of in-app purchases, or <c>null</c> if the receipt contains no in-app purchases.</returns>
    public string? ExtractTransactionIdFromAppReceipt(string appReceipt)
    {
        var receiptBytes = Convert.FromBase64String(appReceipt);
        // Navigate PKCS#7 structure: ContentInfo -> [1] content -> SignedData -> encapContentInfo -> [0] content
        var reader = new AsnReader(receiptBytes, AsnEncodingRules.BER);
        var contentInfo = reader.ReadSequence();
        contentInfo.ReadObjectIdentifier(); // contentType
        var content = contentInfo.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        var signedData = content.ReadSequence();
        signedData.ReadInteger(); // version
        signedData.ReadSetOf(); // digestAlgorithms
        var encapContentInfo = signedData.ReadSequence();
        encapContentInfo.ReadObjectIdentifier(); // eContentType
        var eContent = encapContentInfo.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        var receiptOctetString = eContent.ReadOctetString();

        // Handle Xcode's extra wrapping: if the octet string starts with another octet string tag (0x04),
        // unwrap it
        if (receiptOctetString.Length > 2 && receiptOctetString[0] == 0x04)
        {
            var innerReader = new AsnReader(receiptOctetString, AsnEncodingRules.BER);
            receiptOctetString = innerReader.ReadOctetString();
        }

        return ExtractTransactionIdFromReceiptPayload(receiptOctetString);
    }

    /// <summary>
    /// Extracts a transaction identifier from an encoded transactional receipt.
    /// <b>No validation</b> is performed on the receipt, and any data returned should only be used to call the App Store Server API.
    /// </summary>
    /// <param name="transactionReceipt">The unmodified transactional receipt, base64 encoded.</param>
    /// <returns>A transaction identifier, or <c>null</c> if no transaction identifier is found in the receipt.</returns>
    public string? ExtractTransactionIdFromTransactionReceipt(string transactionReceipt)
    {
        var topLevel = Encoding.UTF8.GetString(Convert.FromBase64String(transactionReceipt));

        var purchaseInfoMatch = Regex.Match(topLevel, @"""purchase-info""\s+=\s+""([a-zA-Z0-9+/=]+)"";");
        if (!purchaseInfoMatch.Success)
        {
            return null;
        }

        var purchaseInfo = Encoding.UTF8.GetString(Convert.FromBase64String(purchaseInfoMatch.Groups[1].Value));

        var transactionIdMatch = Regex.Match(purchaseInfo, @"""transaction-id""\s+=\s+""([a-zA-Z0-9+/=]+)"";");
        if (!transactionIdMatch.Success)
        {
            return null;
        }

        return transactionIdMatch.Groups[1].Value;
    }

    private static string? ExtractTransactionIdFromReceiptPayload(byte[] payload)
    {
        var setReader = new AsnReader(payload, AsnEncodingRules.BER);
        var receiptAttributes = setReader.ReadSetOf();

        while (receiptAttributes.HasData)
        {
            var attribute = receiptAttributes.ReadSequence();
            var typeId = (int)attribute.ReadInteger();

            if (typeId == InAppTypeId)
            {
                attribute.ReadInteger(); // version
                var inAppOctetString = attribute.ReadOctetString();
                var transactionId = ExtractTransactionIdFromInApp(inAppOctetString);

                if (transactionId is not null)
                {
                    return transactionId;
                }
            }
        }

        return null;
    }

    private static string? ExtractTransactionIdFromInApp(byte[] inAppBytes)
    {
        var setReader = new AsnReader(inAppBytes, AsnEncodingRules.BER);
        var inAppAttributes = setReader.ReadSetOf();

        while (inAppAttributes.HasData)
        {
            var attribute = inAppAttributes.ReadSequence();
            var typeId = (int)attribute.ReadInteger();

            if (typeId == TransactionIdentifierTypeId || typeId == OriginalTransactionIdentifierTypeId)
            {
                attribute.ReadInteger(); // version
                var valueOctetString = attribute.ReadOctetString();

                // The value is a UTF8String wrapped in an OCTET STRING
                var valueReader = new AsnReader(valueOctetString, AsnEncodingRules.BER);
                return valueReader.ReadCharacterString(UniversalTagNumber.UTF8String);
            }
        }

        return null;
    }
}
