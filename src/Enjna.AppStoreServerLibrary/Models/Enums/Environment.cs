using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The server environment, either sandbox or production.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/environment"/>
[JsonConverter(typeof(JsonEnumMemberConverter<Environment>))]
public enum Environment
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// Indicates that the data applies to testing in the sandbox environment.
    /// </summary>
    [EnumMember(Value = "Sandbox")]
    Sandbox,

    /// <summary>
    /// Indicates that the data applies to the production environment.
    /// </summary>
    [EnumMember(Value = "Production")]
    Production,

    /// <summary>
    /// The Xcode environment.
    /// </summary>
    [EnumMember(Value = "Xcode")]
    Xcode,

    /// <summary>
    /// The local testing environment.
    /// </summary>
    [EnumMember(Value = "LocalTesting")]
    LocalTesting
}
