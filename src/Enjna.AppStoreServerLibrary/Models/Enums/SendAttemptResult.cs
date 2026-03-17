using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary.Models.Enums;

/// <summary>
/// The success or error information the App Store server records when it attempts to send an App Store server notification to your server.
/// </summary>
/// <seealso href="https://developer.apple.com/documentation/appstoreserverapi/sendattemptresult"/>
[JsonConverter(typeof(JsonEnumMemberConverter<SendAttemptResult>))]
public enum SendAttemptResult
{
    /// <summary>
    /// Represents a value not yet supported by this version of the library.
    /// </summary>
    _Unmapped,

    /// <summary>
    /// The App Store server received a success response when it sent the notification to your server.
    /// </summary>
    [EnumMember(Value = "SUCCESS")]
    Success,

    /// <summary>
    /// The App Store server didn't get a response from your server and timed out.
    /// </summary>
    [EnumMember(Value = "TIMED_OUT")]
    TimedOut,

    /// <summary>
    /// The App Store server couldn't establish a TLS session or validate your certificate.
    /// </summary>
    [EnumMember(Value = "TLS_ISSUE")]
    TlsIssue,

    /// <summary>
    /// The App Store server detected a continual redirect. Check your server's redirects for a circular redirect loop.
    /// </summary>
    [EnumMember(Value = "CIRCULAR_REDIRECT")]
    CircularRedirect,

    /// <summary>
    /// The App Store server didn't receive a valid HTTP response from your server.
    /// </summary>
    [EnumMember(Value = "NO_RESPONSE")]
    NoResponse,

    /// <summary>
    /// A network error caused the notification attempt to fail.
    /// </summary>
    [EnumMember(Value = "SOCKET_ISSUE")]
    SocketIssue,

    /// <summary>
    /// The App Store server doesn't support the supplied charset.
    /// </summary>
    [EnumMember(Value = "UNSUPPORTED_CHARSET")]
    UnsupportedCharset,

    /// <summary>
    /// The App Store server received an invalid response from your server.
    /// </summary>
    [EnumMember(Value = "INVALID_RESPONSE")]
    InvalidResponse,

    /// <summary>
    /// The App Store server's connection to your server was closed while the send was in progress.
    /// </summary>
    [EnumMember(Value = "PREMATURE_CLOSE")]
    PrematureClose,

    /// <summary>
    /// The App Store server didn't receive an HTTP 200 response from your server.
    /// </summary>
    [EnumMember(Value = "UNSUCCESSFUL_HTTP_RESPONSE_CODE")]
    UnsuccessfulHttpResponseCode,

    /// <summary>
    /// Another error occurred that prevented your server from receiving the notification.
    /// </summary>
    [EnumMember(Value = "OTHER")]
    Other
}
