using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/lasttransactionsitem
public record LastTransactionsItem(
    [property: JsonPropertyName("originalTransactionId")] string OriginalTransactionId,
    [property: JsonPropertyName("status")] Status Status,
    [property: JsonPropertyName("signedRenewalInfo")] JWSRenewalInfo SignedRenewalInfo,
    [property: JsonPropertyName("signedTransactionInfo")] JWSTransaction SignedTransactionInfo
);
