namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidrevokederror
public sealed class InvalidRevokedError : Error
{
    internal InvalidRevokedError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
