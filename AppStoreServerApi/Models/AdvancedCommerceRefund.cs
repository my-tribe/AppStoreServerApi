using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommercerefund
public record AdvancedCommerceRefund(
    [property: JsonPropertyName("refundAmount")] long RefundAmount,
    [property: JsonPropertyName("refundDate"), JsonConverter(typeof(DateTimeConverter))] DateTime RefundDate,
    [property: JsonPropertyName("refundReason")] AdvancedCommerceRefundReason RefundReason,
    [property: JsonPropertyName("refundType")] AdvancedCommerceRefundType RefundType
);