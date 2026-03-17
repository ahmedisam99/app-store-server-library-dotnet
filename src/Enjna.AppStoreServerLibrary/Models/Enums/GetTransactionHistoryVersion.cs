using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The version of the Get Transaction History endpoint to use.
/// </summary>
[JsonConverter(typeof(JsonEnumMemberConverter<GetTransactionHistoryVersion>))]
public enum GetTransactionHistoryVersion
{
    /// <summary>
    /// Version 1.
    /// </summary>
    [System.Obsolete]
    [EnumMember(Value = "v1")]
    V1,

    /// <summary>
    /// Version 2.
    /// </summary>
    [EnumMember(Value = "v2")]
    V2
}
