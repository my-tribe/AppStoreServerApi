using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/consumptionrequestreason
[JsonConverter(typeof(RawStringConverter<ConsumptionRequestReason>))]
public record ConsumptionRequestReason(string RawValue) : IRawString<ConsumptionRequestReason>
{
    public static readonly ConsumptionRequestReason UnintendedPurchase = new("UNINTENDED_PURCHASE");
    public static readonly ConsumptionRequestReason FulfillmentIssue = new("FULFILLMENT_ISSUE");
    public static readonly ConsumptionRequestReason UnsatisfiedWithPurchase = new("UNSATISFIED_WITH_PURCHASE");
    public static readonly ConsumptionRequestReason Legal = new("LEGAL");
    public static readonly ConsumptionRequestReason Other = new("OTHER");

    static ConsumptionRequestReason IRawString<ConsumptionRequestReason>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<ConsumptionRequestReason>.IntoRaw() => RawValue;
}