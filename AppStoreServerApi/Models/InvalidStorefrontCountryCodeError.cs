namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidstorefrontcountrycodeerror
public sealed class InvalidStorefrontCountryCodeError : Error
{
    internal InvalidStorefrontCountryCodeError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
