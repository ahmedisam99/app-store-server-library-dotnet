using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body you use to change the price of an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionpricechangerequest"/>
public sealed class AdvancedCommerceSubscriptionPriceChangeRequest : AdvancedCommerceRequest
{
    /// <summary>
    /// The currency of the prices.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// One or more SKUs and the changed price for each SKU.
    /// </summary>
    [JsonPropertyName("items")]
    public required AdvancedCommerceSubscriptionPriceChangeItem[] Items { get; set; }

    /// <summary>
    /// The App Store storefront of the subscription.
    /// </summary>
    [JsonPropertyName("storefront")]
    public string? Storefront { get; set; }
}
