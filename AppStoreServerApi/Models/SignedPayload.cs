using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

using JWT.Builder;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/signedpayload
[JsonConverter(typeof(SignedPayloadConverter))]
public record SignedPayload(string RawValue)
{
    private JWSDecodedHeader? _decodedHeader;
    public JWSDecodedHeader DecodedHeader =>
        _decodedHeader ??= JwtBuilder.Create()
            .DecodeHeader<JWSDecodedHeader>(RawValue);

    private ResponseBodyV2DecodedPayload? _decodedPayload;
    public ResponseBodyV2DecodedPayload DecodedPayload =>
        _decodedPayload ??= JwtBuilder.Create()
            .DoNotVerifySignature()
            .Decode<ResponseBodyV2DecodedPayload>(RawValue);
}
