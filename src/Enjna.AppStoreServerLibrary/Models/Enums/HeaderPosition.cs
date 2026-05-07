using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The position where the header text appears in a message.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/headerposition"/>
[JsonConverter(typeof(JsonEnumMemberConverter<HeaderPosition>))]
public enum HeaderPosition
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The header text appears above the body text.
    /// </summary>
    [EnumMember(Value = "ABOVE_BODY")]
    AboveBody,

    /// <summary>
    /// The header text appears above the image.
    /// </summary>
    [EnumMember(Value = "ABOVE_IMAGE")]
    AboveImage
}
