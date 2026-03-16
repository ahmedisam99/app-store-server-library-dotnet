using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body that contains the default configuration information.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/defaultconfigurationrequest"/>
public sealed class DefaultConfigurationRequest
{
    /// <summary>
    /// The message identifier of the message to configure as a default message.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messageidentifier"/>
    [JsonPropertyName("messageIdentifier")]
    public string? MessageIdentifier { get; set; }
}
