using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Models;

namespace AppStoreServerApi.Json;

public class RefundPreferenceConverter : JsonConverter<RefundPreference>
{
    public override RefundPreference? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;
        
        var rawValue = reader.GetInt32();
        return new RefundPreference(rawValue);
    }

    public override void Write(Utf8JsonWriter writer, RefundPreference value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.RawValue);
    }
}
