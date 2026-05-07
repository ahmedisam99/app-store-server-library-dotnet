using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The response body that contains the default configuration information.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/defaultconfigurationresponse"/>
public sealed class DefaultConfigurationResponse
{
    /// <summary>
    /// The message identifier of the retention message you configured as a default.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messageidentifier"/>
    [JsonPropertyName("messageIdentifier")]
    public string? MessageIdentifier { get; set; }
}
