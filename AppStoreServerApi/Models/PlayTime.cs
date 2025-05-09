using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/playtime
[JsonConverter(typeof(RawInt32Converter<PlayTime>))]
public record PlayTime(int RawValue) : IRawInt32<PlayTime>
{
    public static readonly PlayTime Undeclared = new(0);
    public static readonly PlayTime UpTo5Minutes = new(1);
    public static readonly PlayTime UpTo60Minutes = new(2);
    public static readonly PlayTime UpTo6Hours = new(3);
    public static readonly PlayTime UpTo24Hours = new(4);
    public static readonly PlayTime UpTo4Days = new(5);
    public static readonly PlayTime UpTo16Days = new(6);
    public static readonly PlayTime Over16Days = new(7);

    static PlayTime IRawInt32<PlayTime>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<PlayTime>.IntoRaw() => RawValue;
}
