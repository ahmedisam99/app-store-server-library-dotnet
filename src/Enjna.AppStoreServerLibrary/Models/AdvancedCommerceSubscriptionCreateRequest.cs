using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request data your app provides when a customer purchases an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptioncreaterequest"/>
public sealed class AdvancedCommerceSubscriptionCreateRequest : AdvancedCommerceInAppRequest
{
    /// <summary>
    /// The currency of the transaction.
    /// </summary>
    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    /// <summary>
    /// The display name and description of the subscription.
    /// </summary>
    [JsonPropertyName("descriptors")]
    public required AdvancedCommerceDescriptors Descriptors { get; set; }

    /// <summary>
    /// One or more SKUs included in the subscription.
    /// </summary>
    [JsonPropertyName("items")]
    public required AdvancedCommerceSubscriptionCreateItem[] Items { get; set; }

    /// <summary>
    /// The subscription period.
    /// </summary>
    [JsonPropertyName("period")]
    public required AdvancedCommercePeriod Period { get; set; }

    /// <summary>
    /// The transaction identifier of a previous transaction this subscription replaces.
    /// </summary>
    [JsonPropertyName("previousTransactionId")]
    public string? PreviousTransactionId { get; set; }

    /// <summary>
    /// The App Store storefront for the transaction.
    /// </summary>
    [JsonPropertyName("storefront")]
    public string? Storefront { get; set; }

    /// <summary>
    /// The tax code for this product.
    /// </summary>
    [JsonPropertyName("taxCode")]
    public required string TaxCode { get; set; }
}
