namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/subscriptionextensionineligibleerror
public sealed class SubscriptionExtensionIneligibleError : Error
{
    internal SubscriptionExtensionIneligibleError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
