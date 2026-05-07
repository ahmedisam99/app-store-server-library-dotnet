using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// An item record contained in <see cref="AdvancedCommerceTransactionInfo"/>.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/advancedcommercetransactionitem"/>
public sealed class AdvancedCommerceTransactionItem
{
    /// <summary>
    /// The product identifier of the item.
    /// </summary>
    [JsonPropertyName("SKU")]
    public string? Sku { get; set; }

    /// <summary>
    /// The description of the item.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The display name of the item.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// The discount offer associated with the item.
    /// </summary>
    [JsonPropertyName("offer")]
    public AdvancedCommerceOffer? Offer { get; set; }

    /// <summary>
    /// The price of the item, in milliunits.
    /// </summary>
    [JsonPropertyName("price")]
    public long? Price { get; set; }

    /// <summary>
    /// Refund records associated with the item.
    /// </summary>
    [JsonPropertyName("refunds")]
    public AdvancedCommerceRefund[]? Refunds { get; set; }

    /// <summary>
    /// The UNIX time, in milliseconds, when the item was revoked.
    /// </summary>
    [JsonPropertyName("revocationDate")]
    public long? RevocationDate { get; set; }
}
