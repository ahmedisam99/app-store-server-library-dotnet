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
    [EnumMember(Value = "FREE_TRIAL")]
    FreeTrial,

    [EnumMember(Value = "PAY_AS_YOU_GO")]
    PayAsYouGo,

    [EnumMember(Value = "PAY_UP_FRONT")]
    PayUpFront,

    [EnumMember(Value = "ONE_TIME")]
    OneTime
}
