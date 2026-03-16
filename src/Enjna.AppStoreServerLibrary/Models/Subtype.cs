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
    [EnumMember(Value = "INITIAL_BUY")]
    InitialBuy,

    [EnumMember(Value = "RESUBSCRIBE")]
    Resubscribe,

    [EnumMember(Value = "DOWNGRADE")]
    Downgrade,

    [EnumMember(Value = "UPGRADE")]
    Upgrade,

    [EnumMember(Value = "AUTO_RENEW_ENABLED")]
    AutoRenewEnabled,

    [EnumMember(Value = "AUTO_RENEW_DISABLED")]
    AutoRenewDisabled,

    [EnumMember(Value = "VOLUNTARY")]
    Voluntary,

    [EnumMember(Value = "BILLING_RETRY")]
    BillingRetry,

    [EnumMember(Value = "PRICE_INCREASE")]
    PriceIncrease,

    [EnumMember(Value = "GRACE_PERIOD")]
    GracePeriod,

    [EnumMember(Value = "PENDING")]
    Pending,

    [EnumMember(Value = "ACCEPTED")]
    Accepted,

    [EnumMember(Value = "BILLING_RECOVERY")]
    BillingRecovery,

    [EnumMember(Value = "PRODUCT_NOT_FOR_SALE")]
    ProductNotForSale,

    [EnumMember(Value = "SUMMARY")]
    Summary,

    [EnumMember(Value = "FAILURE")]
    Failure,

    [EnumMember(Value = "UNREPORTED")]
    Unreported
}
