using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body that contains an app account token value.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/updateappaccounttokenrequest"/>
public sealed class UpdateAppAccountTokenRequest
{
    /// <summary>
    /// The UUID that an app optionally generates to map a customer's in-app purchase with its resulting App Store transaction.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/appaccounttoken"/>
    [JsonPropertyName("appAccountToken")]
    public required string AppAccountToken { get; set; }
}
