using System.Security.Cryptography;

using JWT.Algorithms;
using JWT.Builder;

namespace AppStoreServerApi;

public sealed class AppStoreClientJwtProvider(
    string privateKey,
    string keyId,
    string issuerId,
    string bundleId) : IJwtProvider
{
    private static readonly string AppstoreAudience = "appstoreconnect-v1";
    private const long MaxTokenAge = 1800;

    private readonly object _guard = new();
    
    private string _lastJwt = string.Empty;
    private DateTime _lastJwtExpireTime;

    private readonly string _privateKey = privateKey
        .Replace("-----BEGIN PRIVATE KEY-----", string.Empty)
        .Replace("-----END PRIVATE KEY-----", string.Empty)
        .Replace(Environment.NewLine, string.Empty);
    private readonly string _keyId = keyId;
    private readonly string _issuerId = issuerId;
    private readonly string _bundleId = bundleId;

    public string GetJwt()
    {
        var now = DateTime.Now;
        lock (_guard)
        {
            if (!string.IsNullOrEmpty(_lastJwt) && now < _lastJwtExpireTime)
            {
                return _lastJwt;
            }
        }

        var expiry = now.AddSeconds(MaxTokenAge);
        var privateKey = ECDsa.Create();
        privateKey.ImportPkcs8PrivateKey(Convert.FromBase64String(_privateKey), out var _);

        var newJwt = JwtBuilder.Create()
            .WithAlgorithm(new ES256Algorithm(ECDsa.Create(), privateKey))
            .AddHeader(HeaderName.KeyId, _keyId)
            .IssuedAt(now)
            .ExpirationTime(expiry)
            .Issuer(_issuerId)
            .Audience(AppstoreAudience)
            .AddClaim("bid", _bundleId)
            .Encode()!;

        lock (_guard)
        {
            _lastJwt = newJwt;
            _lastJwtExpireTime = expiry;
        }
        return newJwt;
    }

    public void ResetJwt()
    {
        lock (_guard)
        {
            _lastJwt = string.Empty;
        }
    }
}