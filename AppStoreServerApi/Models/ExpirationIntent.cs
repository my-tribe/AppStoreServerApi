using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/expirationintent
[JsonConverter(typeof(ExpirationIntentConverter))]
public record ExpirationIntent(int RawValue)
{
    public static readonly ExpirationIntent Cancelled = new(1);
    public static readonly ExpirationIntent BillingError = new(2);
    public static readonly ExpirationIntent DidNotConsent = new(3);
    public static readonly ExpirationIntent ProductWasNotAvailable = new(4);
    public static readonly ExpirationIntent Other = new(5);
}