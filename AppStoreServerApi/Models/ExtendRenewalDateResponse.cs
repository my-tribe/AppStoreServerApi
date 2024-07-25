using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/extendrenewaldateresponse
public record ExtendRenewalDateResponse(
    [property: JsonPropertyName("effectiveDate"), JsonConverter(typeof(DateTimeConverter))] DateTime EffectiveDate,
    [property: JsonPropertyName("originalTransactionId")] string OriginalTransactionId,
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("webOrderLineItemId")] string WebOrderLineItemId
);