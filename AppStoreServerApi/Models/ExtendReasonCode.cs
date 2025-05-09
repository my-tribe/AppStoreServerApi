using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/extendreasoncode
[JsonConverter(typeof(RawInt32Converter<ExtendReasonCode>))]
public record ExtendReasonCode(int RawValue) : IRawInt32<ExtendReasonCode>
{
    public static readonly ExtendReasonCode Undeclared = new(0);
    public static readonly ExtendReasonCode CustomerSatisfaction = new(1);
    public static readonly ExtendReasonCode Other = new(2);
    public static readonly ExtendReasonCode ServiceIssues = new(3);

    static ExtendReasonCode IRawInt32<ExtendReasonCode>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<ExtendReasonCode>.IntoRaw() => RawValue;
}
