using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommercereason
[JsonConverter(typeof(RawStringConverter<AdvancedCommerceReason>))]
public record AdvancedCommerceReason(string RawValue) : IRawString<AdvancedCommerceReason>
{
    public static readonly AdvancedCommerceReason Acquisition = new("ACQUISITION");
    public static readonly AdvancedCommerceReason WinBack = new("WIN_BACK");
    public static readonly AdvancedCommerceReason Retention = new("RETENTION");

    static AdvancedCommerceReason IRawString<AdvancedCommerceReason>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<AdvancedCommerceReason>.IntoRaw() => RawValue;
}