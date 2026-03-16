using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A switch-plan message and product ID you provide in a real-time response to your Get Retention Message endpoint.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/alternateproduct"/>
public sealed class AlternateProduct
{
    /// <summary>
    /// The message identifier of the text to display in the switch-plan retention message.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messageidentifier"/>
    [JsonPropertyName("messageIdentifier")]
    public string? MessageIdentifier { get; set; }

    /// <summary>
    /// The product identifier of the subscription the retention message suggests for your customer to switch to.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/productid"/>
    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }
}
