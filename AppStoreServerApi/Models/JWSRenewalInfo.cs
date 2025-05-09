using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

using JWT.Builder;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/jwsrenewalinfo
[JsonConverter(typeof(RawStringConverter<JWSRenewalInfo>))]
public record JWSRenewalInfo(string RawValue) : IRawString<JWSRenewalInfo>
{
    private JWSDecodedHeader? _decodedHeader;
    public JWSDecodedHeader DecodedHeader =>
        _decodedHeader ??= JwtBuilder.Create()
            .DecodeHeader<JWSDecodedHeader>(RawValue);

    private JWSRenewalInfoDecodedPayload? _decodedPayload;
    public JWSRenewalInfoDecodedPayload DecodedPayload =>
        _decodedPayload ??= JwtBuilder.Create()
            .DoNotVerifySignature()
            .Decode<JWSRenewalInfoDecodedPayload>(RawValue);

    static JWSRenewalInfo IRawString<JWSRenewalInfo>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<JWSRenewalInfo>.IntoRaw() => RawValue;
}