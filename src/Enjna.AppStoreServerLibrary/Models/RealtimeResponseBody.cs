using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response you provide to choose, in real time, a retention message the system displays to the customer.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/realtimeresponsebody"/>
public sealed class RealtimeResponseBody
{
    /// <summary>
    /// A retention message that's text-based and can include an optional image.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/message"/>
    [JsonPropertyName("message")]
    public Message? Message { get; set; }

    /// <summary>
    /// A retention message with a switch-plan option.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/alternateproduct"/>
    [JsonPropertyName("alternateProduct")]
    public AlternateProduct? AlternateProduct { get; set; }

    /// <summary>
    /// A retention message that includes a promotional offer.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/promotionaloffer"/>
    [JsonPropertyName("promotionalOffer")]
    public PromotionalOffer? PromotionalOffer { get; set; }
}
