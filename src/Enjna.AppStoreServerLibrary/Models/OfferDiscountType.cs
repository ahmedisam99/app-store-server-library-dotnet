using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The payment mode for a discount offer on an In-App Purchase.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/offerdiscounttype"/>
[JsonConverter(typeof(JsonEnumMemberConverter<OfferDiscountType>))]
public enum OfferDiscountType
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// A payment mode of a discount for auto-renewable subscriptions that indicates a free trial.
    /// </summary>
    [EnumMember(Value = "FREE_TRIAL")]
    FreeTrial,

    /// <summary>
    /// A payment mode of a discount for auto-renewable subscriptions that customers pay over a single or multiple billing periods.
    /// </summary>
    [EnumMember(Value = "PAY_AS_YOU_GO")]
    PayAsYouGo,

    /// <summary>
    /// A payment mode of a discount for auto-renewable subscriptions that customers pay up front.
    /// </summary>
    [EnumMember(Value = "PAY_UP_FRONT")]
    PayUpFront,

    /// <summary>
    /// A payment mode for a discount for In-App Purchase types including consumable, non-consumable, and non-renewing subscription.
    /// </summary>
    [EnumMember(Value = "ONE_TIME")]
    OneTime
}
