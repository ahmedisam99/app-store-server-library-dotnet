using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The response body that contains the URL for your Get Retention Message endpoint.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/realtimeurlresponse"/>
public sealed class RealtimeUrlResponse
{
    /// <summary>
    /// A string that contains the URL you provided for your Get Retention Message endpoint.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/realtimeurl"/>
    [JsonPropertyName("realtimeURL")]
    public string? RealtimeUrl { get; set; }
}
