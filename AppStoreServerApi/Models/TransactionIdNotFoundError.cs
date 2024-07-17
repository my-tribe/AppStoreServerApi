namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/transactionidnotfounderror
public sealed class TransactionIdNotFoundError : Error
{
    internal TransactionIdNotFoundError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}