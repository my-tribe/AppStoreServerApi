namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/status
public record Status(int RawValue)
{
    public readonly Status Active = new(1);
    public readonly Status Expired = new(2);
    public readonly Status BillingRetry = new(3);
    public readonly Status BillingGrace = new(4);
    public readonly Status Revoked = new(5);
}