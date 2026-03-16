using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that contains signed app transaction information for a customer.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/apptransactioninforesponse"/>
public sealed class AppTransactionInfoResponse
{
    /// <summary>
    /// A customer's app transaction information, signed by Apple, in JSON Web Signature (JWS) format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwsapptransaction"/>
    [JsonPropertyName("signedAppTransactionInfo")]
    public string? SignedAppTransactionInfo { get; set; }
}
