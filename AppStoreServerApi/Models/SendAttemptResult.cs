using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/sendattemptresult
[JsonConverter(typeof(JsonStringEnumConverter<SendAttemptResult>))]
public enum SendAttemptResult
{
    SUCCESS,
    CIRCULAR_REDIRECT,
    INVALID_RESPONSE,
    NO_RESPONSE,
    OTHER,
    PREMATURE_CLOSE,
    SOCKET_ISSUE,
    TIMED_OUT,
    TLS_ISSUE,
    UNSUCCESSFUL_HTTP_RESPONSE_CODE,
    UNSUPPORTED_CHARSET
}
