using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/extendrenewaldaterequest
public record ExtendRenewalDateRequest(
    [property: JsonPropertyName("extendByDays")] int ExtendByDays,
    [property: JsonPropertyName("extendReasonCode")] ExtendReasonCode ExtendReasonCode,
    [property: JsonPropertyName("requestIdentifier")] string RequestIdentifier
);
