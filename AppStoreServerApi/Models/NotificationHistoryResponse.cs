using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/notificationhistoryresponse
public record NotificationHistoryResponse(
    [property: JsonPropertyName("notificationHistory")] ImmutableArray<NotificationHistoryResponseItem> NotificationHistory,
    [property: JsonPropertyName("hasMore")] bool HasMore,
    [property: JsonPropertyName("paginationToken")] string PaginationToken
);
