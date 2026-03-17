using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Enjna.AppStoreServerLibrary.Models;
using Enjna.AppStoreServerLibrary.Models.Enums;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Environment = Enjna.AppStoreServerLibrary.Models.Enums.Environment;

namespace Enjna.AppStoreServerLibrary;

/// <summary>
/// A class providing utility methods for verifying and decoding App Store signed data.
/// </summary>
public class SignedDataVerifier
{
    private const long MaxSkewMilliseconds = 60_000;
    private const int MaximumCacheSize = 32;
    private const long CacheTimeLimitMilliseconds = 15 * 60 * 1_000;

    private static readonly string LeafOid = "1.2.840.113635.100.6.11.1";
    private static readonly string IntermediateOid = "1.2.840.113635.100.6.2.1";
    private static readonly JsonSerializerOptions JsonOptions = new();

    private readonly X509Certificate2[] _rootCertificates;
    private readonly bool _enableOnlineChecks;
    private readonly Environment _environment;
    private readonly string _bundleId;
    private readonly long? _appAppleId;

    internal readonly object CacheLock = new();
    internal readonly Dictionary<string, CacheEntry> Cache = new();

    internal X509Certificate2[] RootCertificates => _rootCertificates;

    /// <summary>
    /// Creates a new <see cref="SignedDataVerifier"/> instance.
    /// </summary>
    /// <param name="appleRootCertificates">A list of DER-encoded Apple root certificates.</param>
    /// <param name="enableOnlineChecks">Whether to enable revocation checking and check expiration using the current date.</param>
    /// <param name="environment">The App Store environment to target for checks.</param>
    /// <param name="bundleId">The app's bundle identifier.</param>
    /// <param name="appAppleId">The app's identifier. When provided in Production, it will be validated against the payload.</param>
    public SignedDataVerifier(
        byte[][] appleRootCertificates,
        bool enableOnlineChecks,
        Environment environment,
        string bundleId,
        long? appAppleId = null)
    {
        _rootCertificates = appleRootCertificates.Select(cert => new X509Certificate2(cert)).ToArray();
        _enableOnlineChecks = enableOnlineChecks;
        _environment = environment;
        _bundleId = bundleId;
        _appAppleId = appAppleId;
    }

    /// <summary>
    /// Verifies and decodes a signedTransaction obtained from the App Store Server API, an App Store Server Notification, or from a device.
    /// </summary>
    /// <param name="signedTransaction">The signedTransaction field.</param>
    /// <returns>The decoded transaction info after verification.</returns>
    /// <exception cref="VerificationException">Thrown if the data could not be verified.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwstransaction"/>
    public async Task<JWSTransactionDecodedPayload> VerifyAndDecodeTransactionAsync(string signedTransaction)
    {
        var decoded = await VerifyJwtAsync<JWSTransactionDecodedPayload>(signedTransaction, ExtractSignedDate).ConfigureAwait(false);

        if (decoded.BundleId != _bundleId)
        {
            throw new VerificationException(VerificationStatus.InvalidAppIdentifier);
        }

        if (decoded.Environment != _environment)
        {
            throw new VerificationException(VerificationStatus.InvalidEnvironment);
        }

        return decoded;
    }

    /// <summary>
    /// Verifies and decodes a signedRenewalInfo obtained from the App Store Server API, an App Store Server Notification, or from a device.
    /// </summary>
    /// <param name="signedRenewalInfo">The signedRenewalInfo field.</param>
    /// <returns>The decoded renewal info after verification.</returns>
    /// <exception cref="VerificationException">Thrown if the data could not be verified.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwsrenewalinfo"/>
    public async Task<JWSRenewalInfoDecodedPayload> VerifyAndDecodeRenewalInfoAsync(string signedRenewalInfo)
    {
        var decoded = await VerifyJwtAsync<JWSRenewalInfoDecodedPayload>(signedRenewalInfo, ExtractSignedDate).ConfigureAwait(false);

        if (decoded.Environment != _environment)
        {
            throw new VerificationException(VerificationStatus.InvalidEnvironment);
        }

        return decoded;
    }

