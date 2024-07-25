using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/sendattemptitem
public record SendAttemptItem(
    [property: JsonPropertyName("attemptDate"), JsonConverter(typeof(DateTimeConverter))] DateTime AttemptDate,
    [property: JsonPropertyName("sendAttemptResult")] SendAttemptResult SendAttemptResult
);
