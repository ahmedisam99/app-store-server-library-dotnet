using Enjna.AppStoreServerLibrary.Models.Enums;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The app metadata and the signed renewal and transaction information.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/data"/>
public sealed class Data
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
    /// The version of the build that identifies an iteration of the bundle.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/bundleversion"/>
    [JsonPropertyName("bundleVersion")]
    public string? BundleVersion { get; set; }

    /// <summary>
    /// Transaction information signed by the App Store, in JSON Web Signature (JWS) format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwstransaction"/>
    [JsonPropertyName("signedTransactionInfo")]
    public string? SignedTransactionInfo { get; set; }

    /// <summary>
    /// Subscription renewal information, signed by the App Store, in JSON Web Signature (JWS) format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwsrenewalinfo"/>
    [JsonPropertyName("signedRenewalInfo")]
    public string? SignedRenewalInfo { get; set; }

    /// <summary>
    /// The status of an auto-renewable subscription as of the signedDate in the responseBodyV2DecodedPayload.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/status"/>
    [JsonPropertyName("status")]
    public Status? Status { get; set; }

    /// <summary>
    /// The reason the customer requested the refund.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/consumptionrequestreason"/>
    [JsonPropertyName("consumptionRequestReason")]
    public ConsumptionRequestReason? ConsumptionRequestReason { get; set; }
}
