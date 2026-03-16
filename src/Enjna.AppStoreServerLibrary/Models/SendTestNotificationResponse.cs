using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that contains the test notification token.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/sendtestnotificationresponse"/>
public sealed class SendTestNotificationResponse
{
    /// <summary>
    /// A unique identifier for a notification test that the App Store server sends to your server.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/testnotificationtoken"/>
    [JsonPropertyName("testNotificationToken")]
    public string? TestNotificationToken { get; set; }
}
