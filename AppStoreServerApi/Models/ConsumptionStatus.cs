using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/consumptionstatus
[JsonConverter(typeof(RawInt32Converter<ConsumptionStatus>))]
public record ConsumptionStatus(int RawValue) : IRawInt32<ConsumptionStatus>
{
    public static readonly ConsumptionStatus Undeclared = new(0);
    public static readonly ConsumptionStatus NotConsumed = new(1);
    public static readonly ConsumptionStatus PartiallyConsumed = new(2);
    public static readonly ConsumptionStatus FullyConsumed = new(3);

    static ConsumptionStatus IRawInt32<ConsumptionStatus>.FromRaw(int rawValue) => new(rawValue);
    int IRawInt32<ConsumptionStatus>.IntoRaw() => RawValue;
}
