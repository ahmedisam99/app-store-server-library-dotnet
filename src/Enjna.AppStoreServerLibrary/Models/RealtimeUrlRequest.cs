using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body for configuring the URL of your Get Retention Message endpoint.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/realtimeurlrequest"/>
public sealed class RealtimeUrlRequest
{
    /// <summary>
    /// A string that contains the URL of your Get Retention Message endpoint for configuration. Maximum length: 256 characters.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/realtimeurl"/>
    [JsonPropertyName("realtimeURL")]
    public required string RealtimeUrl { get; set; }
}
