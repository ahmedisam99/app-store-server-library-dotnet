using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// A reason to request a refund.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/refundreason"/>
[JsonConverter(typeof(JsonEnumMemberConverter<AdvancedCommerceRefundReason>))]
public enum AdvancedCommerceRefundReason
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    [EnumMember(Value = "UNINTENDED_PURCHASE")]
    UnintendedPurchase,

    [EnumMember(Value = "FULFILLMENT_ISSUE")]
    FulfillmentIssue,

    [EnumMember(Value = "UNSATISFIED_WITH_PURCHASE")]
    UnsatisfiedWithPurchase,

    [EnumMember(Value = "LEGAL")]
    Legal,

    [EnumMember(Value = "OTHER")]
    Other,

    [EnumMember(Value = "MODIFY_ITEMS_REFUND")]
    ModifyItemsRefund,

    [EnumMember(Value = "SIMULATE_REFUND_DECLINE")]
    SimulateRefundDecline
}
