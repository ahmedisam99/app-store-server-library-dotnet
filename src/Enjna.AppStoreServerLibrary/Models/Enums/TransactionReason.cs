using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The cause of a purchase transaction, which indicates whether it's a customer's purchase or a renewal for an auto-renewable subscription that the system initiates.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/transactionreason"/>
[JsonConverter(typeof(JsonEnumMemberConverter<TransactionReason>))]
public enum TransactionReason
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The customer initiated the purchase, which may be for any in-app purchase type: consumable, non-consumable, non-renewing subscription, or auto-renewable subscription.
    /// </summary>
    [EnumMember(Value = "PURCHASE")]
    Purchase,

    /// <summary>
    /// The App Store server initiated the purchase transaction to renew an auto-renewable subscription.
    /// </summary>
    [EnumMember(Value = "RENEWAL")]
    Renewal
}
