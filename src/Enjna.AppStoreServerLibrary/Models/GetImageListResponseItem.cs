using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// An image identifier and state information for an image.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/getimagelistresponseitem"/>
public sealed class GetImageListResponseItem
{
    /// <summary>
    /// The identifier of the image.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/imageidentifier"/>
    [JsonPropertyName("imageIdentifier")]
    public string? ImageIdentifier { get; set; }

    /// <summary>
    /// The current state of the image.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/imagestate"/>
    [JsonPropertyName("imageState")]
    public ImageState? ImageState { get; set; }
}
