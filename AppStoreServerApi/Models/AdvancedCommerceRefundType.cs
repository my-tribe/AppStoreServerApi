using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommercerefundtype
[JsonConverter(typeof(RawStringConverter<AdvancedCommerceRefundType>))]
public record AdvancedCommerceRefundType(string RawValue) : IRawString<AdvancedCommerceRefundType>
{
    public static readonly AdvancedCommerceRefundType Prorated = new("PRORATED");

    static AdvancedCommerceRefundType IRawString<AdvancedCommerceRefundType>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<AdvancedCommerceRefundType>.IntoRaw() => RawValue;
}