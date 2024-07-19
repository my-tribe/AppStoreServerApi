using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreserverapi/consumptionstatus
[JsonConverter(typeof(ConsumptionStatusConverter))]
public record ConsumptionStatus(int RawValue)
{
    public static readonly ConsumptionStatus Undeclared = new(0);
    public static readonly ConsumptionStatus NotConsumed = new(1);
    public static readonly ConsumptionStatus PartiallyConsumed = new(2);
    public static readonly ConsumptionStatus FullyConsumed = new(3);
}
