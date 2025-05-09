using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/responsebodyv2
public record ResponseBodyV2(
    [property: JsonPropertyName("signedPayload")] SignedPayload SignedPayload
);