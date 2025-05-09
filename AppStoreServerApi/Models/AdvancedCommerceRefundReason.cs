using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommercerefundreason
[JsonConverter(typeof(RawStringConverter<AdvancedCommerceRefundReason>))]
public record AdvancedCommerceRefundReason(string RawValue) : IRawString<AdvancedCommerceRefundReason>
{
    public static readonly AdvancedCommerceRefundReason ModifyItemsRefund = new("MODIFY_ITEMS_REFUND");

    static AdvancedCommerceRefundReason IRawString<AdvancedCommerceRefundReason>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<AdvancedCommerceRefundReason>.IntoRaw() => RawValue;
}