using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/priceincreasestatus
[JsonConverter(typeof(RawInt32Converter<PriceIncreaseStatus>))]
public record PriceIncreaseStatus(int RawValue) : IRawInt32<PriceIncreaseStatus>
{
    public static readonly PriceIncreaseStatus CustomerNotConsented = new(0);
    public static readonly PriceIncreaseStatus CustomerConsented = new(1);

    static PriceIncreaseStatus IRawInt32<PriceIncreaseStatus>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<PriceIncreaseStatus>.IntoRaw() => RawValue;
}