using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The metadata to include in Advanced Commerce server requests.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/requestinfo"/>
public sealed class AdvancedCommerceRequestInfo
{
    /// <summary>
    /// A UUID that represents an app account token, to associate with the transaction in the request.
    /// </summary>
    [JsonPropertyName("appAccountToken")]
    public string? AppAccountToken { get; set; }

    /// <summary>
    /// The value of the advancedCommerceConsistencyToken that you receive in the JWSRenewalInfo renewal information for a subscription.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/AppStoreServerAPI/advancedCommerceConsistencyToken"/>
    [JsonPropertyName("consistencyToken")]
    public string? ConsistencyToken { get; set; }

    /// <summary>
    /// A UUID that you provide to uniquely identify each request.
    /// </summary>
    [JsonPropertyName("requestReferenceId")]
    public required string RequestReferenceId { get; set; }
}
