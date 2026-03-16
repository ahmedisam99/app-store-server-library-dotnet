using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that contains an array of signed JSON Web Signature (JWS) refunded transactions, and paging information.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/refundhistoryresponse"/>
public sealed class RefundHistoryResponse
{
    /// <summary>
    /// A list of up to 20 JWS transactions, or an empty array if the customer hasn't received any refunds in your app. The transactions are sorted in ascending order by revocationDate.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwstransaction"/>
    [JsonPropertyName("signedTransactions")]
    public string[]? SignedTransactions { get; set; }

    /// <summary>
    /// A token you use in a query to request the next set of transactions for the customer.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/revision"/>
    [JsonPropertyName("revision")]
    public string? Revision { get; set; }

    /// <summary>
    /// A Boolean value indicating whether the App Store has more transaction data.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/hasmore"/>
    [JsonPropertyName("hasMore")]
    public bool? HasMore { get; set; }
}
