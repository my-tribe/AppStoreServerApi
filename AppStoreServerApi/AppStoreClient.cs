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
    private readonly IJwtProvider _jwtProvider;

    public AppStoreClient(AppleEnvironment environment, string privateKey, string keyId, string issuerId, string bundleId)
        : this(NullLogger<AppStoreClient>.Instance, DeafultHttpClientFactory.Instance, environment,
            new AppStoreClientJwtProvider(privateKey, keyId, issuerId, bundleId))
    {
    }

    public AppStoreClient(ILogger<AppStoreClient> logger,
        HttpClientFactory httpClientFactory,
        AppleEnvironment environment,
        IJwtProvider jwtProvider)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _environment = environment;
        _jwtProvider = jwtProvider;
    }

    // https://developer.apple.com/documentation/appstoreserverapi/get_transaction_history
    public async Task<HistoryResponse> GetTransactionHistoryAsync(string transactionId,
        string? revision = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? productId = null,
        IReadOnlyCollection<ProductType>? productType = null,
        InAppOwnershipType? inAppOwnershipType = null,
        SortOrder? sort = null,
        bool? revoked = null,
        IReadOnlyCollection<string>? subscriptionGroupIdentifier = null,
        CancellationToken ct = default)
    {
        if (startDate is not null && endDate is not null && endDate < startDate) throw new ArgumentException(null, nameof(endDate));

        using var httpClient = MakeHttpClient();

        var startDateMs = startDate?.ToUnixTimeMilliseconds();
        var endDateMs = endDate?.ToUnixTimeMilliseconds();

        var query = new List<string>();
        if (revision is not null) query.Add($"revision={revision}");
        if (startDate is not null) query.Add($"startDate={startDateMs}");
        if (endDate is not null) query.Add($"endDate={endDateMs}");
        if (productId is not null) query.Add($"productId={productId}");
        if (productType is not null) query.AddRange(productType.Select(x => $"productType={x}"));
        if (inAppOwnershipType is not null) query.Add($"inAppOwnershipType={inAppOwnershipType.Value}");
        if (sort is not null) query.Add($"sort={sort.Value}");
        if (revoked is not null) query.Add($"revoked={revoked.Value.ToString().ToLower()}");
        if (subscriptionGroupIdentifier is not null) query.AddRange(subscriptionGroupIdentifier.Select(x => $"subscriptionGroupIdentifier={x}"));
        var queryStr = string.Join("&", query);

        var requestUrl = queryStr switch {
            "" => $"inApps/v2/history/{transactionId}",
            _ => $"inApps/v2/history/{transactionId}?{queryStr}"
        };

        Console.WriteLine(requestUrl);

        using var responseMessage = await httpClient.GetAsync(requestUrl, ct);
        return await GetResultAsync<HistoryResponse>(responseMessage, ct);
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
        var jwt = _jwtProvider.GetJwt();
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
                _jwtProvider.ResetJwt();
                throw new UnauthorizedException();
            default:
                var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(responseContent)!;
                throw errorResponse.MakeTypedError();
        }
    }
}
