namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidplaytimeerror
public sealed class InvalidPlayTimeError : Error
{
    internal InvalidPlayTimeError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
