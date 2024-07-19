namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidinappownershiptypeerror
public sealed class InvalidInAppOwnershipTypeError : Error
{
    internal InvalidInAppOwnershipTypeError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}
