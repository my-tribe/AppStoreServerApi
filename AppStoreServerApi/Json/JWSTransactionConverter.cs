using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Models;

namespace AppStoreServerApi.Json;

public class JWSTransactionConverter : JsonConverter<JWSTransaction>
{
    public override JWSTransaction? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rawValue = reader.GetString();
        return rawValue is not null ? new JWSTransaction(rawValue) : null;
    }

    public override void Write(Utf8JsonWriter writer, JWSTransaction value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.RawValue);
    }
}