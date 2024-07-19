namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidaccounttenureerror
public sealed class InvalidAccountTenureError : Error
{
    internal InvalidAccountTenureError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