    /// <summary>
    /// Verifies and decodes an App Store Server Notification signedPayload.
    /// </summary>
    /// <param name="signedPayload">The payload received by your server.</param>
    /// <returns>The decoded payload after verification.</returns>
    /// <exception cref="VerificationException">Thrown if the data could not be verified.</exception>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/signedpayload"/>
    public async Task<ResponseBodyV2DecodedPayload> VerifyAndDecodeNotificationAsync(string signedPayload)
    {
        var decoded = await VerifyJwtAsync<ResponseBodyV2DecodedPayload>(signedPayload, ExtractSignedDate).ConfigureAwait(false);

        long? appAppleId = null;
        string? bundleId = null;
        Environment? environment = null;

        if (decoded.Data is not null)
        {
            appAppleId = decoded.Data.AppAppleId;
            bundleId = decoded.Data.BundleId;
            environment = decoded.Data.Environment;
        }
        else if (decoded.Summary is not null)
        {
            appAppleId = decoded.Summary.AppAppleId;
            bundleId = decoded.Summary.BundleId;
            environment = decoded.Summary.Environment;
        }
        else if (decoded.ExternalPurchaseToken is not null)
        {
            appAppleId = decoded.ExternalPurchaseToken.AppAppleId;
            bundleId = decoded.ExternalPurchaseToken.BundleId;
            environment =
                decoded.ExternalPurchaseToken.ExternalPurchaseId is not null &&
                decoded.ExternalPurchaseToken.ExternalPurchaseId.StartsWith("SANDBOX")
                    ? Environment.Sandbox
                    : Environment.Production;
        }
        else if (decoded.AppData is not null)
        {
            appAppleId = decoded.AppData.AppAppleId;
            bundleId = decoded.AppData.BundleId;
            environment = decoded.AppData.Environment;
        }

        if (_bundleId != bundleId ||
            (_environment == Environment.Production && _appAppleId is not null && _appAppleId != appAppleId))
        {
            throw new VerificationException(VerificationStatus.InvalidAppIdentifier);
        }

        if (_environment != environment)
        {
            throw new VerificationException(VerificationStatus.InvalidEnvironment);
        }

        return decoded;
    }

    /// <summary>
    /// Verifies and decodes a signed AppTransaction.
    /// </summary>
    /// <param name="signedAppTransaction">The signed AppTransaction.</param>
    /// <returns>The decoded AppTransaction after validation.</returns>
    /// <exception cref="VerificationException">Thrown if the data could not be verified.</exception>
    /// <seealso href="https://developer.apple.com/documentation/storekit/apptransaction"/>
    public async Task<AppTransaction> VerifyAndDecodeAppTransactionAsync(string signedAppTransaction)
    {
        var decoded = await VerifyJwtAsync<AppTransaction>(signedAppTransaction, ExtractReceiptCreationDate).ConfigureAwait(false);

        if (decoded.BundleId != _bundleId ||
            (_environment == Environment.Production && _appAppleId is not null && decoded.AppAppleId != _appAppleId))
        {
            throw new VerificationException(VerificationStatus.InvalidAppIdentifier);
        }

        if (decoded.ReceiptType != _environment)
        {
            throw new VerificationException(VerificationStatus.InvalidEnvironment);
        }

        return decoded;
    }

