using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/platform
[JsonConverter(typeof(RawInt32Converter<Platform>))]
public record Platform(int RawValue) : IRawInt32<Platform>
{
    public static readonly Platform Undeclared = new(0);
    public static readonly Platform Apple = new(1);
    public static readonly Platform NonApple = new(2);

    static Platform IRawInt32<Platform>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<Platform>.IntoRaw() => RawValue;
}
