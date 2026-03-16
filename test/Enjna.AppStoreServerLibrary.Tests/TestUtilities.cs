using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Environment = Enjna.AppStoreServerLibrary.Models.Environment;

namespace Enjna.AppStoreServerLibrary.Tests;

internal static class TestUtilities
{
    private const string ResourcePrefix = "Enjna.AppStoreServerLibrary.Tests.Resources.";

    public static string ReadResourceAsString(string path)
    {
        var resourceName = ResourcePrefix + path;
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        if (stream is null)
        {
            throw new FileNotFoundException($"Embedded resource not found: {resourceName}");
        }

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    public static byte[] ReadResourceAsBytes(string path)
    {
        var resourceName = ResourcePrefix + path;
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        if (stream is null)
        {
            throw new FileNotFoundException($"Embedded resource not found: {resourceName}");
        }

        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        return ms.ToArray();
    }

    public static string GetSigningKey()
    {
        return ReadResourceAsString("certs.testSigningKey.p8");
    }

    public static SignedDataVerifier GetSignedPayloadVerifier(Environment environment, string bundleId, long appAppleId)
    {
        var rootCertBytes = ReadResourceAsBytes("certs.testCA.der");
        return new SignedDataVerifier(
            [rootCertBytes],
            enableOnlineChecks: false,
            environment: environment,
            bundleId: bundleId,
            appAppleId: appAppleId);
    }

    public static SignedDataVerifier GetDefaultSignedPayloadVerifier()
    {
        return GetSignedPayloadVerifier(Environment.LocalTesting, "com.example", 1234);
    }

    public static string CreateSignedDataFromJson(string resourcePath)
    {
        var json = ReadResourceAsString(resourcePath);

        using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);

        var headerJson = JsonSerializer.Serialize(new { alg = "ES256", typ = "JWT" });
        var headerBase64 = Base64UrlEncode(Encoding.UTF8.GetBytes(headerJson));
        var payloadBase64 = Base64UrlEncode(Encoding.UTF8.GetBytes(json));

        var dataToSign = Encoding.UTF8.GetBytes($"{headerBase64}.{payloadBase64}");
        var signature = ecdsa.SignData(dataToSign, HashAlgorithmName.SHA256);
        var signatureBase64 = Base64UrlEncode(signature);

        return $"{headerBase64}.{payloadBase64}.{signatureBase64}";
    }

    private static string Base64UrlEncode(byte[] data)
    {
        return Convert.ToBase64String(data)
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');
    }
}
