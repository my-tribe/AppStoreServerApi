using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommerceperiod
[JsonConverter(typeof(RawStringConverter<AdvancedCommercePeriod>))]
public record AdvancedCommercePeriod(string RawValue) : IRawString<AdvancedCommercePeriod>
{
    public static readonly AdvancedCommercePeriod P1W = new("P1W");
    public static readonly AdvancedCommercePeriod P1M = new("P1M");
    public static readonly AdvancedCommercePeriod P2M = new("P2M");
    public static readonly AdvancedCommercePeriod P3M = new("P3M");
    public static readonly AdvancedCommercePeriod P6M = new("P6M");
    public static readonly AdvancedCommercePeriod P1Y = new("P1Y");

    static AdvancedCommercePeriod IRawString<AdvancedCommercePeriod>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<AdvancedCommercePeriod>.IntoRaw() => RawValue;
}