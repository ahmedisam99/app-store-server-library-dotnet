using System.Collections.Generic;

namespace Enjna.AppStoreServerLibrary;

/// <summary>
/// A creator for introductory offer eligibility JWS signatures.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/storekit/generating-jws-to-sign-app-store-requests"/>
public class IntroductoryOfferEligibilitySignatureCreator : JWSSignatureCreator
{
    /// <summary>
    /// Creates a new <see cref="IntroductoryOfferEligibilitySignatureCreator"/> instance.
    /// </summary>
    /// <param name="signingKey">Your private key downloaded from App Store Connect, in PEM format.</param>
    /// <param name="keyId">Your private key ID from App Store Connect.</param>
    /// <param name="issuerId">Your issuer ID from the Keys page in App Store Connect.</param>
    /// <param name="bundleId">Your app's bundle ID.</param>
    public IntroductoryOfferEligibilitySignatureCreator(string signingKey, string keyId, string issuerId, string bundleId)
        : base("introductory-offer-eligibility", signingKey, keyId, issuerId, bundleId)
    {
    }

    /// <summary>
    /// Creates an introductory offer eligibility signature.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="allowIntroductoryOffer">A boolean value that determines whether the customer is eligible for an introductory offer.</param>
    /// <param name="transactionId">The unique identifier of any transaction that belongs to the customer.</param>
    /// <param name="bundleId">An optional bundle ID to use instead of the one provided in the constructor.</param>
    /// <returns>The signed JWS.</returns>
    public string CreateSignature(string productId, bool allowIntroductoryOffer, string transactionId, string? bundleId = null)
    {
        var claims = new Dictionary<string, object>
        {
            ["productId"] = productId,
            ["allowIntroductoryOffer"] = allowIntroductoryOffer,
            ["transactionId"] = transactionId
        };

        return base.CreateSignature(claims, bundleId);
    }
}
