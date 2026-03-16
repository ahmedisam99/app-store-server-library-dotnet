using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body that contains subscription-renewal-extension data for an individual subscription.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/extendrenewaldaterequest"/>
public sealed class ExtendRenewalDateRequest
{
    /// <summary>
    /// The number of days to extend the subscription renewal date.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/extendbydays"/>
    [JsonPropertyName("extendByDays")]
    public int? ExtendByDays { get; set; }

    /// <summary>
    /// The reason code for the subscription date extension.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/extendreasoncode"/>
    [JsonPropertyName("extendReasonCode")]
    public ExtendReasonCode? ExtendReasonCode { get; set; }

    /// <summary>
    /// A string that contains a unique identifier you provide to track each subscription-renewal-date extension request.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/requestidentifier"/>
    [JsonPropertyName("requestIdentifier")]
    public string? RequestIdentifier { get; set; }
}
