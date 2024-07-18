using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/transactionreason
[JsonConverter(typeof(JsonStringEnumConverter<TransactionReason>))]
public enum TransactionReason
{
    PURCHASE,
    RENEWAL
}