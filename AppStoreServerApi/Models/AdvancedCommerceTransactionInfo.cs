using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommercetransactioninfo
public record AdvancedCommerceTransactionInfo(
    [property: JsonPropertyName("descriptors")] AdvancedCommerceDescriptors Descriptors,
    [property: JsonPropertyName("estimatedTax")] long EstimatedTax,
    [property: JsonPropertyName("items")] ImmutableArray<AdvancedCommerceTransactionItem> Items,
    [property: JsonPropertyName("period")] AdvancedCommercePeriod Period,
    [property: JsonPropertyName("requestReferenceId")] string RequestReferenceId,
    [property: JsonPropertyName("taxCode")] string TaxCode,
    [property: JsonPropertyName("taxExclusivePrice")] long TaxExclusivePrice,
    [property: JsonPropertyName("taxRate")] string TaxRate
);