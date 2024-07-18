using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/environment
[JsonConverter(typeof(JsonStringEnumConverter<Environment>))]
public enum Environment
{
    Sandbox,
    Production
}