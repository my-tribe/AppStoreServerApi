namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/startdatetoofarinpasterror
public sealed class StartDateTooFarInPastError : Error
{
    internal StartDateTooFarInPastError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
