using System.Net;

namespace AppStoreServerApi.Models;

public sealed class Error(long errorCode, string errorMessage) : Exception(errorMessage)
{
    public readonly long ErrorCode = errorCode;
}