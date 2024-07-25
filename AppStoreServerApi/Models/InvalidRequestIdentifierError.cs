namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidrequestidentifiererror
public sealed class InvalidRequestIdentifierError : Error
{
    internal InvalidRequestIdentifierError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
