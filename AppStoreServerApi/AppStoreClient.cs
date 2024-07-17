using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

using Microsoft.Extensions.Logging;

using AppStoreServerApi.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace AppStoreServerApi;

public class AppStoreClient : IAppStoreClient
{
    private readonly ILogger _logger;
    private readonly HttpClientFactory _httpClientFactory;
    private readonly AppleEnvironment _environment;

    private readonly AppStoreClientJwtFactory _jwtFactory;

    public AppStoreClient(AppleEnvironment environment, string privateKey, string keyId, string issuerId, string bundleId)
        : this(NullLogger<AppStoreClient>.Instance, DeafultHttpClientFactory.Instance, environment, privateKey, keyId, issuerId, bundleId)
    {
    }

    public AppStoreClient(ILogger<AppStoreClient> logger,
        HttpClientFactory httpClientFactory,
        AppleEnvironment environment,
        string privateKey,
        string keyId,
        string issuerId,
        string bundleId)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _environment = environment;

        _jwtFactory = new(privateKey, keyId, issuerId, bundleId);
    }

    // https://developer.apple.com/documentation/appstoreserverapi/get_transaction_info
    public async Task<TransactionInfoResponse> GetTransactionInfoAsync(string transactionId, CancellationToken ct = default)
    {
        using var httpClient = MakeHttpClient();

        var requestUrl = $"inApps/v1/transactions/{transactionId}";

        using var responseMessage = await httpClient.GetAsync(requestUrl, ct);
        return await GetResultAsync<TransactionInfoResponse>(responseMessage, ct);
    }

    private HttpClient MakeHttpClient()
    {
        var jwt = _jwtFactory.GetJwt();
        var httpClient = _httpClientFactory();
        httpClient.BaseAddress = _environment.BaseUrl;
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        return httpClient;
    }

    private async Task<T> GetResultAsync<T>(HttpResponseMessage responseMessage, CancellationToken ct)
    {
        var responseContent = await responseMessage.Content.ReadAsStringAsync(ct);
        switch (responseMessage.StatusCode)
        {
            case HttpStatusCode.OK:
                return JsonSerializer.Deserialize<T>(responseContent)!;
            case HttpStatusCode.Unauthorized:
                _jwtFactory.ClearJwt();
                throw new UnauthorizedException();
            default:
                var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(responseContent)!;
                throw errorResponse.MakeTypedError();
        }
    }
}
