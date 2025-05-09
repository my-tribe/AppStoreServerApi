using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

using JWT.Builder;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/jwstransaction
[JsonConverter(typeof(RawStringConverter<JWSTransaction>))]
public record JWSTransaction(string RawValue) : IRawString<JWSTransaction>
{
    private JWSDecodedHeader? _decodedHeader;
    public JWSDecodedHeader DecodedHeader =>
        _decodedHeader ??= JwtBuilder.Create()
            .DecodeHeader<JWSDecodedHeader>(RawValue);

    private JWSTransactionDecodedPayload? _decodedPayload;
    public JWSTransactionDecodedPayload DecodedPayload =>
        _decodedPayload ??= JwtBuilder.Create()
            .DoNotVerifySignature()
            .Decode<JWSTransactionDecodedPayload>(RawValue);

    static JWSTransaction IRawString<JWSTransaction>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<JWSTransaction>.IntoRaw() => RawValue;
}