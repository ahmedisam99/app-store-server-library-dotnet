using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The most recent App Store-signed transaction information and App Store-signed renewal information for an auto-renewable subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/lasttransactionsitem"/>
public sealed class LastTransactionsItem
{
    /// <summary>
    /// The status of the auto-renewable subscription.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/status"/>
    [JsonPropertyName("status")]
    public Status? Status { get; set; }

    /// <summary>
    /// The original transaction identifier of a purchase.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/originaltransactionid"/>
    [JsonPropertyName("originalTransactionId")]
    public string? OriginalTransactionId { get; set; }

    /// <summary>
    /// Transaction information signed by the App Store, in JSON Web Signature (JWS) format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwstransaction"/>
    [JsonPropertyName("signedTransactionInfo")]
    public string? SignedTransactionInfo { get; set; }

    /// <summary>
    /// Subscription renewal information, signed by the App Store, in JSON Web Signature (JWS) format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/jwsrenewalinfo"/>
    [JsonPropertyName("signedRenewalInfo")]
    public string? SignedRenewalInfo { get; set; }
}
