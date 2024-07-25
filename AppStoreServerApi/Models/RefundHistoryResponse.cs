using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/refundhistoryresponse
public record RefundHistoryResponse(
    [property: JsonPropertyName("hasMore")] bool HasMore,
    [property: JsonPropertyName("revision")] string Revision,
    [property: JsonPropertyName("signedTransactions")] ImmutableArray<JWSTransaction> SignedTransactions
);