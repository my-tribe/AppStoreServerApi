using JWT.Builder;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/jwstransaction
public record JWSTransaction(string RawValue)
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
}