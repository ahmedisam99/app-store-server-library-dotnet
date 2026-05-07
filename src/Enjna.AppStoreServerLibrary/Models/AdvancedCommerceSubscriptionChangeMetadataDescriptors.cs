using System.Text.Json.Serialization;
using Enjna.AppStoreServerLibrary.Models.Enums;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The subscription metadata to change, specifically the description and display name.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/subscriptionchangemetadatadescriptors"/>
public sealed class AdvancedCommerceSubscriptionChangeMetadataDescriptors
{
    /// <summary>
    /// When the metadata change goes into effect.
    /// </summary>
    [JsonPropertyName("effective")]
    public required AdvancedCommerceEffective Effective { get; set; }

    /// <summary>
    /// The new description for the subscription.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The new display name for the subscription.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }
}
