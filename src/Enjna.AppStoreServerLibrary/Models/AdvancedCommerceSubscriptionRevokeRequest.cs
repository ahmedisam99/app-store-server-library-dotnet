using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body you provide to terminate a subscription and all its items immediately.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionrevokerequest"/>
public sealed class AdvancedCommerceSubscriptionRevokeRequest : AdvancedCommerceRequest
{
    /// <summary>
    /// The reason for the refund associated with the revocation.
    /// </summary>
    [JsonPropertyName("refundReason")]
    public required AdvancedCommerceRefundReason RefundReason { get; set; }

    /// <summary>
    /// The customer's refund risking preference.
    /// </summary>
    [JsonPropertyName("refundRiskingPreference")]
    public required bool RefundRiskingPreference { get; set; }

    /// <summary>
    /// The type of refund.
    /// </summary>
    [JsonPropertyName("refundType")]
    public required AdvancedCommerceRefundType RefundType { get; set; }

    /// <summary>
    /// The App Store storefront of the subscription.
    /// </summary>
    [JsonPropertyName("storefront")]
    public string? Storefront { get; set; }
}
