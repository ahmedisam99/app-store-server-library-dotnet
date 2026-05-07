using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The text and its bullet-point image to include in a retention message's bulleted list.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/bulletpoint"/>
public sealed class BulletPoint
{
    /// <summary>
    /// The text of the individual bullet point. Maximum length: 66 characters.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/bulletpoint/text"/>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// The identifier of the image to use as the bullet point.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/imageidentifier"/>
    [JsonPropertyName("imageIdentifier")]
    public required string ImageIdentifier { get; set; }

    /// <summary>
    /// The alternative text you provide for the corresponding image of the bullet point. Maximum length: 150 characters.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/alttext"/>
    [JsonPropertyName("altText")]
    public required string AltText { get; set; }
}
