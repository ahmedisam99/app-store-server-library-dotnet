using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A message identifier and status information for a message.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/getmessagelistresponseitem"/>
public sealed class GetMessageListResponseItem
{
    /// <summary>
    /// The identifier of the message.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messageidentifier"/>
    [JsonPropertyName("messageIdentifier")]
    public string? MessageIdentifier { get; set; }

    /// <summary>
    /// The current state of the message.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messagestate"/>
    [JsonPropertyName("messageState")]
    public MessageState? MessageState { get; set; }
}
