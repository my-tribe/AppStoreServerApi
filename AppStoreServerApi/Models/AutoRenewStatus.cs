using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/autorenewstatus
[JsonConverter(typeof(RawInt32Converter<AutoRenewStatus>))]
public record AutoRenewStatus(int RawValue) : IRawInt32<AutoRenewStatus>
{
    public static readonly AutoRenewStatus AutomaticRenewalOff = new(0);
    public static readonly AutoRenewStatus AutomaticRenewalOn = new(1);

    static AutoRenewStatus IRawInt32<AutoRenewStatus>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<AutoRenewStatus>.IntoRaw() => RawValue;
}