using System.Collections.Immutable;
using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommercetransactionitem
public record AdvancedCommerceTransactionItem(
    [property: JsonPropertyName("SKU")] string SKU,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("displayName")] string DisplayName,
    [property: JsonPropertyName("offer")] AdvancedCommerceOffer Offer,
    [property: JsonPropertyName("price")] long Price,
    [property: JsonPropertyName("refunds")] ImmutableArray<AdvancedCommerceRefund> Refunds,
    [property: JsonPropertyName("revocationDate"), JsonConverter(typeof(DateTimeConverter))] DateTime RevocationDate
);