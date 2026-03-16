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
    [EnumMember(Value = "UNINTENDED_PURCHASE")]
    UnintendedPurchase,

    [EnumMember(Value = "FULFILLMENT_ISSUE")]
    FulfillmentIssue,

    [EnumMember(Value = "UNSATISFIED_WITH_PURCHASE")]
    UnsatisfiedWithPurchase,

    [EnumMember(Value = "LEGAL")]
    Legal,

    [EnumMember(Value = "OTHER")]
    Other
}