    /// <summary>
    /// Verifies and decodes a Retention Messaging API signedPayload.
    /// </summary>
    /// <param name="signedPayload">The payload received by your server.</param>
    /// <returns>The decoded payload after verification.</returns>
    /// <exception cref="VerificationException">Thrown if the data could not be verified.</exception>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/signedpayload"/>
    public async Task<DecodedRealtimeRequestBody> VerifyAndDecodeRealtimeRequestAsync(string signedPayload)
    {
        var decoded = await VerifyJwtAsync<DecodedRealtimeRequestBody>(signedPayload, ExtractSignedDate).ConfigureAwait(false);

        if (_environment == Environment.Production && _appAppleId is not null && decoded.AppAppleId != _appAppleId)
        {
            throw new VerificationException(VerificationStatus.InvalidAppIdentifier);
        }

        if (decoded.Environment != _environment)
        {
            throw new VerificationException(VerificationStatus.InvalidEnvironment);
        }

        return decoded;
    }

    private async Task<T> VerifyJwtAsync<T>(string jwt, Func<T, DateTimeOffset> signedDateExtractor) where T : class
    {
        try
        {
            var handler = new JsonWebTokenHandler();
            var token = handler.ReadJsonWebToken(jwt);

            var payload =
                JsonSerializer.Deserialize<T>(Base64UrlEncoder.DecodeBytes(token.EncodedPayload), JsonOptions);

            if (payload is null)
            {
                throw new VerificationException(VerificationStatus.Failure);
            }

            if (_environment == Environment.Xcode || _environment == Environment.LocalTesting)
            {
                return payload;
            }

            var header =
                JsonSerializer.Deserialize<JWSDecodedHeader>(Base64UrlEncoder.Decode(token.EncodedHeader), JsonOptions);
            var certChain = header?.X5C;

            if (certChain is not { Length: 3 })
            {
                throw new VerificationException(VerificationStatus.InvalidChainLength);
            }

            X509Certificate2 leafCert;
            X509Certificate2 intermediateCert;
            try
            {
                leafCert = new X509Certificate2(Convert.FromBase64String(certChain[0]));
                intermediateCert = new X509Certificate2(Convert.FromBase64String(certChain[1]));
            }
            catch (Exception e)
            {
                throw new VerificationException(VerificationStatus.InvalidCertificate, e);
            }

            var effectiveDate = _enableOnlineChecks
                ? DateTimeOffset.UtcNow
                : signedDateExtractor(payload);

            var publicKey = await VerifyCertificateChainAsync(leafCert, intermediateCert, effectiveDate).ConfigureAwait(false);

            var validationParams = new TokenValidationParameters
            {
                IssuerSigningKey = publicKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                RequireExpirationTime = false,
                RequireSignedTokens = true
            };

            var result = await handler.ValidateTokenAsync(jwt, validationParams).ConfigureAwait(false);
            if (!result.IsValid)
            {
                throw new VerificationException(VerificationStatus.VerificationFailure, result.Exception);
            }

            return payload;
        }
        catch (VerificationException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new VerificationException(VerificationStatus.VerificationFailure, e);
        }
    }

