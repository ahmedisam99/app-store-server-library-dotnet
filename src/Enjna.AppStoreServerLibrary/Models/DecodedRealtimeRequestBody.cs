using System;
using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The decoded request body the App Store sends to your server to request a real-time retention message.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/decodedrealtimerequestbody"/>
public sealed class DecodedRealtimeRequestBody : DecodedSignedData
{
    /// <summary>
    /// The original transaction identifier of the customer's subscription.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/originaltransactionid"/>
    [JsonPropertyName("originalTransactionId")]
    public required string OriginalTransactionId { get; set; }

    /// <summary>
    /// The unique identifier of the app in the App Store.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/appappleid"/>
    [JsonPropertyName("appAppleId")]
    public long AppAppleId { get; set; }

    /// <summary>
    /// The unique identifier of the auto-renewable subscription.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/productid"/>
    [JsonPropertyName("productId")]
    public required string ProductId { get; set; }

    /// <summary>
    /// The device's locale.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/locale"/>
    [JsonPropertyName("userLocale")]
    public required string UserLocale { get; set; }

    /// <summary>
    /// A UUID the App Store server creates to uniquely identify each request.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/requestidentifier"/>
    [JsonPropertyName("requestIdentifier")]
    public required string RequestIdentifier { get; set; }

    /// <summary>
    /// The server environment, either sandbox or production.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/environment"/>
    [JsonPropertyName("environment")]
    public AppStoreEnvironment Environment { get; set; }

    /// <summary>
    /// The UNIX time, in milliseconds, that the App Store signed the JSON Web Signature data.
    /// </summary>
    [JsonPropertyName("signedDate")]
    public new long SignedDate { get; set; }

    /// <summary>
    /// The UTC date and time that the App Store signed the JSON Web Signature data,
    /// derived from <see cref="SignedDate"/>.
    /// </summary>
    [JsonIgnore]
    public new DateTime SignedDateUtc => DateTimeOffset.FromUnixTimeMilliseconds(SignedDate).UtcDateTime;
}
