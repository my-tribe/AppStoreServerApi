namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidpaginationtokenerror
public sealed class InvalidPaginationTokenError : Error
{
    internal InvalidPaginationTokenError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
