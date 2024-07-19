using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/lifetimedollarsrefunded
[JsonConverter(typeof(LifetimeDollarsRefundedConverter))]
public record LifetimeDollarsRefunded(int RawValue)
{
    public static readonly LifetimeDollarsRefunded Undeclared = new(0);
    public static readonly LifetimeDollarsRefunded Zero = new(1);
    public static readonly LifetimeDollarsRefunded UpTo50 = new(2);
    public static readonly LifetimeDollarsRefunded UpTo100 = new(3);
    public static readonly LifetimeDollarsRefunded UpTo500 = new(4);
    public static readonly LifetimeDollarsRefunded UpTo1000 = new(5);
    public static readonly LifetimeDollarsRefunded UpTo2000 = new(6);
    public static readonly LifetimeDollarsRefunded Over2000 = new(7);
}
