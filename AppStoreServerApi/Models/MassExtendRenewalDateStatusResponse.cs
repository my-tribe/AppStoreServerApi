using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/massextendrenewaldatestatusresponse
public record MassExtendRenewalDateStatusResponse(
    [property: JsonPropertyName("requestIdentifier")] string RequestIdentifier,
    [property: JsonPropertyName("complete")] bool Complete,
    [property: JsonPropertyName("completeDate"), JsonConverter(typeof(DateTimeConverter))] DateTime? CompleteDate,
    [property: JsonPropertyName("failedCount")] long? FailedCount,
    [property: JsonPropertyName("succeededCount")] long? SucceededCount
);