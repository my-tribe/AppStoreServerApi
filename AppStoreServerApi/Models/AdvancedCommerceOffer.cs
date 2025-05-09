using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommerceoffer
public record AdvancedCommerceOffer(
    [property: JsonPropertyName("period")] AdvancedCommerceOfferPeriod Peroid,
    [property: JsonPropertyName("periodCount")] int PeriodCount,
    [property: JsonPropertyName("price")] long Price,
    [property: JsonPropertyName("reason")] AdvancedCommerceReason Reason
);