using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The status of an Advanced Commerce price increase.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/advancedcommercepriceincreaseinfostatus"/>
[JsonConverter(typeof(JsonEnumMemberConverter<AdvancedCommercePriceIncreaseInfoStatus>))]
public enum AdvancedCommercePriceIncreaseInfoStatus
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    [EnumMember(Value = "SCHEDULED")]
    Scheduled,

    [EnumMember(Value = "PENDING")]
    Pending,

    [EnumMember(Value = "ACCEPTED")]
    Accepted
}
