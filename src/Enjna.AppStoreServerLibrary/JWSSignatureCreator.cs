using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Enjna.AppStoreServerLibrary;

/// <summary>
/// A base class for creating JWS signatures for App Store requests.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/storekit/generating-jws-to-sign-app-store-requests"/>
public abstract class JWSSignatureCreator
{
    private readonly string _audience;
    private readonly string _signingKey;
    private readonly string _keyId;
    private readonly string _issuerId;
    private readonly string _bundleId;

    /// <summary>
    /// Creates a new <see cref="JWSSignatureCreator"/> instance.
    /// </summary>
    /// <param name="audience">The audience for the JWS.</param>
    /// <param name="signingKey">Your private key downloaded from App Store Connect, in PEM format.</param>
    /// <param name="keyId">Your private key ID from App Store Connect.</param>
    /// <param name="issuerId">Your issuer ID from the Keys page in App Store Connect.</param>
    /// <param name="bundleId">Your app's bundle ID.</param>
    protected JWSSignatureCreator(string audience, string signingKey, string keyId, string issuerId, string bundleId)
    {
        _audience = audience;
        _signingKey = signingKey;
        _keyId = keyId;
        _issuerId = issuerId;
        _bundleId = bundleId;
    }

    /// <summary>
    /// Creates a signed JWS with the given feature-specific claims.
    /// </summary>
    /// <param name="featureSpecificClaims">The claims specific to the feature being signed.</param>
    /// <param name="bundleId">An optional bundle ID to use instead of the one provided in the constructor.</param>
    /// <returns>The signed JWS.</returns>
    protected string CreateSignature(Dictionary<string, object> featureSpecificClaims, string? bundleId = null)
    {
        var ecdsa = ECDsa.Create();
        ecdsa.ImportFromPem(_signingKey);

        var securityKey = new ECDsaSecurityKey(ecdsa)
        {
            KeyId = _keyId
        };

        featureSpecificClaims["bid"] = bundleId ?? _bundleId;
        featureSpecificClaims["nonce"] = Guid.NewGuid().ToString();

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _issuerId,
            Audience = _audience,
            IssuedAt = DateTime.UtcNow,
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.EcdsaSha256),
            Claims = featureSpecificClaims
        };

        var handler = new JsonWebTokenHandler
        {
            SetDefaultTimesOnTokenCreation = false
        };

        return handler.CreateToken(descriptor);
    }

}
