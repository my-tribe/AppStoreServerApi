namespace AppStoreServerApi;

internal static class DateTimeExtensions
{
    public static long ToUnixTimeMilliseconds(this DateTime value) => (long) (value - DateTime.UnixEpoch).TotalMilliseconds;
}