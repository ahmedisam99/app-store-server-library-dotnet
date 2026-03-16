using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that indicates the server successfully received the subscription-renewal-date extension request.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/massextendrenewaldateresponse"/>
public sealed class MassExtendRenewalDateResponse
{
    /// <summary>
    /// A string that contains a unique identifier you provide to track each subscription-renewal-date extension request.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/requestidentifier"/>
    [JsonPropertyName("requestIdentifier")]
    public string? RequestIdentifier { get; set; }
}
