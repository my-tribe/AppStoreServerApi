namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidenddateerror
public sealed class InvalidEndDateError : Error
{
    internal InvalidEndDateError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}