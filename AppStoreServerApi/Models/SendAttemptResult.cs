using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/sendattemptresult
[JsonConverter(typeof(RawStringConverter<SendAttemptResult>))]
public record SendAttemptResult(string RawValue) : IRawString<SendAttemptResult>
{
    public static readonly SendAttemptResult Success = new("SUCCESS");
    public static readonly SendAttemptResult CircularRedirect = new("CIRCULAR_REDIRECT");
    public static readonly SendAttemptResult InvalidResponse = new("INVALID_RESPONSE");
    public static readonly SendAttemptResult NoResponse = new("NO_RESPONSE");
    public static readonly SendAttemptResult Other = new("OTHER");
    public static readonly SendAttemptResult PrematureClose = new("PREMATURE_CLOSE");
    public static readonly SendAttemptResult SocketIssue = new("SOCKET_ISSUE");
    public static readonly SendAttemptResult TimedOut = new("TIMED_OUT");
    public static readonly SendAttemptResult TlsIssue = new("TLS_ISSUE");
    public static readonly SendAttemptResult UnsuccessfulHttpResponseCode = new("UNSUCCESSFUL_HTTP_RESPONSE_CODE");
    public static readonly SendAttemptResult UnsupportedCharset = new("UNSUPPORTED_CHARSET");

    static SendAttemptResult IRawString<SendAttemptResult>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<SendAttemptResult>.IntoRaw() => RawValue;
}
