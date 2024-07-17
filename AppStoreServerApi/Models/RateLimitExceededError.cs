namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/ratelimitexceedederror
public sealed class RateLimitExceededError : Error
{
    internal RateLimitExceededError(long errorCode, string errorMessage) : base(errorCode, errorMessage)
    {
    }
}