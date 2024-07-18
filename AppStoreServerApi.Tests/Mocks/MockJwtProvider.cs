namespace AppStoreServerApi.Tests.Mocks;

internal sealed class MockJwtProvider : IJwtProvider
{
    public string GetJwt()
    {
        return "fooJWT";
    }

    public void ResetJwt()
    {
    }
}