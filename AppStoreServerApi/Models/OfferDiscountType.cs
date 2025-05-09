using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/offerdiscounttype
[JsonConverter(typeof(RawStringConverter<OfferDiscountType>))]
public record OfferDiscountType(string RawValue) : IRawString<OfferDiscountType>
{
    public static readonly OfferDiscountType FreeTrial = new("FREE_TRIAL");
    public static readonly OfferDiscountType PayAsYouGo = new("PAY_AS_YOU_GO");
    public static readonly OfferDiscountType PayUpFront = new("PAY_UP_FRONT");

    static OfferDiscountType IRawString<OfferDiscountType>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<OfferDiscountType>.IntoRaw() => RawValue;
}