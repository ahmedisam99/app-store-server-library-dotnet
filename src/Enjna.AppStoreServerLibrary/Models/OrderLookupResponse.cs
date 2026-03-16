using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that includes the order lookup status and an array of signed transactions for the in-app purchases in the order.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/orderlookupresponse"/>
public sealed class OrderLookupResponse
{
    /// <summary>
    /// The status that indicates whether the order ID is valid.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/orderlookupstatus"/>
    [JsonPropertyName("status")]
    public OrderLookupStatus? Status { get; set; }

    /// <summary>
    /// An array of in-app purchase transactions that are part of order, signed by Apple, in JSON Web Signature format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwstransaction"/>
    [JsonPropertyName("signedTransactions")]
    public string[]? SignedTransactions { get; set; }
}
