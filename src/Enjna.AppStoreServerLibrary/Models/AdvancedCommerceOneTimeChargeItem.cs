using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The details of a one-time charge product, including its display name, price, SKU, and metadata.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/onetimechargeitem"/>
public sealed class AdvancedCommerceOneTimeChargeItem
{
    /// <summary>
    /// The product identifier of an in-app purchase product you manage in your own system.
    /// </summary>
    [JsonPropertyName("SKU")]
    public required string Sku { get; set; }

    /// <summary>
    /// A string you provide that describes a SKU.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// A string with a product name that you can localize and is suitable for display to customers.
    /// </summary>
    [JsonPropertyName("displayName")]
    public required string DisplayName { get; set; }

    /// <summary>
    /// The price, in milliunits of the currency, of the one-time charge product.
    /// </summary>
    [JsonPropertyName("price")]
    public required long Price { get; set; }
}
