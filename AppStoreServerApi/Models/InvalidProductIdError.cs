namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidproductiderror
public sealed class InvalidProductIdError : Error
{
    internal InvalidProductIdError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
