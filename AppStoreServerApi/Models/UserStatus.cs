using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/userstatus
[JsonConverter(typeof(RawInt32Converter<UserStatus>))]
public record UserStatus(int RawValue) : IRawInt32<UserStatus>
{
    public static readonly UserStatus Undeclared = new(0);
    public static readonly UserStatus Active = new(1);
    public static readonly UserStatus Suspended = new(2);
    public static readonly UserStatus Terminated = new(3);
    public static readonly UserStatus Limited = new(4);

    static UserStatus IRawInt32<UserStatus>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<UserStatus>.IntoRaw() => RawValue;
}