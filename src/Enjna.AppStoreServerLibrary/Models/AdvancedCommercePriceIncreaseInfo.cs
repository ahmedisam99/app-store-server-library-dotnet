using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// Information about a price increase for an Advanced Commerce subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/advancedcommercepriceincreaseinfo"/>
public sealed class AdvancedCommercePriceIncreaseInfo
{
    /// <summary>
    /// SKUs whose price increase depends on this item.
    /// </summary>
    [JsonPropertyName("dependentSKUs")]
    public string[]? DependentSkus { get; set; }

    /// <summary>
    /// The price after the increase, in milliunits.
    /// </summary>
    [JsonPropertyName("price")]
    public long? Price { get; set; }

    /// <summary>
    /// The status of the price increase.
    /// </summary>
    [JsonPropertyName("status")]
    public AdvancedCommercePriceIncreaseInfoStatus? Status { get; set; }
}
