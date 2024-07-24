using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/orderlookupresponse
public record OrderLookupResponse(
    [property: JsonPropertyName("status")] OrderLookupStatus Status,
    [property: JsonPropertyName("signedTransactions")] ImmutableArray<JWSTransaction> SignedTransactions
);
