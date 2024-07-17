namespace AppStoreServerApi;

public static class DeafultHttpClientFactory
{
    public static readonly HttpClientFactory Instance = () => new HttpClient();
}