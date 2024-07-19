using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/accounttenure
[JsonConverter(typeof(AccountTenureConverter))]
public record AccountTenure(int RawValue)
{
    public static readonly AccountTenure Undeclared = new(0);
    public static readonly AccountTenure Age0To3Days = new(1);
    public static readonly AccountTenure Age3To10Days = new(2);
    public static readonly AccountTenure Age10To30Days = new(3);
    public static readonly AccountTenure Age30To90Days = new(4);
    public static readonly AccountTenure Age90To180Days = new(5);
    public static readonly AccountTenure Age180To365Days = new(6);
    public static readonly AccountTenure AgeOver365Days = new(7);
}