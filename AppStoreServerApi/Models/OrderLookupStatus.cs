using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/orderlookupstatus
[JsonConverter(typeof(RawInt32Converter<OrderLookupStatus>))]
public record OrderLookupStatus(int RawValue) : IRawInt32<OrderLookupStatus>
{
    public static readonly OrderLookupStatus Valid = new(0);
    public static readonly OrderLookupStatus InvalidOrEmpty = new(1);

    static OrderLookupStatus IRawInt32<OrderLookupStatus>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<OrderLookupStatus>.IntoRaw() => RawValue;
}