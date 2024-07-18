using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/offertype
[JsonConverter(typeof(OfferTypeConverter))]
public record OfferType(int RawValue)
{
    public static readonly OfferType IntroductoryOffer = new(1);
    public static readonly OfferType PromotionalOffer = new(2);
    public static readonly OfferType OfferWithSubscriptionOfferCode = new(3);
    public static readonly OfferType WinBackOffer = new(4);
}