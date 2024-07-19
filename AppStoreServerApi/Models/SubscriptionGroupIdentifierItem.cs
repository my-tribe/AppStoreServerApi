using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/subscriptiongroupidentifieritem
public record SubscriptionGroupIdentifierItem(
    [property: JsonPropertyName("subscriptionGroupIdentifier")] string SubscriptionGroupIdentifier,
    [property: JsonPropertyName("lastTransactions")] ImmutableArray<LastTransactionsItem> LastTransactions
);