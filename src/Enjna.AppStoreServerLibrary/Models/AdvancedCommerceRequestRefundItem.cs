using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// Information about the refund request for an item, such as its SKU, the refund amount, reason, and type.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/requestrefunditem"/>
public sealed class AdvancedCommerceRequestRefundItem
{
    /// <summary>
    /// The product identifier of an in-app purchase product you manage in your own system.
    /// </summary>
    [JsonPropertyName("SKU")]
    public required string Sku { get; set; }

    /// <summary>
    /// The refund amount you're requesting for the SKU, in milliunits of the currency.
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public long? RefundAmount { get; set; }

    /// <summary>
    /// The reason for the refund request.
    /// </summary>
    [JsonPropertyName("refundReason")]
    public AdvancedCommerceRefundReason? RefundReason { get; set; }

    /// <summary>
    /// The type of refund requested.
    /// </summary>
    [JsonPropertyName("refundType")]
    public AdvancedCommerceRefundType? RefundType { get; set; }

    /// <summary>
    /// Whether to revoke access to the SKU.
    /// </summary>
    [JsonPropertyName("revoke")]
    public required bool Revoke { get; set; }
}
