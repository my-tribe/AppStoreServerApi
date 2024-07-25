namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/paginationtokenexpirederror
public sealed class PaginationTokenExpiredError : Error
{
    internal PaginationTokenExpiredError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
