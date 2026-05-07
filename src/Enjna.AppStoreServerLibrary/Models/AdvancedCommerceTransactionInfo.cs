using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// Transaction information that is present only for Advanced Commerce SKUs.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/advancedcommercetransactioninfo"/>
public sealed class AdvancedCommerceTransactionInfo
{
    /// <summary>
    /// The descriptors associated with the transaction.
    /// </summary>
    [JsonPropertyName("descriptors")]
    public AdvancedCommerceDescriptors? Descriptors { get; set; }

    /// <summary>
    /// The estimated tax for the transaction, in milliunits.
    /// </summary>
    [JsonPropertyName("estimatedTax")]
    public long? EstimatedTax { get; set; }

    /// <summary>
    /// The items associated with the transaction.
    /// </summary>
    [JsonPropertyName("items")]
    public AdvancedCommerceTransactionItem[]? Items { get; set; }

    /// <summary>
    /// The subscription period.
    /// </summary>
    [JsonPropertyName("period")]
    public AdvancedCommercePeriod? Period { get; set; }

    /// <summary>
    /// The request reference identifier provided when the transaction was created.
    /// </summary>
    [JsonPropertyName("requestReferenceId")]
    public string? RequestReferenceId { get; set; }

    /// <summary>
    /// The tax code for the transaction.
    /// </summary>
    [JsonPropertyName("taxCode")]
    public string? TaxCode { get; set; }

    /// <summary>
    /// The price of the transaction, excluding tax, in milliunits.
    /// </summary>
    [JsonPropertyName("taxExclusivePrice")]
    public long? TaxExclusivePrice { get; set; }

    /// <summary>
    /// The applicable tax rate.
    /// </summary>
    [JsonPropertyName("taxRate")]
    public string? TaxRate { get; set; }
}
