namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidrefundpreferenceerror
public sealed class InvalidRefundPreferenceError : Error
{
    internal InvalidRefundPreferenceError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
