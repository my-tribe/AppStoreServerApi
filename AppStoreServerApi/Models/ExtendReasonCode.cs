using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/extendreasoncode
[JsonConverter(typeof(ExtendReasonCodeConverter))]
public record ExtendReasonCode(int RawValue)
{
    public static readonly ExtendReasonCode Undeclared = new(0);
    public static readonly ExtendReasonCode CustomerSatisfaction = new(1);
    public static readonly ExtendReasonCode Other = new(2);
    public static readonly ExtendReasonCode ServiceIssues = new(3);
}
