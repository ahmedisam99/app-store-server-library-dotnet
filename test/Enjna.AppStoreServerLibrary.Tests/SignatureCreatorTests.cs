using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Enjna.AppStoreServerLibrary.Tests;

public class SignatureCreatorTests
{
    private const string KeyId = "testKeyId";
    private const string IssuerId = "testIssuerId";
    private const string BundleId = "com.example";

    private readonly string _signingKey = TestUtilities.GetSigningKey();

    private static (JsonDocument Header, JsonDocument Payload) DecodeJwtParts(string jwt)
    {
        var parts = jwt.Split('.');
        var header = JsonDocument.Parse(Base64UrlDecode(parts[0]));
        var payload = JsonDocument.Parse(Base64UrlDecode(parts[1]));
        return (header, payload);
    }

    private static byte[] Base64UrlDecode(string input)
    {
        var base64 = input.Replace('-', '+').Replace('_', '/');
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        return Convert.FromBase64String(base64);
    }

    [Fact]
    public void PromotionalOfferV2_WithTransactionId_CreatesValidSignature()
    {
        var creator = new PromotionalOfferV2SignatureCreator(_signingKey, KeyId, IssuerId, BundleId);
        var signature = creator.CreateSignature("productId", "offerIdentifier", "transactionId");

        var (header, payload) = DecodeJwtParts(signature);

        Assert.Equal("JWT", header.RootElement.GetProperty("typ").GetString());
        Assert.Equal("ES256", header.RootElement.GetProperty("alg").GetString());
        Assert.Equal(KeyId, header.RootElement.GetProperty("kid").GetString());

        Assert.Equal(IssuerId, payload.RootElement.GetProperty("iss").GetString());
        Assert.True(payload.RootElement.TryGetProperty("iat", out _));
        Assert.False(payload.RootElement.TryGetProperty("exp", out _));
        Assert.Equal("promotional-offer", payload.RootElement.GetProperty("aud").GetString());
        Assert.Equal(BundleId, payload.RootElement.GetProperty("bid").GetString());
        Assert.True(payload.RootElement.TryGetProperty("nonce", out _));
        Assert.Equal("productId", payload.RootElement.GetProperty("productId").GetString());
        Assert.Equal("offerIdentifier", payload.RootElement.GetProperty("offerIdentifier").GetString());
        Assert.Equal("transactionId", payload.RootElement.GetProperty("transactionId").GetString());

        header.Dispose();
        payload.Dispose();
    }

    [Fact]
    public void PromotionalOfferV2_WithoutTransactionId_OmitsTransactionId()
    {
        var creator = new PromotionalOfferV2SignatureCreator(_signingKey, KeyId, IssuerId, BundleId);
        var signature = creator.CreateSignature("productId", "offerIdentifier");

        var (header, payload) = DecodeJwtParts(signature);

        Assert.Equal("promotional-offer", payload.RootElement.GetProperty("aud").GetString());
        Assert.Equal("productId", payload.RootElement.GetProperty("productId").GetString());
        Assert.Equal("offerIdentifier", payload.RootElement.GetProperty("offerIdentifier").GetString());
        Assert.False(payload.RootElement.TryGetProperty("transactionId", out _));

        header.Dispose();
        payload.Dispose();
    }

    [Fact]
    public void IntroductoryOfferEligibility_CreatesValidSignature()
    {
        var creator = new IntroductoryOfferEligibilitySignatureCreator(_signingKey, KeyId, IssuerId, BundleId);
        var signature = creator.CreateSignature("productId", true, "transactionId");

        var (header, payload) = DecodeJwtParts(signature);

        Assert.Equal("JWT", header.RootElement.GetProperty("typ").GetString());
        Assert.Equal("ES256", header.RootElement.GetProperty("alg").GetString());
        Assert.Equal(KeyId, header.RootElement.GetProperty("kid").GetString());

        Assert.Equal(IssuerId, payload.RootElement.GetProperty("iss").GetString());
        Assert.True(payload.RootElement.TryGetProperty("iat", out _));
        Assert.False(payload.RootElement.TryGetProperty("exp", out _));
        Assert.Equal("introductory-offer-eligibility", payload.RootElement.GetProperty("aud").GetString());
        Assert.Equal(BundleId, payload.RootElement.GetProperty("bid").GetString());
        Assert.True(payload.RootElement.TryGetProperty("nonce", out _));
        Assert.Equal("productId", payload.RootElement.GetProperty("productId").GetString());
        Assert.True(payload.RootElement.GetProperty("allowIntroductoryOffer").GetBoolean());
        Assert.Equal("transactionId", payload.RootElement.GetProperty("transactionId").GetString());

        header.Dispose();
        payload.Dispose();
    }

