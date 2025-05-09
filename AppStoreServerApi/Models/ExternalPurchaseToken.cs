using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/externalpurchasetoken
public record ExternalPurchaseToken(
    [property: JsonPropertyName("externalPurchaseId")] string ExternalPurchaseId,
    [property: JsonPropertyName("tokenCreationDate"), JsonConverter(typeof(Json.DateTimeConverter))] DateTime TokenCreationDate,
    [property: JsonPropertyName("appAppleId")] long AppAppleId,
    [property: JsonPropertyName("bundleId")] string BundleId
);