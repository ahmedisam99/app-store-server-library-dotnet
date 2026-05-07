using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The data your app provides to change an item of an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionmodifychangeitem"/>
public sealed class AdvancedCommerceSubscriptionModifyChangeItem
{
    /// <summary>
    /// The new product identifier of the item.
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
    /// The current product identifier of the item.
    /// </summary>
    [JsonPropertyName("currentSKU")]
    public required string CurrentSku { get; set; }

    /// <summary>
    /// When the change goes into effect.
    /// </summary>
    [JsonPropertyName("effective")]
    public required AdvancedCommerceEffective Effective { get; set; }

    /// <summary>
    /// A discount offer for the subscription item.
    /// </summary>
    [JsonPropertyName("offer")]
    public AdvancedCommerceOffer? Offer { get; set; }

    /// <summary>
    /// The new price of the item, in milliunits.
    /// </summary>
    [JsonPropertyName("price")]
    public required long Price { get; set; }

    /// <summary>
    /// The prorated price of the item, in milliunits.
    /// </summary>
    [JsonPropertyName("proratedPrice")]
    public long? ProratedPrice { get; set; }

    /// <summary>
    /// The reason for the change.
    /// </summary>
    [JsonPropertyName("reason")]
    public required AdvancedCommerceReason Reason { get; set; }
}
