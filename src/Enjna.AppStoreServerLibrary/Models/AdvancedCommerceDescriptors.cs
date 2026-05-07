using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The display name and description of a subscription product.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/advancedcommerceapi/descriptors"/>
public class AdvancedCommerceDescriptors
{
    /// <summary>
    /// A string you provide that describes a SKU. Maximum length: 45 characters.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// A string with a product name that you can localize and is suitable for display to customers. Maximum length: 30 characters.
    /// </summary>
    [JsonPropertyName("displayName")]
    public required string DisplayName { get; set; }
}
