using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The type of refund requested.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/requestrefunditem"/>
[JsonConverter(typeof(JsonEnumMemberConverter<AdvancedCommerceRefundType>))]
public enum AdvancedCommerceRefundType
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    [EnumMember(Value = "FULL")]
    Full,

    [EnumMember(Value = "PRORATED")]
    Prorated,

    [EnumMember(Value = "CUSTOM")]
    Custom
}
