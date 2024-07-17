namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/generalinternalerror
public sealed class GeneralInternalError : Error
{
    internal GeneralInternalError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}