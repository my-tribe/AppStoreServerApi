using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/revocationreason
[JsonConverter(typeof(RawInt32Converter<RevocationReason>))]
public record RevocationReason(int RawValue) : IRawInt32<RevocationReason>
{
    public static readonly RevocationReason Other = new(0);
    public static readonly RevocationReason Issue = new(1);

    static RevocationReason IRawInt32<RevocationReason>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<RevocationReason>.IntoRaw() => RawValue;
}