using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/platform
[JsonConverter(typeof(PlatformConverter))]
public record Platform(int RawValue)
{
    public static readonly Platform Undeclared = new(0);
    public static readonly Platform Apple = new(1);
    public static readonly Platform NonApple = new(2);
}
