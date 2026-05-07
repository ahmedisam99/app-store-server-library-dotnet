using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The data your app provides to remove an item from an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionmodifyremoveitem"/>
public sealed class AdvancedCommerceSubscriptionModifyRemoveItem
{
    /// <summary>
    /// The product identifier of the item to remove.
    /// </summary>
    [JsonPropertyName("SKU")]
    public required string Sku { get; set; }
}
