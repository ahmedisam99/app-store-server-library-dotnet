using System;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body containing consumption information.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/consumptionrequestv1"/>
[Obsolete("Use ConsumptionRequest instead.")]
public sealed class ConsumptionRequestV1
{
    /// <summary>
    /// A Boolean value that indicates whether the customer consented to provide consumption data to the App Store.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/customerconsented"/>
    [JsonPropertyName("customerConsented")]
    public bool? CustomerConsented { get; set; }

    /// <summary>
    /// A value that indicates the extent to which the customer consumed the in-app purchase.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/consumptionstatus"/>
    [JsonPropertyName("consumptionStatus")]
    public ConsumptionStatus? ConsumptionStatus { get; set; }

    /// <summary>
    /// A value that indicates the platform on which the customer consumed the in-app purchase.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/platform"/>
    [JsonPropertyName("platform")]
    public Platform? Platform { get; set; }

    /// <summary>
    /// A Boolean value that indicates whether you provided, prior to its purchase, a free sample or trial of the content, or information about its functionality.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/samplecontentprovided"/>
    [JsonPropertyName("sampleContentProvided")]
    public bool? SampleContentProvided { get; set; }

    /// <summary>
    /// A value that indicates whether the app successfully delivered an in-app purchase that works properly.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/deliverystatus"/>
    [JsonPropertyName("deliveryStatus")]
    public DeliveryStatusV1? DeliveryStatus { get; set; }

    /// <summary>
    /// The UUID that an app optionally generates to map a customer's in-app purchase with its resulting App Store transaction.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/appaccounttoken"/>
    [JsonPropertyName("appAccountToken")]
    public string? AppAccountToken { get; set; }

    /// <summary>
    /// The age of the customer's account.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/accounttenure"/>
    [JsonPropertyName("accountTenure")]
    public AccountTenure? AccountTenure { get; set; }

    /// <summary>
    /// A value that indicates the amount of time that the customer used the app.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/consumptionrequest"/>
    [JsonPropertyName("playTime")]
    public PlayTime? PlayTime { get; set; }

    /// <summary>
    /// A value that indicates the total amount, in USD, of refunds the customer has received, in your app, across all platforms.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/lifetimedollarsrefunded"/>
    [JsonPropertyName("lifetimeDollarsRefunded")]
    public LifetimeDollarsRefunded? LifetimeDollarsRefunded { get; set; }

    /// <summary>
    /// A value that indicates the total amount, in USD, of in-app purchases the customer has made in your app, across all platforms.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/lifetimedollarspurchased"/>
    [JsonPropertyName("lifetimeDollarsPurchased")]
    public LifetimeDollarsPurchased? LifetimeDollarsPurchased { get; set; }

    /// <summary>
    /// The status of the customer's account.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/userstatus"/>
    [JsonPropertyName("userStatus")]
    public UserStatus? UserStatus { get; set; }

    /// <summary>
    /// A value that indicates your preference, based on your operational logic, as to whether Apple should grant the refund.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/refundpreference"/>
    [JsonPropertyName("refundPreference")]
    public RefundPreferenceV1? RefundPreference { get; set; }
}
