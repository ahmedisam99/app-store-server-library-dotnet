using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A renewal item record contained in <see cref="AdvancedCommerceRenewalInfo"/>.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/advancedcommercerenewalitem"/>
public sealed class AdvancedCommerceRenewalItem
{
    /// <summary>
    /// The product identifier of the item.
    /// </summary>
    [JsonPropertyName("SKU")]
    public string? Sku { get; set; }

    /// <summary>
    /// The description of the item.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The display name of the item.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// The discount offer associated with the item.
    /// </summary>
    [JsonPropertyName("offer")]
    public AdvancedCommerceOffer? Offer { get; set; }

    /// <summary>
    /// The renewal price of the item, in milliunits.
    /// </summary>
    [JsonPropertyName("price")]
    public long? Price { get; set; }

    /// <summary>
    /// Information about a price increase for this item.
    /// </summary>
    [JsonPropertyName("priceIncreaseInfo")]
    public AdvancedCommercePriceIncreaseInfo? PriceIncreaseInfo { get; set; }
}
