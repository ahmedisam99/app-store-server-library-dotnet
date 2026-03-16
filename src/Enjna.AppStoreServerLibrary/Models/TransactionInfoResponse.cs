using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that contains signed transaction information for a single transaction.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/transactioninforesponse"/>
public sealed class TransactionInfoResponse
{
    /// <summary>
    /// A customer's in-app purchase transaction, signed by Apple, in JSON Web Signature (JWS) format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwstransaction"/>
    [JsonPropertyName("signedTransactionInfo")]
    public string? SignedTransactionInfo { get; set; }
}
