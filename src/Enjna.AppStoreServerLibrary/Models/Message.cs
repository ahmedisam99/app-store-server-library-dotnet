using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A message identifier you provide in a real-time response to your Get Retention Message endpoint.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/message"/>
public sealed class Message
{
    /// <summary>
    /// The identifier of the message to display to the customer.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messageidentifier"/>
    [JsonPropertyName("messageIdentifier")]
    public string? MessageIdentifier { get; set; }
}
