using System;
using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The success or error information and the date the App Store server records when it attempts to send a server notification to your server.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/sendattemptitem"/>
public sealed class SendAttemptItem
{
    /// <summary>
    /// The date the App Store server attempts to send a notification.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/attemptdate"/>
    [JsonPropertyName("attemptDate")]
    public long? AttemptDate { get; set; }

    /// <summary>
    /// The UTC date and time when the App Store server attempts to send a notification,
    /// derived from <see cref="AttemptDate"/>.
    /// </summary>
    [JsonIgnore]
    public DateTime? AttemptDateUtc => AttemptDate.HasValue
        ? DateTimeOffset.FromUnixTimeMilliseconds(AttemptDate.Value).UtcDateTime
        : null;

    /// <summary>
    /// The success or error information the App Store server records when it attempts to send an App Store server notification to your server.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/sendattemptresult"/>
    [JsonPropertyName("sendAttemptResult")]
    public SendAttemptResult? SendAttemptResult { get; set; }
}
