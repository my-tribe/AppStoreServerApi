using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/expirationintent
[JsonConverter(typeof(RawInt32Converter<ExpirationIntent>))]
public record ExpirationIntent(int RawValue) : IRawInt32<ExpirationIntent>
{
    public static readonly ExpirationIntent Cancelled = new(1);
    public static readonly ExpirationIntent BillingError = new(2);
    public static readonly ExpirationIntent DidNotConsent = new(3);
    public static readonly ExpirationIntent ProductWasNotAvailable = new(4);
    public static readonly ExpirationIntent Other = new(5);

    static ExpirationIntent IRawInt32<ExpirationIntent>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<ExpirationIntent>.IntoRaw() => RawValue;
}