namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invaliddeliverystatuserror
public sealed class InvalidDeliveryStatusError : Error
{
    internal InvalidDeliveryStatusError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
