using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

using AppStoreServerApi.Models;
using JWT.Builder;
using JWT.Algorithms;
using System.Security.Cryptography;

namespace AppStoreServerApi;

public class AppStoreClient
{
    private static readonly string AppstoreAudience = "appstoreconnect-v1";
    private const long MaxTokenAge = 1800;

    private readonly AppleEnvironment _environment;
    private readonly string _privateKey;
    private readonly string _keyId;
    private readonly string _issuerId;
    private readonly string _bundleId;

    public AppStoreClient(AppleEnvironment environment, string privateKey, string keyId, string issuerId, string bundleId)
    {
        _environment = environment;
        _privateKey = privateKey.Replace("-----BEGIN PRIVATE KEY-----", string.Empty)
            .Replace("-----END PRIVATE KEY-----", string.Empty)
            .Replace(Environment.NewLine, string.Empty);
        _keyId = keyId;
        _issuerId = issuerId;
        _bundleId = bundleId;
    }

    // https://developer.apple.com/documentation/appstoreserverapi/get_transaction_info
    public async Task<TransactionInfoResponse> GetTransactionInfoAsync(string transactionId)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = _environment.BaseUrl;
        var jwt = MakeJWT();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        var requestUrl = $"inApps/v1/transactions/{transactionId}";

        var response = await httpClient.GetAsync(requestUrl);
        var responseBody = await response.Content.ReadAsStringAsync();

        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                return JsonSerializer.Deserialize<TransactionInfoResponse>(responseBody)!;
            case HttpStatusCode.Unauthorized:
                throw new Exception("The request is unauthorized; the JSON Web Token (JWT) is invalid.");
            default:
                var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(responseBody)!;
                throw new Error(errorResponse.ErrorCode, errorResponse.ErrorMessage);
        }
    }

    private string MakeJWT()
    {
        var now = DateTime.Now;
        var expiry = now.AddSeconds(MaxTokenAge);
        var privateKey = ECDsa.Create();
        privateKey.ImportPkcs8PrivateKey(Convert.FromBase64String(_privateKey), out var _);

        return JwtBuilder.Create()
            .WithAlgorithm(new ES256Algorithm(ECDsa.Create(), privateKey))
            .AddHeader(HeaderName.KeyId, _keyId)
            .IssuedAt(now)
            .ExpirationTime(expiry)
            .Issuer(_issuerId)
            .Audience(AppstoreAudience)
            .AddClaim("bid", _bundleId)
            .Encode()!;
    }
}
