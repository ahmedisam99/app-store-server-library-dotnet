using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// A response that contains status information for all images.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/getimagelistresponse"/>
public sealed class GetImageListResponse
{
    /// <summary>
    /// An array of all image identifiers and their image state.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/getimagelistresponseitem"/>
    [JsonPropertyName("imageIdentifiers")]
    public GetImageListResponseItem[]? ImageIdentifiers { get; set; }
}
