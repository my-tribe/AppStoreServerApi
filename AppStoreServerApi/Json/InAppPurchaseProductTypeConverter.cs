using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Models;

namespace AppStoreServerApi.Json;

public class InAppPurchaseProductTypeConverter : JsonConverter<InAppPurchaseProductType>
{
    public override InAppPurchaseProductType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rawValue = reader.GetString();
        return rawValue is not null ? new InAppPurchaseProductType(rawValue) : null;
    }

    public override void Write(Utf8JsonWriter writer, InAppPurchaseProductType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.RawValue);
    }
}