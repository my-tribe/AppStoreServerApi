using System.Text.Json;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Json;

public class RawInt64Converter<T> : JsonConverter<T>
    where T : class, IRawInt64<T>
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;

        var rawValue = reader.GetInt64()!;
        return T.FromRaw(rawValue);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.IntoRaw());
    }
}
