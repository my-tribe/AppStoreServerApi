using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/inappownershiptype
[JsonConverter(typeof(JsonStringEnumConverter<InAppOwnershipType>))]
public enum InAppOwnershipType
{
    FAMILY_SHARED,
    PURCHASED
}