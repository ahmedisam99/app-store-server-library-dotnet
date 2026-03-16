using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that contains status information for all messages.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/getmessagelistresponse"/>
public sealed class GetMessageListResponse
{
    /// <summary>
    /// An array of all message identifiers and their message state.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/getmessagelistresponseitem"/>
    [JsonPropertyName("messageIdentifiers")]
    public GetMessageListResponseItem[]? MessageIdentifiers { get; set; }
}
