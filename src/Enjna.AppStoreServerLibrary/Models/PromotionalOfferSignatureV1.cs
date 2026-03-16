using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The promotional offer signature you generate using an earlier signature version.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/promotionaloffersignaturev1"/>
public sealed class PromotionalOfferSignatureV1
{
    /// <summary>
    /// The Base64-encoded cryptographic signature you generate using the offer parameters.
    /// </summary>
    [JsonPropertyName("encodedSignature")]
    public required string EncodedSignature { get; set; }

    /// <summary>
    /// The subscription's product identifier.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/productid"/>
    [JsonPropertyName("productId")]
    public required string ProductId { get; set; }

    /// <summary>
    /// A one-time-use UUID antireplay value you generate.
    /// </summary>
    [JsonPropertyName("nonce")]
    public required string Nonce { get; set; }

    /// <summary>
    /// The UNIX time, in milliseconds, when you generate the signature.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required long Timestamp { get; set; }

    /// <summary>
    /// A string that identifies the private key you use to generate the signature.
    /// </summary>
    [JsonPropertyName("keyId")]
    public required string KeyId { get; set; }

    /// <summary>
    /// The subscription offer identifier that you set up in App Store Connect.
    /// </summary>
    [JsonPropertyName("offerIdentifier")]
    public required string OfferIdentifier { get; set; }

    /// <summary>
    /// A UUID that you provide to associate with the transaction if the customer accepts the promotional offer.
    /// </summary>
    [JsonPropertyName("appAccountToken")]
    public string? AppAccountToken { get; set; }
}
