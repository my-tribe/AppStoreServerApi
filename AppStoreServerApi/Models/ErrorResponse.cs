using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

public record ErrorResponse(
    [property: JsonPropertyName("errorCode")] long ErrorCode,
    [property: JsonPropertyName("errorMessage")] string ErrorMessage
)
{
    internal Error MakeTypedError() =>
        ErrorCode switch {
            4000006 => new InvalidTransactionIdError(ErrorCode, ErrorMessage),
            4040010 => new TransactionIdNotFoundError(ErrorCode, ErrorMessage),
            4290000 => new RateLimitExceededError(ErrorCode, ErrorMessage),
            5000000 => new GeneralInternalError(ErrorCode, ErrorMessage),
            5000001 => new GeneralInternalRetryableError(ErrorCode, ErrorMessage),
            _ => new Error(ErrorCode, ErrorMessage)
        };
}