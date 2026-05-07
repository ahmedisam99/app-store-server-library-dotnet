using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The reason for a discount offer.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/offer"/>
[JsonConverter(typeof(JsonEnumMemberConverter<AdvancedCommerceOfferReason>))]
public enum AdvancedCommerceOfferReason
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    [EnumMember(Value = "ACQUISITION")]
    Acquisition,

    [EnumMember(Value = "WIN_BACK")]
    WinBack,

    [EnumMember(Value = "RETENTION")]
    Retention
}
