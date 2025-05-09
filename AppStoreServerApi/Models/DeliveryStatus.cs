using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/deliverystatus
[JsonConverter(typeof(RawInt32Converter<DeliveryStatus>))]
public record DeliveryStatus(int RawValue) : IRawInt32<DeliveryStatus>
{
    public static readonly DeliveryStatus Delivered = new(0);
    public static readonly DeliveryStatus QualityIssue = new(1);
    public static readonly DeliveryStatus WrongItem = new(2);
    public static readonly DeliveryStatus ServerOutage = new(3);
    public static readonly DeliveryStatus CurrencyChange = new(4);
    public static readonly DeliveryStatus Other = new(5);

    static DeliveryStatus IRawInt32<DeliveryStatus>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<DeliveryStatus>.IntoRaw() => RawValue;
}
