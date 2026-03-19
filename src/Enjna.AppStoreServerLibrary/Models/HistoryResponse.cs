using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that contains the customer's transaction history for an app.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/historyresponse"/>
public sealed class HistoryResponse
{
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

    /// <summary>
    /// The bundle identifier of an app.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/bundleid"/>
    [JsonPropertyName("bundleId")]
    public string? BundleId { get; set; }

    /// <summary>
    /// The unique identifier of an app in the App Store.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/appappleid"/>
    [JsonPropertyName("appAppleId")]
    public long? AppAppleId { get; set; }

    /// <summary>
    /// The server environment in which you're making the request, whether sandbox or production.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/environment"/>
    [JsonPropertyName("environment")]
    public Environment? Environment { get; set; }

    /// <summary>
    /// An array of in-app purchase transactions for the customer, signed by Apple, in JSON Web Signature format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwstransaction"/>
    [JsonPropertyName("signedTransactions")]
    public string[]? SignedTransactions { get; set; }
}
