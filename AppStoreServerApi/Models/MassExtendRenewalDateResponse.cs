using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/massextendrenewaldateresponse
public record MassExtendRenewalDateResponse(
    [property: JsonPropertyName("requestIdentifier")] string RequestIdentifier
);
