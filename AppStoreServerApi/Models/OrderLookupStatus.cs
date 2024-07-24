using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/orderlookupstatus
[JsonConverter(typeof(OrderLookupStatusConverter))]
public record OrderLookupStatus(int RawValue)
{
    public static readonly OrderLookupStatus Valid = new(0);
    public static readonly OrderLookupStatus InvalidOrEmpty = new(1);
}