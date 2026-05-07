using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// An item in a subscription to reactivate.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionreactivateitem"/>
public sealed class AdvancedCommerceSubscriptionReactivateItem
{
    /// <summary>
    /// The product identifier of the item to reactivate.
    /// </summary>
    [JsonPropertyName("SKU")]
    public required string Sku { get; set; }
}
