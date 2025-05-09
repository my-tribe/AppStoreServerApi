using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/notificationhistoryrequest
public record NotificationHistoryRequest(
    [property: JsonPropertyName("startDate"), JsonConverter(typeof(DateTimeConverter))] DateTime StartDate,
    [property: JsonPropertyName("endDate"), JsonConverter(typeof(DateTimeConverter))] DateTime EndDate,
    [property: JsonPropertyName("notificationType")] NotificationType? NotificationType,
    [property: JsonPropertyName("notificationSubtype")] Subtype? NotificationSubtype,
    [property: JsonPropertyName("onlyFailures")] bool? OnlyFailures,
    [property: JsonPropertyName("transactionId")] string? TransactionId
);
