namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidnotificationtypeerror
public sealed class InvalidNotificationTypeError : Error
{
    internal InvalidNotificationTypeError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
