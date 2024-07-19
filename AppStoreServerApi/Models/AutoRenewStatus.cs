using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/autorenewstatus
[JsonConverter(typeof(AutoRenewStatusConverter))]
public record AutoRenewStatus(int RawValue)
{
    public static readonly AutoRenewStatus AutomaticRenewalOff = new(0);
    public static readonly AutoRenewStatus AutomaticRenewalOn = new(1);
}