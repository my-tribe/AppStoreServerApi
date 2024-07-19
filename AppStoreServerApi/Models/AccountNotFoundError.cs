namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/accountnotfounderror
public sealed class AccountNotFoundError : Error
{
    internal AccountNotFoundError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
