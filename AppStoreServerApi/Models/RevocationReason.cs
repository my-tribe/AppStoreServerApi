using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/revocationreason
[JsonConverter(typeof(RevocationReasonConverter))]
public record RevocationReason(int RawValue)
{
    public static readonly RevocationReason Other = new(0);
    public static readonly RevocationReason Issue = new(1);
}