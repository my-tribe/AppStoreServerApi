namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/multiplefilterssuppliederror
public sealed class MultipleFiltersSuppliedError : Error
{
    internal MultipleFiltersSuppliedError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}