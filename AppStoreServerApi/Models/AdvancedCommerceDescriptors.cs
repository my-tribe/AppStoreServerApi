using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/advancedcommercedescriptors
public record AdvancedCommerceDescriptors(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("displayName")] string DisplayName
);