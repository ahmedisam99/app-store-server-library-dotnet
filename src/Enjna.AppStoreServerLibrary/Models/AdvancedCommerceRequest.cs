using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The base class for Advanced Commerce API requests.
/// </summary>
public abstract class AdvancedCommerceRequest
{
    /// <summary>
    /// The metadata to include in server requests.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/requestinfo"/>
    [JsonPropertyName("requestInfo")]
    public required AdvancedCommerceRequestInfo RequestInfo { get; set; }
}
