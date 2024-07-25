using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/massextendrenewaldaterequest
public record MassExtendRenewalDateRequest(
    [property: JsonPropertyName("requestIdentifier")] string RequestIdentifier,
    [property: JsonPropertyName("extendByDays")] int ExtendByDays,
    [property: JsonPropertyName("extendReasonCode")] ExtendReasonCode ExtendReasonCode,
    [property: JsonPropertyName("productId")] string ProductId,
    [property: JsonPropertyName("storefrontCountryCodes"), JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingDefault)] ImmutableArray<string>? StorefrontCountryCodes
);
