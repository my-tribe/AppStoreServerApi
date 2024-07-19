namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidsubscriptiongroupidentifiererror
public sealed class InvalidSubscriptionGroupIdentifierError : Error
{
    internal InvalidSubscriptionGroupIdentifierError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
