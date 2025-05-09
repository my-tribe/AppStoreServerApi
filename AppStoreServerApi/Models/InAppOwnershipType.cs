using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/inappownershiptype
[JsonConverter(typeof(RawStringConverter<InAppOwnershipType>))]
public record InAppOwnershipType(string RawValue) : IRawString<InAppOwnershipType>
{
    public static readonly InAppOwnershipType FamilyShared = new("FAMILY_SHARED");
    public static readonly InAppOwnershipType Purchased = new("PURCHASED");

    static InAppOwnershipType IRawString<InAppOwnershipType>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<InAppOwnershipType>.IntoRaw() => RawValue;
}