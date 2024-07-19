using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Models;

namespace AppStoreServerApi.Json;

public class LifetimeDollarsPurchasedConverter : JsonConverter<LifetimeDollarsPurchased>
{
    public override LifetimeDollarsPurchased? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;
        
        var rawValue = reader.GetInt32();
        return new LifetimeDollarsPurchased(rawValue);
    }

    public override void Write(Utf8JsonWriter writer, LifetimeDollarsPurchased value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.RawValue);
    }
}
