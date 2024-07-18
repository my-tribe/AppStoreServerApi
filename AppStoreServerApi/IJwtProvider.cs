namespace AppStoreServerApi;

public interface IJwtProvider
{
    string GetJwt();
    void ResetJwt();
}