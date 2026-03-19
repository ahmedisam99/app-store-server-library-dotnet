using System;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that indicates whether an individual renewal-date extension succeeded, and related details.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/extendrenewaldateresponse"/>
public sealed class ExtendRenewalDateResponse
{
    /// <summary>
    /// The original transaction identifier of a purchase.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/originaltransactionid"/>
    [JsonPropertyName("originalTransactionId")]
    public string? OriginalTransactionId { get; set; }

    /// <summary>
    /// The unique identifier of subscription-purchase events across devices, including renewals.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/weborderlineitemid"/>
    [JsonPropertyName("webOrderLineItemId")]
    public string? WebOrderLineItemId { get; set; }

    /// <summary>
    /// A Boolean value that indicates whether the subscription-renewal-date extension succeeded.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/success"/>
    [JsonPropertyName("success")]
    public bool? Success { get; set; }

    /// <summary>
    /// The new subscription expiration date for a subscription-renewal extension.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/effectivedate"/>
    [JsonPropertyName("effectiveDate")]
    public long? EffectiveDate { get; set; }

    /// <summary>
    /// The UTC date and time of the new subscription expiration date for a subscription-renewal extension,
    /// derived from <see cref="EffectiveDate"/>.
    /// </summary>
    [JsonIgnore]
    public DateTime? EffectiveDateUtc => EffectiveDate.HasValue
        ? DateTimeOffset.FromUnixTimeMilliseconds(EffectiveDate.Value).UtcDateTime
        : null;
}
