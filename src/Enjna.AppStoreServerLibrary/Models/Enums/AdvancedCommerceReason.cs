using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The reason your app provides for changing an item of an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionmodifychangeitem"/>
[JsonConverter(typeof(JsonEnumMemberConverter<AdvancedCommerceReason>))]
public enum AdvancedCommerceReason
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    [EnumMember(Value = "UPGRADE")]
    Upgrade,

    [EnumMember(Value = "DOWNGRADE")]
    Downgrade,

    [EnumMember(Value = "APPLY_OFFER")]
    ApplyOffer
}
