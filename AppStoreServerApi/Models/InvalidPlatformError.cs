namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidplatformerror
public sealed class InvalidPlatformError : Error
{
    internal InvalidPlatformError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
