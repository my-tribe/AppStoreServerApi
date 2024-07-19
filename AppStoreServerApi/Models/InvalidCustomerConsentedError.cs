namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidcustomerconsentederror
public sealed class InvalidCustomerConsentedError : Error
{
    internal InvalidCustomerConsentedError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
