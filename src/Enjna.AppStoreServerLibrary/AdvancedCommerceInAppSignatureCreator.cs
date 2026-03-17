using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Enjna.AppStoreServerLibrary;

/// <summary>
/// A creator for Advanced Commerce in-app JWS signatures.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/storekit/generating-jws-to-sign-app-store-requests"/>
public class AdvancedCommerceInAppSignatureCreator : JWSSignatureCreator
{
    private static readonly JsonSerializerOptions JsonOptions = new();

    /// <summary>
    /// Creates a new <see cref="AdvancedCommerceInAppSignatureCreator"/> instance.
    /// </summary>
    /// <param name="signingKey">Your private key downloaded from App Store Connect, in PEM format.</param>
    /// <param name="keyId">Your private key ID from App Store Connect.</param>
    /// <param name="issuerId">Your issuer ID from the Keys page in App Store Connect.</param>
    /// <param name="bundleId">Your app's bundle ID.</param>
    public AdvancedCommerceInAppSignatureCreator(string signingKey, string keyId, string issuerId, string bundleId)
        : base("advanced-commerce-api", signingKey, keyId, issuerId, bundleId)
    {
    }

    /// <summary>
    /// Creates an Advanced Commerce in-app signed request.
    /// </summary>
    /// <param name="request">The request object to be signed.</param>
    /// <param name="bundleId">An optional bundle ID to use instead of the one provided in the constructor.</param>
    /// <returns>The signed JWS.</returns>
    public string CreateSignature(object request, string? bundleId = null)
    {
        var json = JsonSerializer.Serialize(request, JsonOptions);
        var base64Request = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

        var claims = new Dictionary<string, object>
        {
            ["request"] = base64Request
        };

        return base.CreateSignature(claims, bundleId);
    }
}
