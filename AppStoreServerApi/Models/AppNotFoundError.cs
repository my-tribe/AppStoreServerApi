namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/appnotfounderror
public sealed class AppNotFoundError : Error
{
    internal AppNotFoundError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
