using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/jwstransactiondecodedpayload
public record JWSTransactionDecodedPayload(
    [property: JsonPropertyName("appAccountToken")] string? AppAccountToken,
    [property: JsonPropertyName("bundleId")] string? BundleId,
    [property: JsonPropertyName("currency")] string? Currency,
    [property: JsonPropertyName("environment")] string? Environment,
    [property: JsonPropertyName("expiresDate"), JsonConverter(typeof(Json.DateTimeConverter))] DateTime? ExpiresDate,
    [property: JsonPropertyName("inAppOwnershipType")] string? InAppOwnershipType,
    [property: JsonPropertyName("isUpgraded")] bool? IsUpgraded,
    [property: JsonPropertyName("offerDiscountType")] string? OfferDiscountType,
    [property: JsonPropertyName("offerIdentifier")] string? OfferIdentifier,
    [property: JsonPropertyName("offerType")] int? OfferType,
    [property: JsonPropertyName("originalPurchaseDate"), JsonConverter(typeof(Json.DateTimeConverter))] DateTime OriginalPurchaseDate,
    [property: JsonPropertyName("originalTransactionId")] string? OriginalTransactionId,
    [property: JsonPropertyName("price")] long Price,
    [property: JsonPropertyName("productId")] string? ProductId,
    [property: JsonPropertyName("purchaseDate"), JsonConverter(typeof(Json.DateTimeConverter))] DateTime PurchaseDate,
    [property: JsonPropertyName("quantity")] int Quantity,
    [property: JsonPropertyName("revocationDate"), JsonConverter(typeof(Json.DateTimeConverter))] DateTime? RevocationDate,
    [property: JsonPropertyName("revocationReason")] int RevocationReason,
    [property: JsonPropertyName("signedDate"), JsonConverter(typeof(Json.DateTimeConverter))] DateTime SignedDate,
    [property: JsonPropertyName("storefront")] string? Storefront,
    [property: JsonPropertyName("storefrontId")] string? StorefrontId,
    [property: JsonPropertyName("subscriptionGroupIdentifier")] string? SubscriptionGroupIdentifier,
    [property: JsonPropertyName("transactionId")] string? TransactionId,
    [property: JsonPropertyName("transactionReason")] string? TransactionReason,
    [property: JsonPropertyName("type")] string? Type,
    [property: JsonPropertyName("webOrderLineItemId")] string? WebOrderLineItemId
);