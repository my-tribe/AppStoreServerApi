namespace AppStoreServerApi.Models;

public class Error : Exception
{
    public readonly long ErrorCode;

    internal Error(long errorCode, string errorMessage) : base(errorMessage)
    {
        ErrorCode = errorCode;
    }
}