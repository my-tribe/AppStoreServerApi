namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidproducttypeerror
public sealed class InvalidProductTypeError : Error
{
    internal InvalidProductTypeError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
