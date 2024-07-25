namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidoriginaltransactioniderror
public sealed class InvalidOriginalTransactionIdError : Error
{
    internal InvalidOriginalTransactionIdError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
