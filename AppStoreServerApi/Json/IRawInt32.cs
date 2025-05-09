namespace AppStoreServerApi.Json;

public interface IRawInt32<TSelf> where TSelf : class
{
    static abstract TSelf FromRaw(int rawValue);
    int IntoRaw();
}
