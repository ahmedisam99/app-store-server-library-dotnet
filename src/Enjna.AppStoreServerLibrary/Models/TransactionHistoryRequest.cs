using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body for the transaction history endpoint.
/// </summary>
public sealed class TransactionHistoryRequest
{
    /// <summary>
    /// An optional start date of the timespan for the transaction history records you're requesting. The startDate must precede the endDate if you specify both dates. To be included in results, the transaction's purchaseDate must be equal to or greater than the startDate.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/startdate"/>
    [JsonPropertyName("startDate")]
    public long? StartDate { get; set; }

    /// <summary>
    /// An optional end date of the timespan for the transaction history records you're requesting. Choose an endDate that's later than the startDate if you specify both dates. Using an endDate in the future is valid. To be included in results, the transaction's purchaseDate must be less than the endDate.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/enddate"/>
    [JsonPropertyName("endDate")]
    public long? EndDate { get; set; }

    /// <summary>
    /// An optional filter that indicates the product identifier to include in the transaction history. Your query may specify more than one productID.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/productid"/>
    [JsonPropertyName("productIds")]
    public string[]? ProductIds { get; set; }

    /// <summary>
    /// An optional filter that indicates the product type to include in the transaction history. Your query may specify more than one productType.
    /// </summary>
    [JsonPropertyName("productTypes")]
    public ProductType[]? ProductTypes { get; set; }

    /// <summary>
    /// An optional sort order for the transaction history records. The response sorts the transaction records by their recently modified date. The default value is ASCENDING, so you receive the oldest records first.
    /// </summary>
    [JsonPropertyName("sort")]
    public SortOrder? Sort { get; set; }

    /// <summary>
    /// An optional filter that indicates the subscription group identifier to include in the transaction history. Your query may specify more than one subscriptionGroupIdentifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/subscriptiongroupidentifier"/>
    [JsonPropertyName("subscriptionGroupIdentifiers")]
    public string[]? SubscriptionGroupIdentifiers { get; set; }

    /// <summary>
    /// An optional filter that limits the transaction history by the in-app ownership type.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/inappownershiptype"/>
    [JsonPropertyName("inAppOwnershipType")]
    public InAppOwnershipType? InAppOwnershipType { get; set; }

    /// <summary>
    /// An optional Boolean value that indicates whether the response includes only revoked transactions when the value is true, or contains only nonrevoked transactions when the value is false. By default, the request doesn't include this parameter.
    /// </summary>
    [JsonPropertyName("revoked")]
    public bool? Revoked { get; set; }
}
