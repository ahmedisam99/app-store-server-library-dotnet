using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The type of the refund or revocation that applies to the transaction.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/revocationtype"/>
[JsonConverter(typeof(JsonEnumMemberConverter<RevocationType>))]
public enum RevocationType
{
    [EnumMember(Value = "REFUND_FULL")]
    RefundFull,

    [EnumMember(Value = "REFUND_PRORATED")]
    RefundProrated,

    [EnumMember(Value = "FAMILY_REVOKE")]
    FamilyRevoke
}
