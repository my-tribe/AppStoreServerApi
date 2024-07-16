using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/jwsdecodedheader
public record JWSDecodedHeader(
    [property: JsonPropertyName("alg")] string Alg,
    [property: JsonPropertyName("x5c")] ImmutableArray<string> X5C
);