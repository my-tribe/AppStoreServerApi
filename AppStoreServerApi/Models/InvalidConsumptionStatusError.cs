namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidconsumptionstatuserror
public sealed class InvalidConsumptionStatusError : Error
{
    internal InvalidConsumptionStatusError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
