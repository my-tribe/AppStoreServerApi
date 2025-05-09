namespace AppStoreServerApi.Json;

public interface IRawString<TSelf> where TSelf : class
{
    static abstract TSelf FromRaw(string rawValue);
    string IntoRaw();
}
