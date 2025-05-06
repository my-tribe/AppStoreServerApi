using System.Collections.Immutable;
using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/jwsrenewalinfodecodedpayload
public record JWSRenewalInfoDecodedPayload(
    [property: JsonPropertyName("appAccountToken")] string? AppAccountToken,
    [property: JsonPropertyName("autoRenewProductId")] string AutoRenewProductId,
    [property: JsonPropertyName("autoRenewStatus")] AutoRenewStatus AutoRenewStatus,
    [property: JsonPropertyName("currency")] string Currency,
    [property: JsonPropertyName("eligibleWinBackOfferIds")] ImmutableArray<string> EligibleWinBackOfferIds,
    [property: JsonPropertyName("environment")] Environment Environment,
    [property: JsonPropertyName("expirationIntent")] ExpirationIntent ExpirationIntent,
    [property: JsonPropertyName("gracePeriodExpiresDate"), JsonConverter(typeof(DateTimeConverter))] DateTime? GracePeriodExpiresDate,
    [property: JsonPropertyName("isInBillingRetryPeriod")] bool IsInBillingRetryPeriod,
    [property: JsonPropertyName("offerDiscountType")] OfferDiscountType OfferDiscountType,
    [property: JsonPropertyName("offerIdentifier")] string? OfferIdentifier,
    [property: JsonPropertyName("offerType")] OfferType OfferType,
    [property: JsonPropertyName("originalTransactionId")] string OriginalTransactionId,
    [property: JsonPropertyName("priceIncreaseStatus")] PriceIncreaseStatus? PriceIncreaseStatus,
    [property: JsonPropertyName("productId")] string ProductId,
    [property: JsonPropertyName("recentSubscriptionStartDate"), JsonConverter(typeof(DateTimeConverter))] DateTime RecentSubscriptionStartDate,
    [property: JsonPropertyName("renewalDate"), JsonConverter(typeof(DateTimeConverter))] DateTime RenewalDate,
    [property: JsonPropertyName("renewalPrice")] long RenewalPrice,
    [property: JsonPropertyName("signedDate"), JsonConverter(typeof(DateTimeConverter))] DateTime SignedDate
);