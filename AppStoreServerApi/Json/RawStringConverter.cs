using System.Text.Json;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Json;

public class RawStringConverter<T> : JsonConverter<T>
    where T : class, IRawString<T>
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;

        var rawValue = reader.GetString()!;
        return T.FromRaw(rawValue);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.IntoRaw());
    }
}
