using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/priceincreasestatus
[JsonConverter(typeof(PriceIncreaseStatusConverter))]
public record PriceIncreaseStatus(int RawValue)
{
    public static readonly PriceIncreaseStatus CustomerNotConsented = new(0);
    public static readonly PriceIncreaseStatus CustomerConsented = new(1);
}