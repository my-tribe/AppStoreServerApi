namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidlifetimedollarsrefundederror
public sealed class InvalidLifetimeDollarsRefundedError : Error
{
    internal InvalidLifetimeDollarsRefundedError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
