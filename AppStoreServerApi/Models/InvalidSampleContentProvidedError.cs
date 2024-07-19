namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/invalidsamplecontentprovidederror
public sealed class InvalidSampleContentProvidedError : Error
{
    internal InvalidSampleContentProvidedError(long errorCode, string errorMessage) : base (errorCode, errorMessage)
    {
    }
}
