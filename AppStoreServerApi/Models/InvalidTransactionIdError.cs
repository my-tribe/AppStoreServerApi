namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidtransactioniderror
public sealed class InvalidTransactionIdError : Error
{
    internal InvalidTransactionIdError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}