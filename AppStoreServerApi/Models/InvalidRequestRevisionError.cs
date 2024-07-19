namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidrequestrevisionerror
public sealed class InvalidRequestRevisionError : Error
{
    internal InvalidRequestRevisionError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}