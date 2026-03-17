using Enjna.AppStoreServerLibrary.Models.Enums;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The object that contains the app metadata and signed app transaction information.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/appdata"/>
public sealed class AppData
{
    /// <summary>
    /// The unique identifier of the app that the notification applies to.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/appappleid"/>
    [JsonPropertyName("appAppleId")]
    public long? AppAppleId { get; set; }

    /// <summary>
    /// The bundle identifier of the app.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/bundleid"/>
    [JsonPropertyName("bundleId")]
    public string? BundleId { get; set; }

    /// <summary>
    /// The server environment that the notification applies to, either sandbox or production.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/environment"/>
    [JsonPropertyName("environment")]
    public Environment? Environment { get; set; }

    /// <summary>
    /// App transaction information signed by the App Store, in JSON Web Signature (JWS) format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreservernotifications/jwsapptransaction"/>
    [JsonPropertyName("signedAppTransactionInfo")]
    public string? SignedAppTransactionInfo { get; set; }
}
