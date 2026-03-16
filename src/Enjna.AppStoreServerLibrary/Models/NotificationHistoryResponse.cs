using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that contains the App Store Server Notifications history for your app.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/notificationhistoryresponse"/>
public sealed class NotificationHistoryResponse
{
    /// <summary>
    /// A pagination token that you return to the endpoint on a subsequent call to receive the next set of results.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/paginationtoken"/>
    [JsonPropertyName("paginationToken")]
    public string? PaginationToken { get; set; }

    /// <summary>
    /// A Boolean value indicating whether the App Store has more transaction data.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/hasmore"/>
    [JsonPropertyName("hasMore")]
    public bool? HasMore { get; set; }

    /// <summary>
    /// An array of App Store server notification history records.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/notificationhistoryresponseitem"/>
    [JsonPropertyName("notificationHistory")]
    public NotificationHistoryResponseItem[]? NotificationHistory { get; set; }
}
