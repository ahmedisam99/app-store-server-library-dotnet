using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A string that provides details about select notification types in version 2.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/subtype"/>
[JsonConverter(typeof(JsonEnumMemberConverter<Subtype>))]
public enum Subtype
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.Subscribed"/>
    /// notification type. A notification with this subtype indicates that the customer purchased
    /// the subscription for the first time or that the customer received access to the subscription through Family Sharing for the first time.
    /// </summary>
    [EnumMember(Value = "INITIAL_BUY")]
    InitialBuy,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.Subscribed"/>
    /// notification type. A notification with this subtype indicates that the customer resubscribed
    /// or received access through Family Sharing to the same subscription or to another subscription within the same subscription group.
    /// </summary>
    [EnumMember(Value = "RESUBSCRIBE")]
    Resubscribe,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.DidChangeRenewalPref"/> and <see cref="NotificationTypeV2.OfferRedeemed"/>
    /// notification types. A notification with this subtype indicates that the customer downgraded
    /// their subscription or cross-graded to a subscription with a different duration. Downgrades take effect at the next renewal date.
    /// </summary>
    [EnumMember(Value = "DOWNGRADE")]
    Downgrade,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.DidChangeRenewalPref"/> and <see cref="NotificationTypeV2.OfferRedeemed"/>
    /// notification types. A notification with this subtype indicates that the customer upgraded
    /// their subscription or cross-graded to a subscription with the same duration. Upgrades take effect immediately.
    /// </summary>
    [EnumMember(Value = "UPGRADE")]
    Upgrade,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.DidChangeRenewalStatus"/>
    /// notification type. A notification with this subtype indicates that the customer enabled
    /// subscription auto-renewal.
    /// </summary>
    [EnumMember(Value = "AUTO_RENEW_ENABLED")]
    AutoRenewEnabled,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.DidChangeRenewalStatus"/>
    /// notification type. A notification with this subtype indicates that the customer turned off
    /// subscription auto-renewal, or the App Store turned off subscription auto-renewal after the customer requested a refund.
    /// </summary>
    [EnumMember(Value = "AUTO_RENEW_DISABLED")]
    AutoRenewDisabled,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.Expired"/>
    /// notification type. A notification with this subtype indicates that the subscription expired
    /// after the customer turned off subscription auto-renewal.
    /// </summary>
    [EnumMember(Value = "VOLUNTARY")]
    Voluntary,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.Expired"/>
    /// notification type. A notification with this subtype indicates that the subscription expired
    /// because the subscription failed to renew before the billing retry period ended.
    /// </summary>
    [EnumMember(Value = "BILLING_RETRY")]
    BillingRetry,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.Expired"/>
    /// notification type. A notification with this subtype indicates that the subscription expired
    /// because the customer didn't consent to a price increase.
    /// </summary>
    [EnumMember(Value = "PRICE_INCREASE")]
    PriceIncrease,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.DidFailToRenew"/>
    /// notification type. A notification with this subtype indicates that the subscription failed
    /// to renew due to a billing issue. Continue to provide access to the subscription during the grace period.
    /// </summary>
    [EnumMember(Value = "GRACE_PERIOD")]
    GracePeriod,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.PriceIncrease"/>
    /// notification type. A notification with this subtype indicates that the system informed the
    /// customer of the subscription price increase, but the customer hasn't accepted it.
    /// </summary>
    [EnumMember(Value = "PENDING")]
    Pending,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.PriceIncrease"/>
    /// notification type. A notification with this subtype indicates that the customer consented to
    /// the subscription price increase if the price increase requires customer consent, or that the system notified them of a price increase
    /// if the price increase doesn't require customer consent.
    /// </summary>
    [EnumMember(Value = "ACCEPTED")]
    Accepted,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.DidRenew"/>
    /// notification type. A notification with this subtype indicates that the expired subscription
    /// that previously failed to renew has successfully renewed.
    /// </summary>
    [EnumMember(Value = "BILLING_RECOVERY")]
    BillingRecovery,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.Expired"/>
    /// notification type. A notification with this subtype indicates that the subscription expired
    /// because the product wasn't available for purchase at the time the subscription attempted to renew.
    /// </summary>
    [EnumMember(Value = "PRODUCT_NOT_FOR_SALE")]
    ProductNotForSale,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.RenewalExtension"/>
    /// notification type. A notification with this subtype indicates that the App Store server
    /// completed your request to extend the subscription renewal date for all eligible subscribers. For the summary details, see the
    /// <see cref="Models.Summary"/> object in the <see cref="ResponseBodyV2DecodedPayload"/>. For information on the request, see
    /// <see href="https://developer.apple.com/documentation/AppStoreServerAPI/Extend-Subscription-Renewal-Dates-for-All-Active-Subscribers">Extend Subscription Renewal Dates for All Active Subscribers</see>.
    /// </summary>
    [EnumMember(Value = "SUMMARY")]
    Summary,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.RenewalExtension"/>
    /// notification type. A notification with this subtype indicates that the subscription-renewal-date
    /// extension failed for an individual subscription. For details, see the
    /// <see href="https://developer.apple.com/documentation/appstoreservernotifications/data">data</see> object in the
    /// <see cref="ResponseBodyV2DecodedPayload"/>. For information on the request, see
    /// <see href="https://developer.apple.com/documentation/AppStoreServerAPI/Extend-Subscription-Renewal-Dates-for-All-Active-Subscribers">Extend Subscription Renewal Dates for All Active Subscribers</see>.
    /// </summary>
    [EnumMember(Value = "FAILURE")]
    Failure,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.ExternalPurchaseToken"/>
    /// notification type. A notification with this subtype indicates that Apple created a token for
    /// your app but didn't receive a report. For more information about reporting the token, see
    /// <see cref="Models.ExternalPurchaseToken">externalPurchaseToken</see>.
    /// </summary>
    [EnumMember(Value = "UNREPORTED")]
    Unreported,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.ExternalPurchaseToken"/>
    /// notification type. A notification with this subtype indicates that Apple created a custom link
    /// token for your app. For more information about custom link tokens, see
    /// <see href="https://developer.apple.com/documentation/StoreKit/receiving-and-decoding-external-purchase-tokens">Receiving and decoding external purchase tokens</see>.
    /// </summary>
    [EnumMember(Value = "CREATED")]
    Created,

    /// <summary>
    /// Applies to the <see cref="NotificationTypeV2.ExternalPurchaseToken"/>
    /// notification type. A notification with this subtype is a reminder that Apple created a custom
    /// link external purchase token for your app, and the token is still active. App Store Server sends this notification monthly while the
    /// token is active, unless you report the token as a duplicate. For information about reporting tokens, see
    /// <see cref="Models.ExternalPurchaseToken">externalPurchaseToken</see>.
    /// </summary>
    [EnumMember(Value = "ACTIVE_TOKEN_REMINDER")]
    ActiveTokenReminder
}
