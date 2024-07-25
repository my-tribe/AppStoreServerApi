namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidextendreasoncodeerror
public sealed class InvalidExtendReasonCodeError : Error
{
    internal InvalidExtendReasonCodeError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
