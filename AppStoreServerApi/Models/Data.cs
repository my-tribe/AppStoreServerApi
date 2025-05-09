using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/data
public record Data(
    [property: JsonPropertyName("appAppleId")] long AppAppleId,
    [property: JsonPropertyName("bundleId")] string BundleId,
    [property: JsonPropertyName("bundleVersion")] string BundleVersion,
    [property: JsonPropertyName("consumptionRequestReason")] ConsumptionRequestReason? ConsumptionRequestReason,
    [property: JsonPropertyName("environment")] Environment Environment,
    [property: JsonPropertyName("signedRenewalInfo")] JWSRenewalInfo? SignedRenewalInfo,
    [property: JsonPropertyName("signedTransactionInfo")] JWSTransaction SignedTransactionInfo,
    [property: JsonPropertyName("status")] Status? Status
);