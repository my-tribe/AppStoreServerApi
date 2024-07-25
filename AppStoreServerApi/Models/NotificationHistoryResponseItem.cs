using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/notificationhistoryresponseitem
public record NotificationHistoryResponseItem(
    [property: JsonPropertyName("sendAttempts")] ImmutableArray<SendAttemptItem> sendAttempts,
    [property: JsonPropertyName("signedPayload")] string SignedPayload
);
