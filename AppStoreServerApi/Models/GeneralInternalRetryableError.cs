namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/generalinternalretryableerror
public sealed class GeneralInternalRetryableError : Error
{
    internal GeneralInternalRetryableError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}