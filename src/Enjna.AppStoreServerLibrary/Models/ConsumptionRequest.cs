using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body that contains consumption information for an In-App Purchase.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/consumptionrequest"/>
public sealed class ConsumptionRequest
{
    /// <summary>
    /// A Boolean value that indicates whether the customer consented to provide consumption data to the App Store.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/customerconsented"/>
    [JsonPropertyName("customerConsented")]
    public required bool CustomerConsented { get; set; }

    /// <summary>
    /// An integer that indicates the percentage, in milliunits, of the In-App Purchase the customer consumed.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/consumptionpercentage"/>
    [JsonPropertyName("consumptionPercentage")]
    public int? ConsumptionPercentage { get; set; }

    /// <summary>
    /// A value that indicates whether the app successfully delivered an in-app purchase that works properly.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/deliverystatus"/>
    [JsonPropertyName("deliveryStatus")]
    public required DeliveryStatus DeliveryStatus { get; set; }

    /// <summary>
    /// A value that indicates your preferred outcome for the refund request.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/refundpreference"/>
    [JsonPropertyName("refundPreference")]
    public RefundPreference? RefundPreference { get; set; }

    /// <summary>
    /// A Boolean value that indicates whether you provided, prior to its purchase, a free sample or trial of the content, or information about its functionality.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/samplecontentprovided"/>
    [JsonPropertyName("sampleContentProvided")]
    public required bool SampleContentProvided { get; set; }
}
