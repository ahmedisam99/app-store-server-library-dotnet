using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body the App Store server sends to your Get Retention Message endpoint.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/realtimerequestbody"/>
public sealed class RealtimeRequestBody
{
    /// <summary>
    /// The payload in JSON Web Signature (JWS) format, signed by the App Store.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/signedpayload"/>
    [JsonPropertyName("signedPayload")]
    public string? SignedPayload { get; set; }
}
