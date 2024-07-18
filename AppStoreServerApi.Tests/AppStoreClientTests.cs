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
}