using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/status
[JsonConverter(typeof(RawInt32Converter<Status>))]
public record Status(int RawValue) : IRawInt32<Status>
{
    public static readonly Status Active = new(1);
    public static readonly Status Expired = new(2);
    public static readonly Status BillingRetry = new(3);
    public static readonly Status BillingGrace = new(4);
    public static readonly Status Revoked = new(5);

    static Status IRawInt32<Status>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<Status>.IntoRaw() => RawValue;
}