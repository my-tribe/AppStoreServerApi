namespace AppStoreServerApi.Models;

public sealed class UnauthorizedException : Exception
{
    internal UnauthorizedException() : base("The request is unauthorized; the JSON Web Token (JWT) is invalid.")
    {
    }
}