using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

public record TransactionInfoResponse(
    [property: JsonPropertyName("signedTransactionInfo"), JsonConverter(typeof(JWSTransactionConverter))]
    JWSTransaction SignedTransactionInfo
);