using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The sort order for the transaction history records.
/// </summary>
[JsonConverter(typeof(JsonEnumMemberConverter<Order>))]
public enum Order
{
    [EnumMember(Value = "ASCENDING")]
    Ascending,

    [EnumMember(Value = "DESCENDING")]
    Descending
}
