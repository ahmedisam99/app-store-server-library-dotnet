using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The definition of an image with its alternative text.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/uploadmessageimage"/>
public sealed class UploadMessageImage
{
    /// <summary>
    /// The unique identifier of an image.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/imageidentifier"/>
    [JsonPropertyName("imageIdentifier")]
    public required string ImageIdentifier { get; set; }

    /// <summary>
    /// The alternative text you provide for the corresponding image.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/alttext"/>
    [JsonPropertyName("altText")]
    public required string AltText { get; set; }
}
