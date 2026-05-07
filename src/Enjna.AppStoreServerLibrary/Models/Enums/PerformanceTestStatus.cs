using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The status of the performance test.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/performanceteststatus"/>
[JsonConverter(typeof(JsonEnumMemberConverter<PerformanceTestStatus>))]
public enum PerformanceTestStatus
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The performance test is pending.
    /// </summary>
    [EnumMember(Value = "PENDING")]
    Pending,

    /// <summary>
    /// The performance test passed.
    /// </summary>
    [EnumMember(Value = "PASS")]
    Pass,

    /// <summary>
    /// The performance test failed.
    /// </summary>
    [EnumMember(Value = "FAIL")]
    Fail
}
