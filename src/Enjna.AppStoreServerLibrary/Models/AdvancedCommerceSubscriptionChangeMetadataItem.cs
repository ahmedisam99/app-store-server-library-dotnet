using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The metadata to change for an item, specifically its SKU, description, and display name.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionchangemetadataitem"/>
public sealed class AdvancedCommerceSubscriptionChangeMetadataItem
{
    /// <summary>
    /// The original SKU of the item.
    /// </summary>
    [JsonPropertyName("currentSKU")]
    public required string CurrentSku { get; set; }

    /// <summary>
    /// When the metadata change goes into effect.
    /// </summary>
    [JsonPropertyName("effective")]
    public required AdvancedCommerceEffective Effective { get; set; }

    /// <summary>
    /// The new description for the item.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The new display name for the item.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// The new SKU of the item.
    /// </summary>
    [JsonPropertyName("SKU")]
    public string? Sku { get; set; }
}
