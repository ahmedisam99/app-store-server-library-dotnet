using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// Values that represent Apple platforms.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/storekit/appstore/platform"/>
[JsonConverter(typeof(JsonEnumMemberConverter<PurchasePlatform>))]
public enum PurchasePlatform
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    [EnumMember(Value = "iOS")]
    Ios,

    [EnumMember(Value = "macOS")]
    MacOs,

    [EnumMember(Value = "tvOS")]
    TvOs,

    [EnumMember(Value = "visionOS")]
    VisionOs
}
