namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidtransactiontypenotsupportederror
public sealed class InvalidTransactionTypeNotSupportedError : Error
{
    internal InvalidTransactionTypeNotSupportedError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}