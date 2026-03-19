using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A decoded payload containing the version 2 notification data.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/responsebodyv2decodedpayload"/>
public sealed class ResponseBodyV2DecodedPayload : DecodedSignedData
{
    /// <summary>
    /// The in-app purchase event for which the App Store sends this version 2 notification.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/notificationtype"/>
    [JsonPropertyName("notificationType")]
    public NotificationTypeV2? NotificationType { get; set; }

    /// <summary>
    /// Additional information that identifies the notification event. The subtype field is present only for specific version 2 notifications.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/subtype"/>
    [JsonPropertyName("subtype")]
    public Subtype? Subtype { get; set; }

    /// <summary>
    /// A unique identifier for the notification.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/notificationuuid"/>
    [JsonPropertyName("notificationUUID")]
    public string? NotificationUUID { get; set; }

    /// <summary>
    /// The object that contains the app metadata and signed renewal and transaction information.
    /// The data, summary, and externalPurchaseToken fields are mutually exclusive. The payload contains only one of these fields.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/data"/>
    [JsonPropertyName("data")]
    public Data? Data { get; set; }

    /// <summary>
    /// A string that indicates the notification's App Store Server Notifications version number.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/version"/>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// The summary data that appears when the App Store server completes your request to extend a subscription renewal date for eligible subscribers.
    /// The data, summary, and externalPurchaseToken fields are mutually exclusive. The payload contains only one of these fields.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/summary"/>
    [JsonPropertyName("summary")]
    public Summary? Summary { get; set; }

    /// <summary>
    /// This field appears when the notificationType is EXTERNAL_PURCHASE_TOKEN.
    /// The data, summary, and externalPurchaseToken fields are mutually exclusive. The payload contains only one of these fields.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/externalpurchasetoken"/>
    [JsonPropertyName("externalPurchaseToken")]
    public ExternalPurchaseToken? ExternalPurchaseToken { get; set; }

    /// <summary>
    /// The object that contains the app metadata and signed app transaction information.
    /// This field appears when the notificationType is RESCIND_CONSENT.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/appdata"/>
    [JsonPropertyName("appData")]
    public AppData? AppData { get; set; }
}