    internal async Task<SecurityKey> VerifyCertificateChainAsync(
        X509Certificate2 leaf,
        X509Certificate2 intermediate,
        DateTimeOffset effectiveDate)
    {
        var cacheKey = leaf.Thumbprint + ":" + intermediate.Thumbprint;

        if (_enableOnlineChecks)
        {
            lock (CacheLock)
            {
                if (Cache.TryGetValue(cacheKey, out var entry) &&
                    entry.ExpiryTimestamp > DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
                {
                    return entry.PublicKey;
                }
            }
        }

        var publicKey = await VerifyCertificateChainCore(leaf, intermediate, effectiveDate).ConfigureAwait(false);

        if (_enableOnlineChecks)
        {
            lock (CacheLock)
            {
                Cache[cacheKey] = new CacheEntry(
                    publicKey,
                    DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + CacheTimeLimitMilliseconds);

                if (Cache.Count > MaximumCacheSize)
                {
                    var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    var expiredKeys = Cache
                        .Where(kvp => kvp.Value.ExpiryTimestamp < now)
                        .Select(kvp => kvp.Key)
                        .ToList();

                    foreach (var key in expiredKeys)
                    {
                        Cache.Remove(key);
                    }
                }
            }
        }

        return publicKey;
    }

    internal Task<SecurityKey> VerifyCertificateChainCore(
        X509Certificate2 leaf,
        X509Certificate2 intermediate,
        DateTimeOffset effectiveDate)
    {
        using var chain = new X509Chain();
        chain.ChainPolicy.RevocationMode = _enableOnlineChecks
            ? X509RevocationMode.Online
            : X509RevocationMode.NoCheck;

        chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
        chain.ChainPolicy.TrustMode = X509ChainTrustMode.CustomRootTrust;
        chain.ChainPolicy.VerificationTime = effectiveDate.UtcDateTime;

        foreach (var root in _rootCertificates)
        {
            chain.ChainPolicy.CustomTrustStore.Add(root);
        }

        chain.ChainPolicy.ExtraStore.Add(intermediate);

        if (!chain.Build(leaf))
        {
            foreach (var status in chain.ChainStatus)
            {
                if (status.Status.HasFlag(X509ChainStatusFlags.Revoked))
                {
                    throw new VerificationException(VerificationStatus.VerificationFailure);
                }

                if (status.Status.HasFlag(X509ChainStatusFlags.RevocationStatusUnknown)
                    || status.Status.HasFlag(X509ChainStatusFlags.OfflineRevocation))
                {
                    throw new VerificationException(VerificationStatus.RetryableVerificationFailure);
                }
            }

            throw new VerificationException(VerificationStatus.VerificationFailure);
        }

        // Verify Apple OID extensions
        if (!HasExtension(leaf, LeafOid))
        {
            throw new VerificationException(VerificationStatus.VerificationFailure);
        }

        if (!HasExtension(intermediate, IntermediateOid))
        {
            throw new VerificationException(VerificationStatus.VerificationFailure);
        }

        // Verify certificate dates with skew
        CheckDates(leaf, effectiveDate);
        CheckDates(intermediate, effectiveDate);
        CheckDates(chain.ChainElements[^1].Certificate, effectiveDate);

        var ecdsaKey = leaf.GetECDsaPublicKey();

        if (ecdsaKey is null)
        {
            throw new VerificationException(VerificationStatus.InvalidCertificate);
        }

        return Task.FromResult<SecurityKey>(new ECDsaSecurityKey(ecdsaKey));
    }

    private static void CheckDates(X509Certificate2 cert, DateTimeOffset effectiveDate)
    {
        var notBefore = new DateTimeOffset(cert.NotBefore.ToUniversalTime(), TimeSpan.Zero);
        var notAfter = new DateTimeOffset(cert.NotAfter.ToUniversalTime(), TimeSpan.Zero);
        var skew = TimeSpan.FromMilliseconds(MaxSkewMilliseconds);

        if (notBefore > effectiveDate + skew || notAfter < effectiveDate - skew)
        {
            throw new VerificationException(VerificationStatus.InvalidCertificate);
        }
    }

    private static bool HasExtension(X509Certificate2 cert, string oid)
    {
        return cert.Extensions.Any(ext => ext.Oid?.Value == oid);
    }

    private static DateTimeOffset ExtractSignedDate(DecodedSignedData data)
    {
        return data.SignedDate.HasValue
            ? DateTimeOffset.FromUnixTimeMilliseconds(data.SignedDate.Value)
            : DateTimeOffset.UtcNow;
    }

    private static DateTimeOffset ExtractReceiptCreationDate(AppTransaction data)
    {
        return data.ReceiptCreationDate.HasValue
            ? DateTimeOffset.FromUnixTimeMilliseconds(data.ReceiptCreationDate.Value)
            : DateTimeOffset.UtcNow;
    }

    internal sealed class CacheEntry
    {
        public SecurityKey PublicKey { get; }
        public long ExpiryTimestamp { get; }

        public CacheEntry(SecurityKey publicKey, long expiryTimestamp)
        {
            PublicKey = publicKey;
            ExpiryTimestamp = expiryTimestamp;
        }
    }
}
