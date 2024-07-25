namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/familysharedsubscriptionextensionineligibleerror
public sealed class FamilySharedSubscriptionExtensionIneligibleError : Error
{
    internal FamilySharedSubscriptionExtensionIneligibleError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
