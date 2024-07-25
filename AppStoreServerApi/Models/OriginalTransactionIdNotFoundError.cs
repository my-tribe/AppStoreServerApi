namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/originaltransactionidnotfounderror
public sealed class OriginalTransactionIdNotFoundError : Error
{
    internal OriginalTransactionIdNotFoundError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
