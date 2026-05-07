using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The period of a discount offer for an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/offer"/>
[JsonConverter(typeof(JsonEnumMemberConverter<AdvancedCommerceOfferPeriod>))]
public enum AdvancedCommerceOfferPeriod
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    [EnumMember(Value = "P3D")]
    P3D,

    [EnumMember(Value = "P1W")]
    P1W,

    [EnumMember(Value = "P2W")]
    P2W,

    [EnumMember(Value = "P1M")]
    P1M,

    [EnumMember(Value = "P2M")]
    P2M,

    [EnumMember(Value = "P3M")]
    P3M,

    [EnumMember(Value = "P6M")]
    P6M,

    [EnumMember(Value = "P9M")]
    P9M,

    [EnumMember(Value = "P1Y")]
    P1Y
}
