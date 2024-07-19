namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidlifetimedollarspurchasederror
public sealed class InvalidLifetimeDollarsPurchasedError : Error
{
    internal InvalidLifetimeDollarsPurchasedError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
