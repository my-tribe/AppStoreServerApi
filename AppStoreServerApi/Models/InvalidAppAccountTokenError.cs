namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidappaccounttokenerror
public sealed class InvalidAppAccountTokenError : Error
{
    internal InvalidAppAccountTokenError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
