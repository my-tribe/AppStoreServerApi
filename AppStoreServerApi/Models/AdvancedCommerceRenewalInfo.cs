using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommercerenewalinfo
public record AdvancedCommerceRenewalInfo(
    [property: JsonPropertyName("consistencyToken")] string ConsistencyToken,
    [property: JsonPropertyName("descriptors")] AdvancedCommerceDescriptors Descriptors,
    [property: JsonPropertyName("items")] ImmutableArray<AdvancedCommerceRenewalItem> Items,
    [property: JsonPropertyName("period")] AdvancedCommercePeriod Period,
    [property: JsonPropertyName("requestReferenceId")] string RequestReferenceId,
    [property: JsonPropertyName("taxCode")] string TaxCode
);