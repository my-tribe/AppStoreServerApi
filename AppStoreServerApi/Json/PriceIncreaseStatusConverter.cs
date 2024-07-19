using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Models;

namespace AppStoreServerApi.Json;

public class PriceIncreaseStatusConverter : JsonConverter<PriceIncreaseStatus>
{
    public override PriceIncreaseStatus? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;
        
        var rawValue = reader.GetInt32();
        return new PriceIncreaseStatus(rawValue);
    }

    public override void Write(Utf8JsonWriter writer, PriceIncreaseStatus value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.RawValue);
    }
}