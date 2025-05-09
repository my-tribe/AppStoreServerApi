using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/environment
[JsonConverter(typeof(RawStringConverter<Environment>))]
public record Environment(string RawValue) : IRawString<Environment>
{
    public static readonly Environment Sandbox = new("Sandbox");
    public static readonly Environment Production = new("Production");

    static Environment IRawString<Environment>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<Environment>.IntoRaw() => RawValue;
}