namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidemptystorefrontcountrycodelisterror
public sealed class InvalidEmptyStorefrontCountryCodeListError : Error
{
    internal InvalidEmptyStorefrontCountryCodeListError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
