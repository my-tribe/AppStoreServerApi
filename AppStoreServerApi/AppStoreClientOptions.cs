namespace AppStoreServerApi;

public sealed class AppStoreClientOptions(HttpClientFactory httpClientFactory)
{
    public readonly HttpClientFactory HttpClientFactory = httpClientFactory;
    public AppleEnvironment Environment { get; set; } = AppleEnvironment.Sandbox;
    public string PrivateKey { get; set; } = "invalid";
    public string KeyId { get; set; } = "invalid";
    public string IssuerId { get; set; } = "invalid";
    public string BundleId { get; set; } = "invalid";
}