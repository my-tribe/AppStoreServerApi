namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/accountnotfoundretryableerror
public sealed class AccountNotFoundRetryableError : Error
{
    internal AccountNotFoundRetryableError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
