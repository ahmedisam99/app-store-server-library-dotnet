using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The payload data for a subscription-renewal-date extension notification.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/summary"/>
public sealed class Summary
{
    /// <summary>
    /// The server environment that the notification applies to, either sandbox or production.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/environment"/>
    [JsonPropertyName("environment")]
    public Environment? Environment { get; set; }

    /// <summary>
    /// The unique identifier of an app in the App Store.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/appappleid"/>
    [JsonPropertyName("appAppleId")]
    public long? AppAppleId { get; set; }

    /// <summary>
    /// The bundle identifier of an app.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/bundleid"/>
    [JsonPropertyName("bundleId")]
    public string? BundleId { get; set; }

    /// <summary>
    /// The unique identifier for the product, that you create in App Store Connect.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/productid"/>
    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    /// <summary>
    /// A string that contains a unique identifier you provide to track each subscription-renewal-date extension request.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/requestidentifier"/>
    [JsonPropertyName("requestIdentifier")]
    public string? RequestIdentifier { get; set; }

    /// <summary>
    /// A list of storefront country codes you provide to limit the storefronts for a subscription-renewal-date extension.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/storefrontcountrycodes"/>
    [JsonPropertyName("storefrontCountryCodes")]
    public string[]? StorefrontCountryCodes { get; set; }

    /// <summary>
    /// The count of subscriptions that successfully receive a subscription-renewal-date extension.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/succeededcount"/>
    [JsonPropertyName("succeededCount")]
    public long? SucceededCount { get; set; }

    /// <summary>
    /// The count of subscriptions that fail to receive a subscription-renewal-date extension.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/failedcount"/>
    [JsonPropertyName("failedCount")]
    public long? FailedCount { get; set; }
}
