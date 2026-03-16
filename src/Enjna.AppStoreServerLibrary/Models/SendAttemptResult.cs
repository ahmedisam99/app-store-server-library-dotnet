using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models;

/// <summary>
/// The success or error information the App Store server records when it attempts to send an App Store server notification to your server.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/sendattemptresult"/>
[JsonConverter(typeof(JsonEnumMemberConverter<SendAttemptResult>))]
public enum SendAttemptResult
{
    [EnumMember(Value = "SUCCESS")]
    Success,

    [EnumMember(Value = "TIMED_OUT")]
    TimedOut,

    [EnumMember(Value = "TLS_ISSUE")]
    TlsIssue,

    [EnumMember(Value = "CIRCULAR_REDIRECT")]
    CircularRedirect,

    [EnumMember(Value = "NO_RESPONSE")]
    NoResponse,

    [EnumMember(Value = "SOCKET_ISSUE")]
    SocketIssue,

    [EnumMember(Value = "UNSUPPORTED_CHARSET")]
    UnsupportedCharset,

    [EnumMember(Value = "INVALID_RESPONSE")]
    InvalidResponse,

    [EnumMember(Value = "PREMATURE_CLOSE")]
    PrematureClose,

    [EnumMember(Value = "UNSUCCESSFUL_HTTP_RESPONSE_CODE")]
    UnsuccessfulHttpResponseCode,

    [EnumMember(Value = "OTHER")]
    Other
}
