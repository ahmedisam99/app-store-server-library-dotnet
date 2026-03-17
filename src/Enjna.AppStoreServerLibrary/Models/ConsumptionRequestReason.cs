using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The customer-provided reason for a refund request.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/consumptionrequestreason"/>
[JsonConverter(typeof(JsonEnumMemberConverter<ConsumptionRequestReason>))]
public enum ConsumptionRequestReason
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The customer didn't intend to make the in-app purchase.
    /// </summary>
    [EnumMember(Value = "UNINTENDED_PURCHASE")]
    UnintendedPurchase,

    /// <summary>
    /// The customer had issues with receiving or using the in-app purchase.
    /// </summary>
    [EnumMember(Value = "FULFILLMENT_ISSUE")]
    FulfillmentIssue,

    /// <summary>
    /// The customer wasn't satisfied with the in-app purchase.
    /// </summary>
    [EnumMember(Value = "UNSATISFIED_WITH_PURCHASE")]
    UnsatisfiedWithPurchase,

    /// <summary>
    /// The customer requested a refund based on a legal reason.
    /// </summary>
    [EnumMember(Value = "LEGAL")]
    Legal,

    /// <summary>
    /// The customer requested a refund for other reasons.
    /// </summary>
    [EnumMember(Value = "OTHER")]
    Other
}
