namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/generalbadrequesterror
public sealed class GeneralBadRequestError : Error
{
    internal GeneralBadRequestError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}