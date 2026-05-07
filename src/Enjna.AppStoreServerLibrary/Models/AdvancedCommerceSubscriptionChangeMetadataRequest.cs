using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body you provide to change the metadata of a subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionchangemetadatarequest"/>
public sealed class AdvancedCommerceSubscriptionChangeMetadataRequest : AdvancedCommerceRequest
{
    /// <summary>
    /// Updates to the subscription's descriptors.
    /// </summary>
    [JsonPropertyName("descriptors")]
    public AdvancedCommerceSubscriptionChangeMetadataDescriptors? Descriptors { get; set; }

    /// <summary>
    /// Updates to the subscription's items.
    /// </summary>
    [JsonPropertyName("items")]
    public AdvancedCommerceSubscriptionChangeMetadataItem[]? Items { get; set; }

    /// <summary>
    /// The App Store storefront of the subscription.
    /// </summary>
    [JsonPropertyName("storefront")]
    public string? Storefront { get; set; }

    /// <summary>
    /// The tax code for the subscription.
    /// </summary>
    [JsonPropertyName("taxCode")]
    public string? TaxCode { get; set; }
}
