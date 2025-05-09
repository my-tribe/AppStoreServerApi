using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/lifetimedollarspurchased
[JsonConverter(typeof(RawInt32Converter<LifetimeDollarsPurchased>))]
public record LifetimeDollarsPurchased(int RawValue) : IRawInt32<LifetimeDollarsPurchased>
{
    public static readonly LifetimeDollarsPurchased Undeclared = new(0);
    public static readonly LifetimeDollarsPurchased Zero = new(1);
    public static readonly LifetimeDollarsPurchased UpTo50 = new(2);
    public static readonly LifetimeDollarsPurchased UpTo100 = new(3);
    public static readonly LifetimeDollarsPurchased UpTo500 = new(4);
    public static readonly LifetimeDollarsPurchased UpTo1000 = new(5);
    public static readonly LifetimeDollarsPurchased UpTo2000 = new(6);
    public static readonly LifetimeDollarsPurchased Over2000 = new(7);

    static LifetimeDollarsPurchased IRawInt32<LifetimeDollarsPurchased>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<LifetimeDollarsPurchased>.IntoRaw() => RawValue;
}
