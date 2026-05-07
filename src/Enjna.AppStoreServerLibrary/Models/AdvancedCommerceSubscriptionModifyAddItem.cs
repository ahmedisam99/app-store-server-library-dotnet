using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The data your app provides to add items when it makes changes to an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionmodifyadditem"/>
public sealed class AdvancedCommerceSubscriptionModifyAddItem
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
    /// A discount offer for the subscription item.
    /// </summary>
    [JsonPropertyName("offer")]
    public AdvancedCommerceOffer? Offer { get; set; }

    /// <summary>
    /// The price of the item, in milliunits.
    /// </summary>
    [JsonPropertyName("price")]
    public required long Price { get; set; }

    /// <summary>
    /// The prorated price of the item, in milliunits.
    /// </summary>
    [JsonPropertyName("proratedPrice")]
    public long? ProratedPrice { get; set; }
}
