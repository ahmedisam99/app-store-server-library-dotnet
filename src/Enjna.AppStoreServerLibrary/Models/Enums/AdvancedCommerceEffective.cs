using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// A string value that indicates when a requested change to an auto-renewable subscription goes into effect.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/effective"/>
[JsonConverter(typeof(JsonEnumMemberConverter<AdvancedCommerceEffective>))]
public enum AdvancedCommerceEffective
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The change goes into effect immediately.
    /// </summary>
    [EnumMember(Value = "IMMEDIATELY")]
    Immediately,

    /// <summary>
    /// The change goes into effect at the next billing cycle.
    /// </summary>
    [EnumMember(Value = "NEXT_BILL_CYCLE")]
    NextBillCycle
}
