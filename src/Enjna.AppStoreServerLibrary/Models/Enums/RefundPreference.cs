using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// A value that indicates your preferred outcome for the refund request.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/refundpreference"/>
[JsonConverter(typeof(JsonEnumMemberConverter<RefundPreference>))]
public enum RefundPreference
{
    /// <summary>
    /// You prefer that the App Store declines the refund.
    /// </summary>
    [EnumMember(Value = "DECLINE")]
    Decline,

    /// <summary>
    /// You prefer that the App Store grants the refund in full.
    /// </summary>
    [EnumMember(Value = "GRANT_FULL")]
    GrantFull,

    /// <summary>
    /// You prefer that the App Store grants a prorated refund.
    /// </summary>
    [EnumMember(Value = "GRANT_PRORATED")]
    GrantProrated
}
