using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that contains status information for all of a customer's auto-renewable subscriptions in your app.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/statusresponse"/>
public sealed class StatusResponse
{
    /// <summary>
    /// The server environment, sandbox or production, in which the App Store generated the response.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/environment"/>
    [JsonPropertyName("environment")]
    public Environment? Environment { get; set; }

    /// <summary>
    /// The bundle identifier of an app.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/bundleid"/>
    [JsonPropertyName("bundleId")]
    public string? BundleId { get; set; }

    /// <summary>
    /// The unique identifier of an app in the App Store.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/appappleid"/>
    [JsonPropertyName("appAppleId")]
    public long? AppAppleId { get; set; }

    /// <summary>
    /// An array of information for auto-renewable subscriptions, including App Store-signed transaction information and App Store-signed renewal information.
    /// </summary>
    [JsonPropertyName("data")]
    public SubscriptionGroupIdentifierItem[]? Data { get; set; }
}
