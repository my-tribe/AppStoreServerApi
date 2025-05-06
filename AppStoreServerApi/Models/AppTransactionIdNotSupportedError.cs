namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/apptransactionidnotsupportederror
public sealed class AppTransactionIdNotSupportedError : Error
{
    internal AppTransactionIdNotSupportedError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}