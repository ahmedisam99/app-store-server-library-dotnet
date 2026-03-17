using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The approval state of an image.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/imagestate"/>
[JsonConverter(typeof(JsonEnumMemberConverter<ImageState>))]
public enum ImageState
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The image is awaiting approval.
    /// </summary>
    [EnumMember(Value = "PENDING_REVIEW")]
    PendingReview,

    /// <summary>
    /// The image is approved.
    /// </summary>
    [EnumMember(Value = "APPROVED")]
    Approved,

    /// <summary>
    /// The image is rejected.
    /// </summary>
    [EnumMember(Value = "REJECTED")]
    Rejected
}
