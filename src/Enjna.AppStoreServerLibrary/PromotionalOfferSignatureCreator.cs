using System;
using System.Security.Cryptography;
using System.Text;

namespace Enjna.AppStoreServerLibrary;

/// <summary>
/// A creator for promotional offer signatures using the original StoreKit API.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/storekit/in-app_purchase/original_api_for_in-app_purchase/subscriptions_and_offers/generating_a_signature_for_promotional_offers"/>
public class PromotionalOfferSignatureCreator
{
    private const char Separator = '\u2063';

    private readonly string _signingKey;
    private readonly string _keyId;
    private readonly string _bundleId;

    /// <summary>
    /// Creates a new <see cref="PromotionalOfferSignatureCreator"/> instance.
    /// </summary>
    /// <param name="signingKey">Your private key downloaded from App Store Connect, in PEM format.</param>
    /// <param name="keyId">Your private key ID from App Store Connect.</param>
    /// <param name="bundleId">Your app's bundle ID.</param>
    public PromotionalOfferSignatureCreator(string signingKey, string keyId, string bundleId)
    {
        _signingKey = signingKey;
        _keyId = keyId;
        _bundleId = bundleId;
    }

    /// <summary>
    /// Creates a promotional offer signature.
    /// </summary>
    /// <param name="productIdentifier">The subscription product identifier.</param>
    /// <param name="subscriptionOfferId">The subscription discount identifier.</param>
    /// <param name="appAccountToken">An optional string value that you define; may be an empty string.</param>
    /// <param name="nonce">A one-time UUID value that your server generates. Generate a new nonce for every signature.</param>
    /// <param name="timestamp">A timestamp in UNIX time format, in milliseconds. The timestamp keeps the offer active for 24 hours.</param>
    /// <param name="bundleId">An optional bundle ID to use instead of the one provided in the constructor.</param>
    /// <returns>The Base64 encoded signature.</returns>
    public string CreateSignature(
        string productIdentifier,
        string subscriptionOfferId,
        string appAccountToken,
        Guid nonce,
        long timestamp,
        string? bundleId = null)
    {
        var payload = string.Join(Separator,
            bundleId ?? _bundleId,
            _keyId,
            productIdentifier,
            subscriptionOfferId,
            appAccountToken.ToLowerInvariant(),
            nonce.ToString().ToLowerInvariant(),
            timestamp);

        var payloadBytes = Encoding.UTF8.GetBytes(payload);

        using var ecdsa = ECDsa.Create();
        ecdsa.ImportFromPem(_signingKey);
        var signature = ecdsa.SignData(payloadBytes, HashAlgorithmName.SHA256, DSASignatureFormat.Rfc3279DerSequence);

        return Convert.ToBase64String(signature);
    }

}
