using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The size of an image.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/imagesize"/>
[JsonConverter(typeof(JsonEnumMemberConverter<ImageSize>))]
public enum ImageSize
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// A full-size image.
    /// </summary>
    [EnumMember(Value = "FULL_SIZE")]
    FullSize,

    /// <summary>
    /// An image used as a bullet point.
    /// </summary>
    [EnumMember(Value = "BULLET_POINT")]
    BulletPoint
}
