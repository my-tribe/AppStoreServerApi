using System.Net;
using System.Net.Mime;
using System.Text.Json;

using AppStoreServerApi.Models;
using AppStoreServerApi.Tests.Mocks;

using Microsoft.Extensions.Logging.Abstractions;

using RichardSzalay.MockHttp;

namespace AppStoreServerApi.Tests;

public class AppStoreClientTests
{
#region GetTransactionHistoryAsync
    [Fact]
    public async Task GetTransactionHistoryAsync_WhenReceives200_ReturnsHistoryResponse()
    {
        const string transactionId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var desiredResponse = new HistoryResponse(100500, "bundleId", AppStoreServerApi.Models.Environment.Production, false, string.Empty, []);
        var responseContent = JsonSerializer.Serialize(desiredResponse);

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + $"inApps/v2/history/{transactionId}")
            .Respond(MediaTypeNames.Application.Json, responseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var result = await client.GetTransactionHistoryAsync(transactionId);

        Assert.Equal(desiredResponse.AppAppleId, result.AppAppleId);
    }

    [Fact]
    public async Task GetTransactionHistoryAsync_WhenReceives401_ThrowsUnauthorizedException()
    {
        const string transactionId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v2/history/*")
            .Respond(HttpStatusCode.Unauthorized);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await Assert.ThrowsAsync<UnauthorizedException>(() => client.GetTransactionHistoryAsync(transactionId));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, 4000002, typeof(InvalidAppIdentifierError))]
    [InlineData(HttpStatusCode.BadRequest, 4000005, typeof(InvalidRequestRevisionError))]
    [InlineData(HttpStatusCode.BadRequest, 4000006, typeof(InvalidTransactionIdError))]
    [InlineData(HttpStatusCode.BadRequest, 4000015, typeof(InvalidStartDateError))]
    [InlineData(HttpStatusCode.BadRequest, 4000016, typeof(InvalidEndDateError))]
    [InlineData(HttpStatusCode.BadRequest, 4000021, typeof(InvalidSortError))]
    [InlineData(HttpStatusCode.BadRequest, 4000022, typeof(InvalidProductTypeError))]
    [InlineData(HttpStatusCode.BadRequest, 4000023, typeof(InvalidProductIdError))]
    [InlineData(HttpStatusCode.BadRequest, 4000024, typeof(InvalidSubscriptionGroupIdentifierError))]
    [InlineData(HttpStatusCode.BadRequest, 4000026, typeof(InvalidInAppOwnershipTypeError))]
    [InlineData(HttpStatusCode.BadRequest, 4000030, typeof(InvalidRevokedError))]
    [InlineData(HttpStatusCode.NotFound, 4040001, typeof(AccountNotFoundError))]
    [InlineData(HttpStatusCode.NotFound, 4040002, typeof(AccountNotFoundRetryableError))]
    [InlineData(HttpStatusCode.NotFound, 4040003, typeof(AppNotFoundError))]
    [InlineData(HttpStatusCode.NotFound, 4040004, typeof(AppNotFoundRetryableError))]
    [InlineData(HttpStatusCode.NotFound, 4040010, typeof(TransactionIdNotFoundError))]
    [InlineData(HttpStatusCode.TooManyRequests, 4290000, typeof(RateLimitExceededError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000000, typeof(GeneralInternalError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000001, typeof(GeneralInternalRetryableError))]
    public async Task GetTransactionHistoryAsync_WhenReceivesError_ThrowsCorrespondingException(
        HttpStatusCode httpStatusCode, long errorCode, Type desiredErrorType)
    {
        const string transactionId = "12345";
        const string errorMessage = "some message";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var errorResponseContent = JsonSerializer.Serialize(new ErrorResponse(errorCode, errorMessage));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v2/history/*")
            .Respond(httpStatusCode, MediaTypeNames.Application.Json, errorResponseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var exception = (Error) await Assert.ThrowsAsync(desiredErrorType, () => client.GetTransactionHistoryAsync(transactionId));
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.Message);
    }
#endregion GetTransactionHistoryAsync

#region GetTransactionInfoAsync
    [Fact]
    public async Task GetTransactionInfoAsync_WhenReceives200_ReturnsTransactionInfoResponse()
    {
        const string signedTransactionInfo = "signedTransactionInfo";
        const string transactionId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var responseContent = JsonSerializer.Serialize(new TransactionInfoResponse(new JWSTransaction(signedTransactionInfo)));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + $"inApps/v1/transactions/{transactionId}")
            .Respond(MediaTypeNames.Application.Json, responseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var result = await client.GetTransactionInfoAsync(transactionId);

        Assert.Equal(signedTransactionInfo, result.SignedTransactionInfo.RawValue);
    }

    [Fact]
    public async Task GetTransactionInfoAsync_WhenReceives401_ThrowsUnauthorizedException()
    {
        const string transactionId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v1/transactions/*")
            .Respond(HttpStatusCode.Unauthorized);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await Assert.ThrowsAsync<UnauthorizedException>(() => client.GetTransactionInfoAsync(transactionId));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, 4000006, typeof(InvalidTransactionIdError))]
    [InlineData(HttpStatusCode.NotFound, 4040010, typeof(TransactionIdNotFoundError))]
    [InlineData(HttpStatusCode.TooManyRequests, 4290000, typeof(RateLimitExceededError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000000, typeof(GeneralInternalError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000001, typeof(GeneralInternalRetryableError))]
    public async Task GetTransactionInfoAsync_WhenReceivesError_ThrowsCorrespondingException(
        HttpStatusCode httpStatusCode, long errorCode, Type desiredErrorType)
    {
        const string transactionId = "12345";
        const string errorMessage = "some message";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var errorResponseContent = JsonSerializer.Serialize(new ErrorResponse(errorCode, errorMessage));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v1/transactions/*")
            .Respond(httpStatusCode, MediaTypeNames.Application.Json, errorResponseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var exception = (Error) await Assert.ThrowsAsync(desiredErrorType, () => client.GetTransactionInfoAsync(transactionId));
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.Message);
    }
#endregion GetTransactionInfoAsync

#region GetAllSubscriptionStatusesAsync
    [Fact]
    public async Task GetAllSubscriptionStatusesAsync_WhenReceives200_ReturnsStatusResponse()
    {
        const string transactionId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var desiredResponse = new StatusResponse([], AppStoreServerApi.Models.Environment.Production, 100500, "bundleId");
        var responseContent = JsonSerializer.Serialize(desiredResponse);

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + $"inApps/v1/subscriptions/{transactionId}")
            .Respond(MediaTypeNames.Application.Json, responseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var result = await client.GetAllSubscriptionStatusesAsync(transactionId);

        Assert.Equal(desiredResponse.AppAppleId, result.AppAppleId);
    }

    [Fact]
    public async Task GetAllSubscriptionStatusesAsync_WhenReceives401_ThrowsUnauthorizedException()
    {
        const string transactionId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v1/subscriptions/*")
            .Respond(HttpStatusCode.Unauthorized);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await Assert.ThrowsAsync<UnauthorizedException>(() => client.GetAllSubscriptionStatusesAsync(transactionId));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, 4000002, typeof(InvalidAppIdentifierError))]
    [InlineData(HttpStatusCode.BadRequest, 4000006, typeof(InvalidTransactionIdError))]
    [InlineData(HttpStatusCode.BadRequest, 4000031, typeof(InvalidStatusError))]
    [InlineData(HttpStatusCode.NotFound, 4040001, typeof(AccountNotFoundError))]
    [InlineData(HttpStatusCode.NotFound, 4040002, typeof(AccountNotFoundRetryableError))]
    [InlineData(HttpStatusCode.NotFound, 4040003, typeof(AppNotFoundError))]
    [InlineData(HttpStatusCode.NotFound, 4040004, typeof(AppNotFoundRetryableError))]
    [InlineData(HttpStatusCode.NotFound, 4040010, typeof(TransactionIdNotFoundError))]
    [InlineData(HttpStatusCode.TooManyRequests, 4290000, typeof(RateLimitExceededError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000000, typeof(GeneralInternalError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000001, typeof(GeneralInternalRetryableError))]
    public async Task GetAllSubscriptionStatusesAsync_WhenReceivesError_ThrowsCorrespondingException(
        HttpStatusCode httpStatusCode, long errorCode, Type desiredErrorType)
    {
        const string transactionId = "12345";
        const string errorMessage = "some message";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var errorResponseContent = JsonSerializer.Serialize(new ErrorResponse(errorCode, errorMessage));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v1/subscriptions/*")
            .Respond(httpStatusCode, MediaTypeNames.Application.Json, errorResponseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var exception = (Error) await Assert.ThrowsAsync(desiredErrorType, () => client.GetAllSubscriptionStatusesAsync(transactionId));
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.Message);
    }
#endregion GetAllSubscriptionStatusesAsync

#region SendConsumptionInformationAsync
    [Fact]
    public async Task SendConsumptionInformationAsync_WhenReceives202_ReturnsStatusResponse()
    {
        const string transactionId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Put, environment.BaseUrl + $"inApps/v1/transactions/consumption/{transactionId}")
            .Respond(HttpStatusCode.Accepted);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await client.SendConsumptionInformationAsync(transactionId,
            AccountTenure.Undeclared, string.Empty, ConsumptionStatus.Undeclared,
            true, DeliveryStatus.Delivered, LifetimeDollarsPurchased.Undeclared,
            LifetimeDollarsRefunded.Undeclared, Platform.Undeclared, PlayTime.Undeclared,
            RefundPreference.Undeclared, true, UserStatus.Undeclared);
    }

    [Fact]
    public async Task SendConsumptionInformationAsync_WhenReceives401_ThrowsUnauthorizedException()
    {
        const string transactionId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Put, environment.BaseUrl + "inApps/v1/transactions/consumption/*")
            .Respond(HttpStatusCode.Unauthorized);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await Assert.ThrowsAsync<UnauthorizedException>(() => client.SendConsumptionInformationAsync(transactionId,
            AccountTenure.Undeclared, string.Empty, ConsumptionStatus.Undeclared,
            true, DeliveryStatus.Delivered, LifetimeDollarsPurchased.Undeclared,
            LifetimeDollarsRefunded.Undeclared, Platform.Undeclared, PlayTime.Undeclared,
            RefundPreference.Undeclared, true, UserStatus.Undeclared));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, 4000032, typeof(InvalidAccountTenureError))]
    [InlineData(HttpStatusCode.BadRequest, 4000033, typeof(InvalidAppAccountTokenError))]
    [InlineData(HttpStatusCode.BadRequest, 4000034, typeof(InvalidConsumptionStatusError))]
    [InlineData(HttpStatusCode.BadRequest, 4000035, typeof(InvalidCustomerConsentedError))]
    [InlineData(HttpStatusCode.BadRequest, 4000036, typeof(InvalidDeliveryStatusError))]
    [InlineData(HttpStatusCode.BadRequest, 4000037, typeof(InvalidLifetimeDollarsPurchasedError))]
    [InlineData(HttpStatusCode.BadRequest, 4000038, typeof(InvalidLifetimeDollarsRefundedError))]
    [InlineData(HttpStatusCode.BadRequest, 4000039, typeof(InvalidPlatformError))]
    [InlineData(HttpStatusCode.BadRequest, 4000040, typeof(InvalidPlayTimeError))]
    [InlineData(HttpStatusCode.BadRequest, 4000041, typeof(InvalidSampleContentProvidedError))]
    [InlineData(HttpStatusCode.BadRequest, 4000042, typeof(InvalidUserStatusError))]
    [InlineData(HttpStatusCode.BadRequest, 4000044, typeof(InvalidRefundPreferenceError))]
    [InlineData(HttpStatusCode.BadRequest, 4000047, typeof(InvalidTransactionTypeNotSupportedError))]
    [InlineData(HttpStatusCode.NotFound, 4040010, typeof(TransactionIdNotFoundError))]
    [InlineData(HttpStatusCode.TooManyRequests, 4290000, typeof(RateLimitExceededError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000000, typeof(GeneralInternalError))]
    public async Task SendConsumptionInformationAsync_WhenReceivesError_ThrowsCorrespondingException(
        HttpStatusCode httpStatusCode, long errorCode, Type desiredErrorType)
    {
        const string transactionId = "12345";
        const string errorMessage = "some message";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var errorResponseContent = JsonSerializer.Serialize(new ErrorResponse(errorCode, errorMessage));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Put, environment.BaseUrl + "inApps/v1/transactions/consumption/*")
            .Respond(httpStatusCode, MediaTypeNames.Application.Json, errorResponseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var exception = (Error) await Assert.ThrowsAsync(desiredErrorType, () => client.SendConsumptionInformationAsync(transactionId,
            AccountTenure.Undeclared, string.Empty, ConsumptionStatus.Undeclared,
            true, DeliveryStatus.Delivered, LifetimeDollarsPurchased.Undeclared,
            LifetimeDollarsRefunded.Undeclared, Platform.Undeclared, PlayTime.Undeclared,
            RefundPreference.Undeclared, true, UserStatus.Undeclared));
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.Message);
    }
#endregion SendConsumptionInformationAsync

#region LookUpOrderIdAsync
    [Fact]
    public async Task LookUpOrderIdAsync_WhenReceives200_ReturnsStatusResponse()
    {
        const string orderId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var responseContent = JsonSerializer.Serialize(new OrderLookupResponse(OrderLookupStatus.InvalidOrEmpty, []));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + $"inApps/v1/lookup/{orderId}")
            .Respond(MediaTypeNames.Application.Json, responseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var result = await client.LookUpOrderIdAsync(orderId);

        Assert.Equal(OrderLookupStatus.InvalidOrEmpty, result.Status);
    }

    [Fact]
    public async Task LookUpOrderIdAsync_WhenReceives401_ThrowsUnauthorizedException()
    {
        const string orderId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v1/lookup/*")
            .Respond(HttpStatusCode.Unauthorized);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await Assert.ThrowsAsync<UnauthorizedException>(() => client.LookUpOrderIdAsync(orderId));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, 4000000, typeof(GeneralBadRequestError))]
    [InlineData(HttpStatusCode.TooManyRequests, 4290000, typeof(RateLimitExceededError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000000, typeof(GeneralInternalError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000001, typeof(GeneralInternalRetryableError))]
    public async Task LookUpOrderIdAsync_WhenReceivesError_ThrowsCorrespondingException(
        HttpStatusCode httpStatusCode, long errorCode, Type desiredErrorType)
    {
        const string orderId = "12345";
        const string errorMessage = "some message";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var errorResponseContent = JsonSerializer.Serialize(new ErrorResponse(errorCode, errorMessage));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v1/lookup/*")
            .Respond(httpStatusCode, MediaTypeNames.Application.Json, errorResponseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var exception = (Error) await Assert.ThrowsAsync(desiredErrorType, () => client.LookUpOrderIdAsync(orderId));
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.Message);
    }
#endregion LookUpOrderIdAsync

#region GetRefundHistoryAsync
    [Fact]
    public async Task GetRefundHistoryAsync_WhenReceives200_ReturnsHistoryResponse()
    {
        const string transactionId = "12345";
        const string revision = "revision";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var desiredResponse = new RefundHistoryResponse(true, revision, []);
        var responseContent = JsonSerializer.Serialize(desiredResponse);

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + $"inApps/v2/refund/lookup/{transactionId}")
            .Respond(MediaTypeNames.Application.Json, responseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var result = await client.GetRefundHistoryAsync(transactionId);

        Assert.Equal(desiredResponse.Revision, result.Revision);
    }

    [Fact]
    public async Task GetRefundHistoryAsync_WhenReceives401_ThrowsUnauthorizedException()
    {
        const string transactionId = "12345";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v2/refund/lookup/*")
            .Respond(HttpStatusCode.Unauthorized);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await Assert.ThrowsAsync<UnauthorizedException>(() => client.GetRefundHistoryAsync(transactionId));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, 4000005, typeof(InvalidRequestRevisionError))]
    [InlineData(HttpStatusCode.BadRequest, 4000006, typeof(InvalidTransactionIdError))]
    [InlineData(HttpStatusCode.NotFound, 4040010, typeof(TransactionIdNotFoundError))]
    [InlineData(HttpStatusCode.TooManyRequests, 4290000, typeof(RateLimitExceededError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000000, typeof(GeneralInternalError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000001, typeof(GeneralInternalRetryableError))]
    public async Task GetRefundHistoryAsync_WhenReceivesError_ThrowsCorrespondingException(
        HttpStatusCode httpStatusCode, long errorCode, Type desiredErrorType)
    {
        const string transactionId = "12345";
        const string errorMessage = "some message";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var errorResponseContent = JsonSerializer.Serialize(new ErrorResponse(errorCode, errorMessage));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v2/refund/lookup/*")
            .Respond(httpStatusCode, MediaTypeNames.Application.Json, errorResponseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var exception = (Error) await Assert.ThrowsAsync(desiredErrorType, () => client.GetRefundHistoryAsync(transactionId));
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.Message);
    }
#endregion GetRefundHistoryAsync

#region ExtendSubscriptionRenewalDateAsync
    [Fact]
    public async Task ExtendSubscriptionRenewalDateAsync_WhenReceives200_ReturnsStatusResponse()
    {
        const string originalTransactionId = "12345";
        const int extendByDays = 1;
        const string requestId = "requstId";
        const string webOrderLineItemId = "webOrderLineItemId";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var desiredResponse = new ExtendRenewalDateResponse(DateTime.UnixEpoch, originalTransactionId, true, webOrderLineItemId);
        var responseContent = JsonSerializer.Serialize(desiredResponse);

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Put, environment.BaseUrl + $"inApps/v1/subscriptions/extend/{originalTransactionId}")
            .Respond(MediaTypeNames.Application.Json, responseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var response = await client.ExtendSubscriptionRenewalDateAsync(originalTransactionId,
            extendByDays, ExtendReasonCode.Undeclared, requestId);

        Assert.Equal(desiredResponse, response);
    }

    [Fact]
    public async Task ExtendSubscriptionRenewalDateAsync_WhenReceives401_ThrowsUnauthorizedException()
    {
        const string originalTransactionId = "12345";
        const int extendByDays = 1;
        const string requestId = "requstId";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Put, environment.BaseUrl + "inApps/v1/subscriptions/extend/*")
            .Respond(HttpStatusCode.Unauthorized);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await Assert.ThrowsAsync<UnauthorizedException>(() => client.ExtendSubscriptionRenewalDateAsync(originalTransactionId,
            extendByDays, ExtendReasonCode.Undeclared, requestId));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, 4000008, typeof(InvalidOriginalTransactionIdError))]
    [InlineData(HttpStatusCode.BadRequest, 4000009, typeof(InvalidExtendByDaysError))]
    [InlineData(HttpStatusCode.BadRequest, 4000010, typeof(InvalidExtendReasonCodeError))]
    [InlineData(HttpStatusCode.BadRequest, 4000011, typeof(InvalidRequestIdentifierError))]
    [InlineData(HttpStatusCode.Forbidden, 4030004, typeof(SubscriptionExtensionIneligibleError))]
    [InlineData(HttpStatusCode.Forbidden, 4030005, typeof(SubscriptionMaxExtensionError))]
    [InlineData(HttpStatusCode.Forbidden, 4030007, typeof(FamilySharedSubscriptionExtensionIneligibleError))]
    [InlineData(HttpStatusCode.NotFound, 4040005, typeof(OriginalTransactionIdNotFoundError))]
    [InlineData(HttpStatusCode.TooManyRequests, 4290000, typeof(RateLimitExceededError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000000, typeof(GeneralInternalError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000001, typeof(GeneralInternalRetryableError))]
    public async Task ExtendSubscriptionRenewalDateAsync_WhenReceivesError_ThrowsCorrespondingException(
        HttpStatusCode httpStatusCode, long errorCode, Type desiredErrorType)
    {
        const string originalTransactionId = "12345";
        const int extendByDays = 1;
        const string requestId = "requstId";
        const string errorMessage = "some message";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var errorResponseContent = JsonSerializer.Serialize(new ErrorResponse(errorCode, errorMessage));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Put, environment.BaseUrl + "inApps/v1/subscriptions/extend/*")
            .Respond(httpStatusCode, MediaTypeNames.Application.Json, errorResponseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var exception = (Error) await Assert.ThrowsAsync(desiredErrorType, () => client.ExtendSubscriptionRenewalDateAsync(originalTransactionId,
            extendByDays, ExtendReasonCode.Undeclared, requestId));
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.Message);
    }
#endregion ExtendSubscriptionRenewalDateAsync

#region ExtendSubscriptionRenewalDatesForAllActiveSubscribersAsync
    [Fact]
    public async Task ExtendSubscriptionRenewalDatesForAllActiveSubscribersAsync_WhenReceives200_ReturnsStatusResponse()
    {
        const int extendByDays = 1;
        const string requestId = "requstId";
        const string productId = "productId";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var desiredResponse = new MassExtendRenewalDateResponse(requestId);
        var responseContent = JsonSerializer.Serialize(desiredResponse);

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Post, environment.BaseUrl + "inApps/v1/subscriptions/extend/mass/")
            .Respond(MediaTypeNames.Application.Json, responseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var response = await client.ExtendSubscriptionRenewalDatesForAllActiveSubscribersAsync(
            requestId, extendByDays, ExtendReasonCode.Other, productId);

        Assert.Equal(desiredResponse, response);
    }

    [Fact]
    public async Task ExtendSubscriptionRenewalDatesForAllActiveSubscribersAsync_WhenReceives401_ThrowsUnauthorizedException()
    {
        const int extendByDays = 1;
        const string requestId = "requstId";
        const string productId = "productId";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Post, environment.BaseUrl + "inApps/v1/subscriptions/extend/mass/")
            .Respond(HttpStatusCode.Unauthorized);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await Assert.ThrowsAsync<UnauthorizedException>(() => client.ExtendSubscriptionRenewalDatesForAllActiveSubscribersAsync(
            requestId, extendByDays, ExtendReasonCode.Other, productId));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, 4000009, typeof(InvalidExtendByDaysError))]
    [InlineData(HttpStatusCode.BadRequest, 4000010, typeof(InvalidExtendReasonCodeError))]
    [InlineData(HttpStatusCode.BadRequest, 4000011, typeof(InvalidRequestIdentifierError))]
    [InlineData(HttpStatusCode.BadRequest, 4000023, typeof(InvalidProductIdError))]
    [InlineData(HttpStatusCode.BadRequest, 4000027, typeof(InvalidEmptyStorefrontCountryCodeListError))]
    [InlineData(HttpStatusCode.BadRequest, 4000028, typeof(InvalidStorefrontCountryCodeError))]
    [InlineData(HttpStatusCode.Forbidden, 4030004, typeof(SubscriptionExtensionIneligibleError))]
    [InlineData(HttpStatusCode.Forbidden, 4030005, typeof(SubscriptionMaxExtensionError))]
    [InlineData(HttpStatusCode.TooManyRequests, 4290000, typeof(RateLimitExceededError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000000, typeof(GeneralInternalError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000001, typeof(GeneralInternalRetryableError))]
    public async Task ExtendSubscriptionRenewalDatesForAllActiveSubscribersAsync_WhenReceivesError_ThrowsCorrespondingException(
        HttpStatusCode httpStatusCode, long errorCode, Type desiredErrorType)
    {
        const int extendByDays = 1;
        const string requestId = "requstId";
        const string productId = "productId";
        const string errorMessage = "some message";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var errorResponseContent = JsonSerializer.Serialize(new ErrorResponse(errorCode, errorMessage));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Post, environment.BaseUrl + "inApps/v1/subscriptions/extend/mass/")
            .Respond(httpStatusCode, MediaTypeNames.Application.Json, errorResponseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var exception = (Error) await Assert.ThrowsAsync(desiredErrorType, () => client.ExtendSubscriptionRenewalDatesForAllActiveSubscribersAsync(
            requestId, extendByDays, ExtendReasonCode.Other, productId));
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.Message);
    }
#endregion ExtendSubscriptionRenewalDatesForAllActiveSubscribersAsync

#region GetStatusOfSubscriptionRenewalDateExtensionsAsync
    [Fact]
    public async Task GetStatusOfSubscriptionRenewalDateExtensionsAsync_WhenReceives200_ReturnsTransactionInfoResponse()
    {
        const string productId = "productId";
        const string requestIdentifier = "requestIdentifier";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var desiredResponse = new MassExtendRenewalDateStatusResponse(
            requestIdentifier, true, DateTime.UnixEpoch, 1, 1);
        var responseContent = JsonSerializer.Serialize(desiredResponse);

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + $"inApps/v1/subscriptions/extend/mass/{productId}/{requestIdentifier}")
            .Respond(MediaTypeNames.Application.Json, responseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var result = await client.GetStatusOfSubscriptionRenewalDateExtensionsAsync(productId, requestIdentifier);

        Assert.Equal(desiredResponse, result);
    }

    [Fact]
    public async Task GetStatusOfSubscriptionRenewalDateExtensionsAsync_WhenReceives401_ThrowsUnauthorizedException()
    {
        const string productId = "productId";
        const string requestIdentifier = "requestIdentifier";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v1/subscriptions/extend/mass/*/*")
            .Respond(HttpStatusCode.Unauthorized);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await Assert.ThrowsAsync<UnauthorizedException>(() => client.GetStatusOfSubscriptionRenewalDateExtensionsAsync(productId, requestIdentifier));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, 4000011, typeof(InvalidRequestIdentifierError))]
    [InlineData(HttpStatusCode.BadRequest, 4000023, typeof(InvalidProductIdError))]
    [InlineData(HttpStatusCode.NotFound, 4040009, typeof(StatusRequestNotFoundError))]
    [InlineData(HttpStatusCode.TooManyRequests, 4290000, typeof(RateLimitExceededError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000000, typeof(GeneralInternalError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000001, typeof(GeneralInternalRetryableError))]
    public async Task GetStatusOfSubscriptionRenewalDateExtensionsAsync_WhenReceivesError_ThrowsCorrespondingException(
        HttpStatusCode httpStatusCode, long errorCode, Type desiredErrorType)
    {
        const string productId = "productId";
        const string requestIdentifier = "requestIdentifier";
        const string errorMessage = "some message";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var errorResponseContent = JsonSerializer.Serialize(new ErrorResponse(errorCode, errorMessage));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(environment.BaseUrl + "inApps/v1/subscriptions/extend/mass/*/*")
            .Respond(httpStatusCode, MediaTypeNames.Application.Json, errorResponseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var exception = (Error) await Assert.ThrowsAsync(desiredErrorType, () => client.GetStatusOfSubscriptionRenewalDateExtensionsAsync(productId, requestIdentifier));
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.Message);
    }
#endregion GetStatusOfSubscriptionRenewalDateExtensionsAsync

#region GetNotificationHistoryAsync
    [Fact]
    public async Task GetNotificationHistoryAsync_WhenReceives200_ReturnsTransactionInfoResponse()
    {
        const string paginationToken = "paginationToken";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var desiredResponse = new NotificationHistoryResponse([], true, paginationToken);
        var responseContent = JsonSerializer.Serialize(desiredResponse);

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Post, environment.BaseUrl + "inApps/v1/notifications/history")
            .Respond(MediaTypeNames.Application.Json, responseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var result = await client.GetNotificationHistoryAsync(DateTime.MinValue, DateTime.MaxValue);

        Assert.Equal(desiredResponse.HasMore, result.HasMore);
        Assert.Equal(desiredResponse.PaginationToken, result.PaginationToken);
    }

    [Fact]
    public async Task GetNotificationHistoryAsync_WhenReceives401_ThrowsUnauthorizedException()
    {
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Post, environment.BaseUrl + "inApps/v1/notifications/history")
            .Respond(HttpStatusCode.Unauthorized);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        await Assert.ThrowsAsync<UnauthorizedException>(() => client.GetNotificationHistoryAsync(DateTime.MinValue, DateTime.MaxValue));
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, 4000006, typeof(InvalidTransactionIdError))]
    [InlineData(HttpStatusCode.BadRequest, 4000012, typeof(StartDateTooFarInPastError))]
    [InlineData(HttpStatusCode.BadRequest, 4000013, typeof(StartDateAfterEndDateError))]
    [InlineData(HttpStatusCode.BadRequest, 4000014, typeof(InvalidPaginationTokenError))]
    [InlineData(HttpStatusCode.BadRequest, 4000015, typeof(InvalidStartDateError))]
    [InlineData(HttpStatusCode.BadRequest, 4000016, typeof(InvalidEndDateError))]
    [InlineData(HttpStatusCode.BadRequest, 4000017, typeof(PaginationTokenExpiredError))]
    [InlineData(HttpStatusCode.BadRequest, 4000018, typeof(InvalidNotificationTypeError))]
    [InlineData(HttpStatusCode.BadRequest, 4000019, typeof(MultipleFiltersSuppliedError))]
    [InlineData(HttpStatusCode.NotFound, 4040001, typeof(AccountNotFoundError))]
    [InlineData(HttpStatusCode.NotFound, 4040010, typeof(TransactionIdNotFoundError))]
    [InlineData(HttpStatusCode.TooManyRequests, 4290000, typeof(RateLimitExceededError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000000, typeof(GeneralInternalError))]
    [InlineData(HttpStatusCode.InternalServerError, 5000001, typeof(GeneralInternalRetryableError))]
    public async Task GetNotificationHistoryAsync_WhenReceivesError_ThrowsCorrespondingException(
        HttpStatusCode httpStatusCode, long errorCode, Type desiredErrorType)
    {
        const string errorMessage = "some message";
        var environment = AppleEnvironment.Production;
        var jwtProvider = new MockJwtProvider();

        var errorResponseContent = JsonSerializer.Serialize(new ErrorResponse(errorCode, errorMessage));

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(HttpMethod.Post, environment.BaseUrl + "inApps/v1/notifications/history")
            .Respond(httpStatusCode, MediaTypeNames.Application.Json, errorResponseContent);

        HttpClient HttpClientFactory() => mockHttp.ToHttpClient();

        var client = new AppStoreClient(NullLogger<AppStoreClient>.Instance, HttpClientFactory, environment, jwtProvider);

        var exception = (Error) await Assert.ThrowsAsync(desiredErrorType, () => client.GetNotificationHistoryAsync(DateTime.MinValue, DateTime.MaxValue));
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.Message);
    }
#endregion GetNotificationHistoryAsync
}