namespace AppStoreServerApi;

public sealed class AppleEnvironment
{
    public static readonly AppleEnvironment Production = new(nameof(Production), new("https://api.storekit.itunes.apple.com"));
    public static readonly AppleEnvironment Sandbox = new(nameof(Sandbox), new("https://api.storekit-sandbox.itunes.apple.com"));

    public readonly string Name;
    public readonly Uri BaseUrl;

    private AppleEnvironment(string name, Uri baseUrl)
    {
        Name = name;
        BaseUrl = baseUrl;
    }
}