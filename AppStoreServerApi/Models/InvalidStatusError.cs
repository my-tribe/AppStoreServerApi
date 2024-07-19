namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidstatuserror
public sealed class InvalidStatusError : Error
{
    internal InvalidStatusError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}