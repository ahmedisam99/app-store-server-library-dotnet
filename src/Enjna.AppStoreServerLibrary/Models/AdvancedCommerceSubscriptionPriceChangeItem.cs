using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The data your app provides to change a subscription price.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionpricechangeitem"/>
public sealed class AdvancedCommerceSubscriptionPriceChangeItem
{
    /// <summary>
    /// The product identifier of the item.
    /// </summary>
    [JsonPropertyName("SKU")]
    public required string Sku { get; set; }

    /// <summary>
    /// The new price for the item, in milliunits.
    /// </summary>
    [JsonPropertyName("price")]
    public required long Price { get; set; }

    /// <summary>
    /// SKUs whose price change depends on this item.
    /// </summary>
    [JsonPropertyName("dependentSKUs")]
    public string[]? DependentSkus { get; set; }
}
