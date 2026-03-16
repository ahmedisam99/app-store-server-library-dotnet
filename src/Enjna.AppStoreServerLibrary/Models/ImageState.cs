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
    [EnumMember(Value = "PENDING_REVIEW")]
    PendingReview,

    [EnumMember(Value = "APPROVED")]
    Approved,

    [EnumMember(Value = "REJECTED")]
    Rejected
}
