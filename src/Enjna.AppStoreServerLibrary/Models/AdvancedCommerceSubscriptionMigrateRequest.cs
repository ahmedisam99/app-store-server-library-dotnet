using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The subscription details you provide to migrate a subscription from In-App Purchase to the Advanced Commerce API.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionmigraterequest"/>
public sealed class AdvancedCommerceSubscriptionMigrateRequest : AdvancedCommerceRequest
{
    /// <summary>
    /// The display name and description of the subscription to migrate to.
    /// </summary>
    [JsonPropertyName("descriptors")]
    public required AdvancedCommerceSubscriptionMigrateDescriptors Descriptors { get; set; }

    /// <summary>
    /// One or more SKUs that are included in the subscription.
    /// </summary>
    [JsonPropertyName("items")]
    public required AdvancedCommerceSubscriptionMigrateItem[] Items { get; set; }

    /// <summary>
    /// Items that renew at the next renewal period, if they differ from <see cref="Items"/>.
    /// </summary>
    [JsonPropertyName("renewalItems")]
    public AdvancedCommerceSubscriptionMigrateRenewalItem[]? RenewalItems { get; set; }

    /// <summary>
    /// The App Store storefront for the subscription.
    /// </summary>
    [JsonPropertyName("storefront")]
    public string? Storefront { get; set; }

    /// <summary>
    /// Your generic product ID for the auto-renewable subscription.
    /// </summary>
    [JsonPropertyName("targetProductId")]
    public required string TargetProductId { get; set; }

    /// <summary>
    /// The tax code for the subscription.
    /// </summary>
    [JsonPropertyName("taxCode")]
    public required string TaxCode { get; set; }
}
