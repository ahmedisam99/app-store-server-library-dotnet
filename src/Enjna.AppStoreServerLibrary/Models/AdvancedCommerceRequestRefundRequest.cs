using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body for requesting a refund for a transaction.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/requestrefundrequest"/>
public sealed class AdvancedCommerceRequestRefundRequest : AdvancedCommerceRequest
{
    /// <summary>
    /// The currency of the transaction.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// The items you're requesting refunds for.
    /// </summary>
    [JsonPropertyName("items")]
    public required AdvancedCommerceRequestRefundItem[] Items { get; set; }

    /// <summary>
    /// The customer's refund risking preference.
    /// </summary>
    [JsonPropertyName("refundRiskingPreference")]
    public required bool RefundRiskingPreference { get; set; }

    /// <summary>
    /// The App Store storefront of the transaction.
    /// </summary>
    [JsonPropertyName("storefront")]
    public string? Storefront { get; set; }
}
