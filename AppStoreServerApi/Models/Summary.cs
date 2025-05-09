using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/summary
public record Summary(
    [property: JsonPropertyName("requestIdentifier")] string RequestIdentifier,
    [property: JsonPropertyName("environment")] Environment Environment,
    [property: JsonPropertyName("appAppleId")] long AppAppleId,
    [property: JsonPropertyName("bundleId")] string BundleId,
    [property: JsonPropertyName("productId")] string ProductId,
    [property: JsonPropertyName("storefrontCountryCodes"), JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingDefault)] ImmutableArray<string>? StorefrontCountryCodes,
    [property: JsonPropertyName("failedCount")] long FailedCount,
    [property: JsonPropertyName("succeededCount")] long SucceededCount
);