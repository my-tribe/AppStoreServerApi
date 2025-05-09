using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Models;

namespace AppStoreServerApi.Json;

public class SignedPayloadConverter : JsonConverter<SignedPayload>
{
    public override SignedPayload? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rawValue = reader.GetString();
        return rawValue is not null ? new SignedPayload(rawValue) : null;
    }

    public override void Write(Utf8JsonWriter writer, SignedPayload value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.RawValue);
    }
}