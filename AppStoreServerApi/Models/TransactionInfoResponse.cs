using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/transactioninforesponse
public record TransactionInfoResponse(
    [property: JsonPropertyName("signedTransactionInfo")] JWSTransaction SignedTransactionInfo
);