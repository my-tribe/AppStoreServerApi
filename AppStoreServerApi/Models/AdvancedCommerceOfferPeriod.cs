using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommerceofferperiod
[JsonConverter(typeof(RawStringConverter<AdvancedCommerceOfferPeriod>))]
public record AdvancedCommerceOfferPeriod(string RawValue) : IRawString<AdvancedCommerceOfferPeriod>
{
    public static readonly AdvancedCommerceOfferPeriod P3D = new("P3D");
    public static readonly AdvancedCommerceOfferPeriod P1W = new("P1W");
    public static readonly AdvancedCommerceOfferPeriod P2W = new("P2W");
    public static readonly AdvancedCommerceOfferPeriod P1M = new("P1M");
    public static readonly AdvancedCommerceOfferPeriod P2M = new("P2M");
    public static readonly AdvancedCommerceOfferPeriod P3M = new("P3M");
    public static readonly AdvancedCommerceOfferPeriod P6M = new("P6M");
    public static readonly AdvancedCommerceOfferPeriod P9M = new("P9M");
    public static readonly AdvancedCommerceOfferPeriod P1Y = new("P1Y");

    static AdvancedCommerceOfferPeriod IRawString<AdvancedCommerceOfferPeriod>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<AdvancedCommerceOfferPeriod>.IntoRaw() => RawValue;
}