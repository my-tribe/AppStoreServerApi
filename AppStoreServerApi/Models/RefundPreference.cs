using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/refundpreference
[JsonConverter(typeof(RawInt32Converter<RefundPreference>))]
public record RefundPreference(int RawValue) : IRawInt32<RefundPreference>
{ 
    public static readonly RefundPreference Undeclared = new(0);
    public static readonly RefundPreference Grant = new(1);
    public static readonly RefundPreference Decline = new(2);
    public static readonly RefundPreference NoPreference = new(3);

    static RefundPreference IRawInt32<RefundPreference>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<RefundPreference>.IntoRaw() => RawValue;
}
