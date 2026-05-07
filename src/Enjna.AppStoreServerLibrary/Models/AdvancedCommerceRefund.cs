using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A refund record for an Advanced Commerce transaction.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/advancedcommercerefund"/>
public sealed class AdvancedCommerceRefund
{
    /// <summary>
    /// The refund amount, in milliunits.
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public long? RefundAmount { get; set; }

    /// <summary>
    /// The UNIX time, in milliseconds, when the refund was issued.
    /// </summary>
    [JsonPropertyName("refundDate")]
    public long? RefundDate { get; set; }

    /// <summary>
    /// The reason for the refund.
    /// </summary>
    [JsonPropertyName("refundReason")]
    public AdvancedCommerceRefundReason? RefundReason { get; set; }

    /// <summary>
    /// The type of refund.
    /// </summary>
    [JsonPropertyName("refundType")]
    public AdvancedCommerceRefundType? RefundType { get; set; }
}
