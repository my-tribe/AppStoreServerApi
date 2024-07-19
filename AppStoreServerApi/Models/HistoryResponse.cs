using System.Text.Json.Serialization;
using System.Collections.Immutable;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/historyresponse
public record HistoryResponse(
    [property: JsonPropertyName("appAppleId")] long AppAppleId,
    [property: JsonPropertyName("bundleId")] string BundleId,
    [property: JsonPropertyName("environment")] Environment Environment,
    [property: JsonPropertyName("hasMore")] bool HasMore,
    [property: JsonPropertyName("revision")] string Revision,
    [property: JsonPropertyName("signedTransactions")] ImmutableArray<JWSTransaction> SignedTransactions
);