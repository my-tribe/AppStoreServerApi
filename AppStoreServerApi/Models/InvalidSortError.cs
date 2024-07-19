namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidsorterror
public sealed class InvalidSortError : Error
{
    internal InvalidSortError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
