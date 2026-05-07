using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response object you provide to present an offer or switch-plan recommendation message.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/advancedcommerceinfo"/>
public sealed class AdvancedCommerceInfo
{
    /// <summary>
    /// The identifier of the message to display to the customer, along with the offer or switch-plan recommendation provided in <see cref="AdvancedCommerceData"/>.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messageidentifier"/>
    [JsonPropertyName("messageIdentifier")]
    public string? MessageIdentifier { get; set; }

    /// <summary>
    /// A Base64-encoded JSON object which contains a JWS describing an offer or switch-plan recommendation.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/advancedcommercedata"/>
    [JsonPropertyName("advancedCommerceData")]
    public string? AdvancedCommerceData { get; set; }
}
