using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The sort order for the transaction history records.
/// </summary>
[JsonConverter(typeof(JsonEnumMemberConverter<SortOrder>))]
public enum SortOrder
{
    [EnumMember(Value = "ASCENDING")]
    Ascending,

    [EnumMember(Value = "DESCENDING")]
    Descending
}
