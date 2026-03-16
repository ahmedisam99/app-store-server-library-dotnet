using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The payload data that contains an external purchase token.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/externalpurchasetoken"/>
public sealed class ExternalPurchaseToken
{
    /// <summary>
    /// The field of an external purchase token that uniquely identifies the token.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/externalpurchaseid"/>
    [JsonPropertyName("externalPurchaseId")]
    public string? ExternalPurchaseId { get; set; }

    /// <summary>
    /// The field of an external purchase token that contains the UNIX date, in milliseconds, when the system created the token.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/tokencreationdate"/>
    [JsonPropertyName("tokenCreationDate")]
    public long? TokenCreationDate { get; set; }

    /// <summary>
    /// The unique identifier of an app in the App Store.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/appappleid"/>
    [JsonPropertyName("appAppleId")]
    public long? AppAppleId { get; set; }

    /// <summary>
    /// The bundle identifier of an app.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/bundleid"/>
    [JsonPropertyName("bundleId")]
    public string? BundleId { get; set; }
}
