using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The approval state of a message.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/retentionmessaging/messagestate"/>
[JsonConverter(typeof(JsonEnumMemberConverter<MessageState>))]
public enum MessageState
{
    [EnumMember(Value = "PENDING_REVIEW")]
    PendingReview,

    [EnumMember(Value = "APPROVED")]
    Approved,

    [EnumMember(Value = "REJECTED")]
    Rejected
}
