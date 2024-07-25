using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/sendattemptitem
public record SendAttemptItem(
    [property: JsonPropertyName("attemptDate")] DateTime AttemptDate,
    [property: JsonPropertyName("sendAttemptResult")] SendAttemptResult SendAttemptResult
);
