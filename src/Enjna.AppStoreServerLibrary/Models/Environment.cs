using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The server environment, either sandbox or production.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/environment"/>
[JsonConverter(typeof(JsonEnumMemberConverter<Environment>))]
public enum Environment
{
    [EnumMember(Value = "Sandbox")]
    Sandbox,

    [EnumMember(Value = "Production")]
    Production,

    [EnumMember(Value = "Xcode")]
    Xcode,

    [EnumMember(Value = "LocalTesting")]
    LocalTesting
}
