using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/statusresponse
public record StatusResponse(
    [property: JsonPropertyName("data")] ImmutableArray<SubscriptionGroupIdentifierItem> Data,
    [property: JsonPropertyName("environment")] Environment Environment,
    [property: JsonPropertyName("appAppleId")] long AppAppleId,
    [property: JsonPropertyName("bundleId")] string BundleId
);