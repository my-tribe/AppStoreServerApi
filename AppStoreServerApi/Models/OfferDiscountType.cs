using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/offerdiscounttype
[JsonConverter(typeof(JsonStringEnumConverter<OfferDiscountType>))]
public enum OfferDiscountType
{
    FREE_TRIAL,
    PAY_AS_YOU_GO,
    PAY_UP_FRONT
}