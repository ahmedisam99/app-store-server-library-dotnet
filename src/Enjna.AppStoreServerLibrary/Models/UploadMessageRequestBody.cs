using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The request body for uploading a message, which includes the message text and an optional image reference.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/uploadmessagerequestbody"/>
public sealed class UploadMessageRequestBody
{
    /// <summary>
    /// The header text of the retention message that the system displays to customers.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/header"/>
    [JsonPropertyName("header")]
    public required string Header { get; set; }

    /// <summary>
    /// The body text of the retention message that the system displays to customers.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/body"/>
    [JsonPropertyName("body")]
    public required string Body { get; set; }

    /// <summary>
    /// The optional image identifier and its alternative text to appear as part of a text-based message with an image.
    /// </summary>
    /// <seealso href="https://developer.apple.com/documentation/retentionmessaging/uploadmessageimage"/>
    [JsonPropertyName("image")]
    public UploadMessageImage? Image { get; set; }
}
