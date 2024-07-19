using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

public record ErrorResponse(
    [property: JsonPropertyName("errorCode")] long ErrorCode,
    [property: JsonPropertyName("errorMessage")] string ErrorMessage
)
{
    internal Error MakeTypedError() =>
        ErrorCode switch {
            4000002 => new InvalidAppIdentifierError(ErrorCode, ErrorMessage),
            4000005 => new InvalidRequestRevisionError(ErrorCode, ErrorMessage),
            4000006 => new InvalidTransactionIdError(ErrorCode, ErrorMessage),
            4000015 => new InvalidStartDateError(ErrorCode, ErrorMessage),
            4000016 => new InvalidEndDateError(ErrorCode, ErrorMessage),
            4000021 => new InvalidSortError(ErrorCode, ErrorMessage),
            4000022 => new InvalidProductTypeError(ErrorCode, ErrorMessage),
            4000023 => new InvalidProductIdError(ErrorCode, ErrorMessage),
            4000024 => new InvalidSubscriptionGroupIdentifierError(ErrorCode, ErrorMessage),
            4000026 => new InvalidInAppOwnershipTypeError(ErrorCode, ErrorMessage),
            4000031 => new InvalidStatusError(ErrorCode, ErrorMessage),
            4040001 => new AccountNotFoundError(ErrorCode, ErrorMessage),
            4040002 => new AccountNotFoundRetryableError(ErrorCode, ErrorMessage),
            4040003 => new AppNotFoundError(ErrorCode, ErrorMessage),
            4040004 => new AppNotFoundRetryableError(ErrorCode, ErrorMessage),
            4040010 => new TransactionIdNotFoundError(ErrorCode, ErrorMessage),
            4000030 => new InvalidRevokedError(ErrorCode, ErrorMessage),
            4290000 => new RateLimitExceededError(ErrorCode, ErrorMessage),
            5000000 => new GeneralInternalError(ErrorCode, ErrorMessage),
            5000001 => new GeneralInternalRetryableError(ErrorCode, ErrorMessage),
            _ => new Error(ErrorCode, ErrorMessage)
        };
}