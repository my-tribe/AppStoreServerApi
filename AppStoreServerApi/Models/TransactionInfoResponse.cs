using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

public record TransactionInfoResponse(
    [property: JsonPropertyName("signedTransactionInfo")] JWSTransaction SignedTransactionInfo
);