using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/status
[JsonConverter(typeof(RawInt32Converter<Status>))]
public record Status(int RawValue) : IRawInt32<Status>
{
    public readonly Status Active = new(1);
    public readonly Status Expired = new(2);
    public readonly Status BillingRetry = new(3);
    public readonly Status BillingGrace = new(4);
    public readonly Status Revoked = new(5);

    static Status IRawInt32<Status>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<Status>.IntoRaw() => RawValue;
}