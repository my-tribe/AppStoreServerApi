namespace AppStoreServerApi.Json;

public interface IRawInt64<TSelf> where TSelf : class
{
    static abstract TSelf FromRaw(long rawValue);
    long IntoRaw();
}
