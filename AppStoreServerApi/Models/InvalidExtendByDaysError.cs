namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidextendbydayserror
public sealed class InvalidExtendByDaysError : Error
{
    internal InvalidExtendByDaysError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
