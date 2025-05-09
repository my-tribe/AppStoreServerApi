using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/responsebodyv2decodedpayload
public record ResponseBodyV2DecodedPayload(
    [property: JsonPropertyName("notificationType")] NotificationType NotificationType,
    [property: JsonPropertyName("subtype")] Subtype Subtype,
    [property: JsonPropertyName("data")] Data? Data,
    [property: JsonPropertyName("summary")] Summary? Summary,
    [property: JsonPropertyName("externalPurchaseToken")] ExternalPurchaseToken? ExternalPurchaseToken,
    [property: JsonPropertyName("version")] string Version,
    [property: JsonPropertyName("signedDate"), JsonConverter(typeof(Json.DateTimeConverter))] DateTime SignedDate,
    [property: JsonPropertyName("notificationUUID")] string NotificationUUID
);