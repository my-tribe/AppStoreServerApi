namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidappidentifiererror
public sealed class InvalidAppIdentifierError : Error
{
    internal InvalidAppIdentifierError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}