using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

public record ErrorResponse(
    [property: JsonPropertyName("errorCode")] long ErrorCode,
    [property: JsonPropertyName("errorMessage")] string ErrorMessage
);