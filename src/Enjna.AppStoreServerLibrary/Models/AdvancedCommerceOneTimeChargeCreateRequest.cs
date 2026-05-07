using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request data your app provides when a customer purchases a one-time-charge product.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/onetimechargecreaterequest"/>
public sealed class AdvancedCommerceOneTimeChargeCreateRequest : AdvancedCommerceInAppRequest
{
    /// <summary>
    /// The currency of the price of the product.
    /// </summary>
    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    /// <summary>
    /// The details of the product for purchase.
    /// </summary>
    [JsonPropertyName("item")]
    public required AdvancedCommerceOneTimeChargeItem Item { get; set; }

    /// <summary>
    /// The storefront for the transaction.
    /// </summary>
    [JsonPropertyName("storefront")]
    public string? Storefront { get; set; }

    /// <summary>
    /// The tax code for this product.
    /// </summary>
    [JsonPropertyName("taxCode")]
    public required string TaxCode { get; set; }
}
