using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The cause of a purchase transaction, which indicates whether it's a customer's purchase or a renewal for an auto-renewable subscription that the system initiates.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/transactionreason"/>
[JsonConverter(typeof(JsonEnumMemberConverter<TransactionReason>))]
public enum TransactionReason
{
    [EnumMember(Value = "PURCHASE")]
    Purchase,

    [EnumMember(Value = "RENEWAL")]
    Renewal
}
