using System.Collections.Generic;

namespace Enjna.AppStoreServerLibrary;

/// <summary>
/// A creator for promotional offer V2 JWS signatures.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/storekit/generating-jws-to-sign-app-store-requests"/>
public class PromotionalOfferV2SignatureCreator : JWSSignatureCreator
{
    /// <summary>
    /// Creates a new <see cref="PromotionalOfferV2SignatureCreator"/> instance.
    /// </summary>
    /// <param name="signingKey">Your private key downloaded from App Store Connect, in PEM format.</param>
    /// <param name="keyId">Your private key ID from App Store Connect.</param>
    /// <param name="issuerId">Your issuer ID from the Keys page in App Store Connect.</param>
    /// <param name="bundleId">Your app's bundle ID.</param>
    public PromotionalOfferV2SignatureCreator(string signingKey, string keyId, string issuerId, string bundleId)
        : base("promotional-offer", signingKey, keyId, issuerId, bundleId)
    {
    }

    /// <summary>
    /// Creates a promotional offer V2 signature.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="offerIdentifier">The promotional offer identifier that you set up in App Store Connect.</param>
    /// <param name="transactionId">The unique identifier of any transaction that belongs to the customer. Optional, but recommended.</param>
    /// <returns>The signed JWS.</returns>
    public string CreateSignature(string productId, string offerIdentifier, string? transactionId = null)
    {
        var claims = new Dictionary<string, object>
        {
            ["productId"] = productId,
            ["offerIdentifier"] = offerIdentifier
        };

        if (transactionId is not null)
        {
            claims["transactionId"] = transactionId;
        }

        return base.CreateSignature(claims);
    }
}
