using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A value that indicates your preferred outcome for the refund request.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/refundpreference"/>
[JsonConverter(typeof(JsonEnumMemberConverter<RefundPreference>))]
public enum RefundPreference
{
    [EnumMember(Value = "DECLINE")]
    Decline,

    [EnumMember(Value = "GRANT_FULL")]
    GrantFull,

    [EnumMember(Value = "GRANT_PRORATED")]
    GrantProrated
}
