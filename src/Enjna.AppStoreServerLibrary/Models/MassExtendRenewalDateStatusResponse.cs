using System;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that indicates the current status of a request to extend the subscription renewal date to all eligible subscribers.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/massextendrenewaldatestatusresponse"/>
public sealed class MassExtendRenewalDateStatusResponse
{
    /// <summary>
    /// A string that contains a unique identifier you provide to track each subscription-renewal-date extension request.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/requestidentifier"/>
    [JsonPropertyName("requestIdentifier")]
    public string? RequestIdentifier { get; set; }

    /// <summary>
    /// A Boolean value that indicates whether the App Store completed the request to extend a subscription renewal date to active subscribers.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/complete"/>
    [JsonPropertyName("complete")]
    public bool? Complete { get; set; }

    /// <summary>
    /// The UNIX time, in milliseconds, that the App Store completes a request to extend a subscription renewal date for eligible subscribers.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/completedate"/>
    [JsonPropertyName("completeDate")]
    public long? CompleteDate { get; set; }

    /// <summary>
    /// The UTC date and time that the App Store completes a request to extend a subscription renewal date,
    /// derived from <see cref="CompleteDate"/>.
    /// </summary>
    [JsonIgnore]
    public DateTime? CompleteDateUtc => CompleteDate.HasValue
        ? DateTimeOffset.FromUnixTimeMilliseconds(CompleteDate.Value).UtcDateTime
        : null;

    /// <summary>
    /// The count of subscriptions that successfully receive a subscription-renewal-date extension.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/succeededcount"/>
    [JsonPropertyName("succeededCount")]
    public long? SucceededCount { get; set; }

    /// <summary>
    /// The count of subscriptions that fail to receive a subscription-renewal-date extension.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/failedcount"/>
    [JsonPropertyName("failedCount")]
    public long? FailedCount { get; set; }
}
