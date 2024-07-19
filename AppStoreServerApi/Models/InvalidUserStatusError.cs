namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invaliduserstatuserror
public sealed class InvalidUserStatusError : Error
{
    internal InvalidUserStatusError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
