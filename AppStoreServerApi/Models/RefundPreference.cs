using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/refundpreference
[JsonConverter(typeof(RefundPreferenceConverter))]
public record RefundPreference(int RawValue)
{
    public static readonly RefundPreference Undeclared = new(0);
    public static readonly RefundPreference Grant = new(1);
    public static readonly RefundPreference Decline = new(2);
    public static readonly RefundPreference NoPreference = new(3);
}
