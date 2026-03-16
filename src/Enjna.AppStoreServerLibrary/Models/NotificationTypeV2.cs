using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The type that describes the in-app purchase or external purchase event for which the App Store sends the version 2 notification.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/notificationtype"/>
[JsonConverter(typeof(JsonEnumMemberConverter<NotificationTypeV2>))]
public enum NotificationTypeV2
{
    [EnumMember(Value = "SUBSCRIBED")]
    Subscribed,

    [EnumMember(Value = "DID_CHANGE_RENEWAL_PREF")]
    DidChangeRenewalPref,

    [EnumMember(Value = "DID_CHANGE_RENEWAL_STATUS")]
    DidChangeRenewalStatus,

    [EnumMember(Value = "OFFER_REDEEMED")]
    OfferRedeemed,

    [EnumMember(Value = "DID_RENEW")]
    DidRenew,

    [EnumMember(Value = "EXPIRED")]
    Expired,

    [EnumMember(Value = "DID_FAIL_TO_RENEW")]
    DidFailToRenew,

    [EnumMember(Value = "GRACE_PERIOD_EXPIRED")]
    GracePeriodExpired,

    [EnumMember(Value = "PRICE_INCREASE")]
    PriceIncrease,

    [EnumMember(Value = "REFUND")]
    Refund,

    [EnumMember(Value = "REFUND_DECLINED")]
    RefundDeclined,

    [EnumMember(Value = "CONSUMPTION_REQUEST")]
    ConsumptionRequest,

    [EnumMember(Value = "RENEWAL_EXTENDED")]
    RenewalExtended,

    [EnumMember(Value = "REVOKE")]
    Revoke,

    [EnumMember(Value = "TEST")]
    Test,

    [EnumMember(Value = "RENEWAL_EXTENSION")]
    RenewalExtension,

    [EnumMember(Value = "REFUND_REVERSED")]
    RefundReversed,

    [EnumMember(Value = "EXTERNAL_PURCHASE_TOKEN")]
    ExternalPurchaseToken,

    [EnumMember(Value = "ONE_TIME_CHARGE")]
    OneTimeCharge,

    [EnumMember(Value = "RESCIND_CONSENT")]
    RescindConsent
}
