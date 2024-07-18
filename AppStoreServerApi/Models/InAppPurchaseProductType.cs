using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/type
[JsonConverter(typeof(InAppPurchaseProductTypeConverter))]
public record InAppPurchaseProductType(string RawValue)
{
    public static readonly InAppPurchaseProductType AutoRenewableSubscription = new ("Auto-Renewable Subscription");
    public static readonly InAppPurchaseProductType NonConsumable = new ("Non-Consumable");
    public static readonly InAppPurchaseProductType Consumable = new ("Consumable");
    public static readonly InAppPurchaseProductType NonRenewingSubscription = new ("Non-Renewing Subscription");
}