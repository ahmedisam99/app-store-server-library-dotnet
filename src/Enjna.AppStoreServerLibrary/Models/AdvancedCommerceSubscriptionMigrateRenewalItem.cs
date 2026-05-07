using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The item information that replaces a migrated subscription item when the subscription renews.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionmigraterenewalitem"/>
public sealed class AdvancedCommerceSubscriptionMigrateRenewalItem
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
}