    [Fact]
    public void AdvancedCommerceInApp_CreatesValidSignature()
    {
        var creator = new AdvancedCommerceInAppSignatureCreator(_signingKey, KeyId, IssuerId, BundleId);
        var requestObj = new { key = "value" };
        var signature = creator.CreateSignature(requestObj);

        var (header, payload) = DecodeJwtParts(signature);

        Assert.Equal("JWT", header.RootElement.GetProperty("typ").GetString());
        Assert.Equal("ES256", header.RootElement.GetProperty("alg").GetString());
        Assert.Equal(KeyId, header.RootElement.GetProperty("kid").GetString());

        Assert.Equal(IssuerId, payload.RootElement.GetProperty("iss").GetString());
        Assert.True(payload.RootElement.TryGetProperty("iat", out _));
        Assert.False(payload.RootElement.TryGetProperty("exp", out _));
        Assert.Equal("advanced-commerce-api", payload.RootElement.GetProperty("aud").GetString());
        Assert.Equal(BundleId, payload.RootElement.GetProperty("bid").GetString());
        Assert.True(payload.RootElement.TryGetProperty("nonce", out _));
        var requestBase64 = payload.RootElement.GetProperty("request").GetString();
        Assert.NotNull(requestBase64);
        var requestJson = Encoding.UTF8.GetString(Convert.FromBase64String(requestBase64));
        var requestDoc = JsonDocument.Parse(requestJson);
        Assert.Equal("value", requestDoc.RootElement.GetProperty("key").GetString());

        header.Dispose();
        payload.Dispose();
        requestDoc.Dispose();
    }

    [Fact]
    public void LegacyPromotionalOffer_CreatesNonNullSignature()
    {
        var creator = new PromotionalOfferSignatureCreator(_signingKey, KeyId, BundleId);
        var nonce = Guid.NewGuid();
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        var signature = creator.CreateSignature("productId", "offerId", "", nonce, timestamp);

        Assert.NotNull(signature);
        Assert.NotEmpty(signature);
        // Verify it's valid base64
        var bytes = Convert.FromBase64String(signature);
        Assert.NotEmpty(bytes);
    }

    [Fact]
    public void LegacyPromotionalOffer_ProducesDerEncodedSignature()
    {
        var creator = new PromotionalOfferSignatureCreator(_signingKey, KeyId, BundleId);
        var nonce = Guid.NewGuid();
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var productId = "productId";
        var offerId = "offerId";
        var appAccountToken = "token";

        var signature = creator.CreateSignature(productId, offerId, appAccountToken, nonce, timestamp);
        var signatureBytes = Convert.FromBase64String(signature);

        // DER-encoded ECDSA signatures start with 0x30 (SEQUENCE tag)
        Assert.Equal(0x30, signatureBytes[0]);
        // DER signatures for ES256 are variable length (~70-72 bytes), never exactly 64 (which is P1363)
        Assert.NotEqual(64, signatureBytes.Length);

        // Verify the signature is valid by re-signing with DER format verification
        using var ecdsa = ECDsa.Create();
        ecdsa.ImportFromPem(_signingKey);

        var payload = string.Join('\u2063',
            BundleId,
            KeyId,
            productId,
            offerId,
            appAccountToken.ToLowerInvariant(),
            nonce.ToString().ToLowerInvariant(),
            timestamp);
        var payloadBytes = Encoding.UTF8.GetBytes(payload);

        Assert.True(ecdsa.VerifyData(payloadBytes, signatureBytes, HashAlgorithmName.SHA256, DSASignatureFormat.Rfc3279DerSequence));
    }
}
