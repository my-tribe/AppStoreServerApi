namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/startdateafterenddateerror
public sealed class StartDateAfterEndDateError : Error
{
    internal StartDateAfterEndDateError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
