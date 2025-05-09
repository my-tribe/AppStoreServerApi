using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/transactionreason
[JsonConverter(typeof(RawStringConverter<TransactionReason>))]
public record TransactionReason(string RawValue) : IRawString<TransactionReason>
{
    public static readonly TransactionReason Purchase = new("PURCHASE");
    public static readonly TransactionReason Renewal = new("RENEWAL");

    static TransactionReason IRawString<TransactionReason>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<TransactionReason>.IntoRaw() => RawValue;
}