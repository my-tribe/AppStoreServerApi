using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/consumptionrequest
public record ConsumptionRequest(
    [property: JsonPropertyName("accountTenure")] AccountTenure AccountTenure,
    [property: JsonPropertyName("appAccountToken")] string AppAccountToken,
    [property: JsonPropertyName("consumptionStatus")] ConsumptionStatus ConsumptionStatus,
    [property: JsonPropertyName("customerConsented")] bool CustomerConsented,
    [property: JsonPropertyName("deliveryStatus")] DeliveryStatus DeliveryStatus,
    [property: JsonPropertyName("lifetimeDollarsPurchased")] LifetimeDollarsPurchased LifetimeDollarsPurchased,
    [property: JsonPropertyName("lifetimeDollarsRefunded")] LifetimeDollarsRefunded LifetimeDollarsRefunded,
    [property: JsonPropertyName("platform")] Platform Platform,
    [property: JsonPropertyName("playTime")] PlayTime PlayTime,
    [property: JsonPropertyName("refundPreference")] RefundPreference RefundPreference,
    [property: JsonPropertyName("sampleContentProvided")] bool SampleContentProvided,
    [property: JsonPropertyName("userStatus")] UserStatus UserStatus
);