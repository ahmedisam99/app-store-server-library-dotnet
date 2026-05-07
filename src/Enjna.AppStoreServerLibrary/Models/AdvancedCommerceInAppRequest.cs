using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The base class for Advanced Commerce in-app requests.
/// </summary>
public abstract class AdvancedCommerceInAppRequest : AdvancedCommerceRequest
{
    /// <summary>
    /// The constant that represents the operation of this request.
    /// </summary>
    [JsonPropertyName("operation")]
    public string? Operation { get; set; }

    /// <summary>
    /// The version number of the API.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
