using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/consumptionrequestreason
[JsonConverter(typeof(JsonStringEnumConverter<ConsumptionRequestReason>))]
public enum ConsumptionRequestReason
{
    UNINTENDED_PURCHASE,
    FULFILLMENT_ISSUE,
    UNSATISFIED_WITH_PURCHASE,
    LEGAL,
    OTHER
}