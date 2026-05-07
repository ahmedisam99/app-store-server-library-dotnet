using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request your app provides to reactivate a subscription that has automatic renewal turned off.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionreactivateinapprequest"/>
public sealed class AdvancedCommerceSubscriptionReactivateInAppRequest : AdvancedCommerceInAppRequest
{
    /// <summary>
    /// Items in the subscription to reactivate.
    /// </summary>
    [JsonPropertyName("items")]
    public AdvancedCommerceSubscriptionReactivateItem[]? Items { get; set; }

    /// <summary>
    /// The App Store storefront of the subscription.
    /// </summary>
    [JsonPropertyName("storefront")]
    public string? Storefront { get; set; }

    /// <summary>
    /// The transaction identifier of the subscription to reactivate.
    /// </summary>
    [JsonPropertyName("transactionId")]
    public required string TransactionId { get; set; }
}
