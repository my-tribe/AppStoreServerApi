using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

public record ErrorResponse(
    [property: JsonPropertyName("errorCode")] long ErrorCode,
    [property: JsonPropertyName("errorMessage")] string ErrorMessage
)
{
    internal Error MakeTypedError() =>
        ErrorCode switch {
            4000000 => new GeneralBadRequestError(ErrorCode, ErrorMessage),
            4000002 => new InvalidAppIdentifierError(ErrorCode, ErrorMessage),
            4000005 => new InvalidRequestRevisionError(ErrorCode, ErrorMessage),
            4000006 => new InvalidTransactionIdError(ErrorCode, ErrorMessage),
            4000008 => new InvalidOriginalTransactionIdError(ErrorCode, ErrorMessage),
            4000009 => new InvalidExtendByDaysError(ErrorCode, ErrorMessage),
            4000010 => new InvalidExtendReasonCodeError(ErrorCode, ErrorMessage),
            4000011 => new InvalidRequestIdentifierError(ErrorCode, ErrorMessage),
            4000015 => new InvalidStartDateError(ErrorCode, ErrorMessage),
            4000016 => new InvalidEndDateError(ErrorCode, ErrorMessage),
            4000021 => new InvalidSortError(ErrorCode, ErrorMessage),
            4000022 => new InvalidProductTypeError(ErrorCode, ErrorMessage),
            4000023 => new InvalidProductIdError(ErrorCode, ErrorMessage),
            4000024 => new InvalidSubscriptionGroupIdentifierError(ErrorCode, ErrorMessage),
            4000026 => new InvalidInAppOwnershipTypeError(ErrorCode, ErrorMessage),
            4000027 => new InvalidEmptyStorefrontCountryCodeListError(ErrorCode, ErrorMessage),
            4000028 => new InvalidStorefrontCountryCodeError(ErrorCode, ErrorMessage),
            4000031 => new InvalidStatusError(ErrorCode, ErrorMessage),
            4000032 => new InvalidAccountTenureError(ErrorCode, ErrorMessage),
            4000033 => new InvalidAppAccountTokenError(ErrorCode, ErrorMessage),
            4000034 => new InvalidConsumptionStatusError(ErrorCode, ErrorMessage),
            4000035 => new InvalidCustomerConsentedError(ErrorCode, ErrorMessage),
            4000036 => new InvalidDeliveryStatusError(ErrorCode, ErrorMessage),
            4000037 => new InvalidLifetimeDollarsPurchasedError(ErrorCode, ErrorMessage),
            4000038 => new InvalidLifetimeDollarsRefundedError(ErrorCode, ErrorMessage),
            4000039 => new InvalidPlatformError(ErrorCode, ErrorMessage),
            4000040 => new InvalidPlayTimeError(ErrorCode, ErrorMessage),
            4000041 => new InvalidSampleContentProvidedError(ErrorCode, ErrorMessage),
            4000042 => new InvalidUserStatusError(ErrorCode, ErrorMessage),
            4000044 => new InvalidRefundPreferenceError(ErrorCode, ErrorMessage),
            4000047 => new InvalidTransactionTypeNotSupportedError(ErrorCode, ErrorMessage),
            4030004 => new SubscriptionExtensionIneligibleError(ErrorCode, ErrorMessage),
            4030005 => new SubscriptionMaxExtensionError(ErrorCode, ErrorMessage),
            4030007 => new FamilySharedSubscriptionExtensionIneligibleError(ErrorCode, ErrorMessage),
            4040001 => new AccountNotFoundError(ErrorCode, ErrorMessage),
            4040002 => new AccountNotFoundRetryableError(ErrorCode, ErrorMessage),
            4040003 => new AppNotFoundError(ErrorCode, ErrorMessage),
            4040004 => new AppNotFoundRetryableError(ErrorCode, ErrorMessage),
            4040005 => new OriginalTransactionIdNotFoundError(ErrorCode, ErrorMessage),
            4040009 => new StatusRequestNotFoundError(ErrorCode, ErrorMessage),
            4040010 => new TransactionIdNotFoundError(ErrorCode, ErrorMessage),
            4000030 => new InvalidRevokedError(ErrorCode, ErrorMessage),
            4290000 => new RateLimitExceededError(ErrorCode, ErrorMessage),
            5000000 => new GeneralInternalError(ErrorCode, ErrorMessage),
            5000001 => new GeneralInternalRetryableError(ErrorCode, ErrorMessage),
            _ => new Error(ErrorCode, ErrorMessage)
        };
}