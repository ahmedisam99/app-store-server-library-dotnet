using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A promotional offer and message you provide in a real-time response to your Get Retention Message endpoint.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/promotionaloffer"/>
public sealed class PromotionalOffer
{
    /// <summary>
    /// The identifier of the message to display to the customer, along with the promotional offer.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messageidentifier"/>
    [JsonPropertyName("messageIdentifier")]
    public string? MessageIdentifier { get; set; }

    /// <summary>
    /// The promotional offer signature in V2 format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/promotionaloffersignaturev2"/>
    [JsonPropertyName("promotionalOfferSignatureV2")]
    public string? PromotionalOfferSignatureV2 { get; set; }

    /// <summary>
    /// The promotional offer signature in V1 format.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/promotionaloffersignaturev1"/>
    [JsonPropertyName("promotionalOfferSignatureV1")]
    public PromotionalOfferSignatureV1? PromotionalOfferSignatureV1 { get; set; }
}
