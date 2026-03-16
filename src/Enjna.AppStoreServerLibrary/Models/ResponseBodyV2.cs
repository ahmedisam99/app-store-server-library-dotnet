using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The response body the App Store sends in a version 2 server notification.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/responsebodyv2"/>
public sealed class ResponseBodyV2
{
    /// <summary>
    /// A cryptographically signed payload, in JSON Web Signature (JWS) format, containing the response body for a version 2 notification.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/signedpayload"/>
    [JsonPropertyName("signedPayload")]
    public string? SignedPayload { get; set; }
}
