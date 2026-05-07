using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request data your app provides to make changes to an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionmodifyinapprequest"/>
public sealed class AdvancedCommerceSubscriptionModifyInAppRequest : AdvancedCommerceInAppRequest
{
    /// <summary>
    /// Items to add to the subscription.
    /// </summary>
    [JsonPropertyName("addItems")]
    public AdvancedCommerceSubscriptionModifyAddItem[]? AddItems { get; set; }

    /// <summary>
    /// Items to change in the subscription.
    /// </summary>
    [JsonPropertyName("changeItems")]
    public AdvancedCommerceSubscriptionModifyChangeItem[]? ChangeItems { get; set; }

    /// <summary>
    /// The currency of the transaction.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// Updates to the subscription's descriptors.
    /// </summary>
    [JsonPropertyName("descriptors")]
    public AdvancedCommerceSubscriptionModifyDescriptors? Descriptors { get; set; }

    /// <summary>
    /// A change to the subscription's period.
    /// </summary>
    [JsonPropertyName("periodChange")]
    public AdvancedCommerceSubscriptionModifyPeriodChange? PeriodChange { get; set; }

    /// <summary>
    /// Items to remove from the subscription.
    /// </summary>
    [JsonPropertyName("removeItems")]
    public AdvancedCommerceSubscriptionModifyRemoveItem[]? RemoveItems { get; set; }

    /// <summary>
    /// Whether to retain the current billing cycle.
    /// </summary>
    [JsonPropertyName("retainBillingCycle")]
    public required bool RetainBillingCycle { get; set; }

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

    /// <summary>
    /// The transaction identifier of the subscription to modify.
    /// </summary>
    [JsonPropertyName("transactionId")]
    public required string TransactionId { get; set; }
}
