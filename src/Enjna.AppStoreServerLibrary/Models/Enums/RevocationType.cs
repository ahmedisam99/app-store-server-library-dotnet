using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The type of the refund or revocation that applies to the transaction.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/revocationtype"/>
[JsonConverter(typeof(JsonEnumMemberConverter<RevocationType>))]
public enum RevocationType
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The transaction has a full refund.
    /// </summary>
    [EnumMember(Value = "REFUND_FULL")]
    RefundFull,

    /// <summary>
    /// The transaction has a prorated refund.
    /// </summary>
    [EnumMember(Value = "REFUND_PRORATED")]
    RefundProrated,

    /// <summary>
    /// The transaction is revoked from Family Sharing.
    /// </summary>
    [EnumMember(Value = "FAMILY_REVOKE")]
    FamilyRevoke
}
