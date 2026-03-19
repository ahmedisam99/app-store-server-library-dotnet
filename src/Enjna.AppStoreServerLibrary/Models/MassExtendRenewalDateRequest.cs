using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body that contains subscription-renewal-extension data to apply for all eligible active subscribers.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/massextendrenewaldaterequest"/>
public sealed class MassExtendRenewalDateRequest
{
    /// <summary>
    /// The number of days to extend the subscription renewal date.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/extendbydays"/>
    [JsonPropertyName("extendByDays")]
    public int? ExtendByDays { get; set; }

    /// <summary>
    /// The reason code for the subscription-renewal-date extension.
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

    /// <summary>
    /// A list of storefront country codes you provide to limit the storefronts for a subscription-renewal-date extension.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/storefrontcountrycodes"/>
    [JsonPropertyName("storefrontCountryCodes")]
    public string[]? StorefrontCountryCodes { get; set; }

    /// <summary>
    /// The unique identifier for the product, that you create in App Store Connect.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/productid"/>
    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }
}
