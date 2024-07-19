namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/appnotfoundretryableerror
public sealed class AppNotFoundRetryableError : Error
{
    internal AppNotFoundRetryableError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
