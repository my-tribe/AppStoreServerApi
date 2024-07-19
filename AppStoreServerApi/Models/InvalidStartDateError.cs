namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidstartdateerror
public sealed class InvalidStartDateError : Error
{
    internal InvalidStartDateError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}