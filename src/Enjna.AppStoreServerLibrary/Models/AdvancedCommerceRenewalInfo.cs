using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// Renewal information that is present only for Advanced Commerce SKUs.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/advancedcommercerenewalinfo"/>
public sealed class AdvancedCommerceRenewalInfo
{
    /// <summary>
    /// The consistency token associated with the renewal information.
    /// </summary>
    [JsonPropertyName("consistencyToken")]
    public string? ConsistencyToken { get; set; }

    /// <summary>
    /// The descriptors associated with the renewal.
    /// </summary>
    [JsonPropertyName("descriptors")]
    public AdvancedCommerceDescriptors? Descriptors { get; set; }

    /// <summary>
    /// The items that will renew at the next renewal period.
    /// </summary>
    [JsonPropertyName("items")]
    public AdvancedCommerceRenewalItem[]? Items { get; set; }

    /// <summary>
    /// The subscription period.
    /// </summary>
    [JsonPropertyName("period")]
    public AdvancedCommercePeriod? Period { get; set; }

    /// <summary>
    /// The request reference identifier provided when the renewal was created.
    /// </summary>
    [JsonPropertyName("requestReferenceId")]
    public string? RequestReferenceId { get; set; }

    /// <summary>
    /// The tax code for the renewal.
    /// </summary>
    [JsonPropertyName("taxCode")]
    public string? TaxCode { get; set; }
}
