using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The approval state of a message.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messagestate"/>
[JsonConverter(typeof(JsonEnumMemberConverter<MessageState>))]
public enum MessageState
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The message is awaiting approval.
    /// </summary>
    [EnumMember(Value = "PENDING_REVIEW")]
    PendingReview,

    /// <summary>
    /// The message is approved.
    /// </summary>
    [EnumMember(Value = "APPROVED")]
    Approved,

    /// <summary>
    /// The message is rejected.
    /// </summary>
    [EnumMember(Value = "REJECTED")]
    Rejected
}
