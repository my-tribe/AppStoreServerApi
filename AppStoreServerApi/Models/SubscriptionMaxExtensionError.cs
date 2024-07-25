namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/subscriptionmaxextensionerror
public sealed class SubscriptionMaxExtensionError : Error
{
    internal SubscriptionMaxExtensionError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
