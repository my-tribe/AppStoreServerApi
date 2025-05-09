using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/type
[JsonConverter(typeof(RawStringConverter<InAppPurchaseProductType>))]
public record InAppPurchaseProductType(string RawValue) : IRawString<InAppPurchaseProductType>
{
    public static readonly InAppPurchaseProductType AutoRenewableSubscription = new ("Auto-Renewable Subscription");
    public static readonly InAppPurchaseProductType NonConsumable = new ("Non-Consumable");
    public static readonly InAppPurchaseProductType Consumable = new ("Consumable");
    public static readonly InAppPurchaseProductType NonRenewingSubscription = new ("Non-Renewing Subscription");

    static InAppPurchaseProductType IRawString<InAppPurchaseProductType>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<InAppPurchaseProductType>.IntoRaw() => RawValue;
}