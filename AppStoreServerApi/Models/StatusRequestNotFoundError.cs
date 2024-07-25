namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/statusrequestnotfounderror
public sealed class StatusRequestNotFoundError : Error
{
    internal StatusRequestNotFoundError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}