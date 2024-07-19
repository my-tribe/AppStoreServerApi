using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Models;

namespace AppStoreServerApi.Json;

public class JWSRenewalInfoConverter : JsonConverter<JWSRenewalInfo>
{
    public override JWSRenewalInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rawValue = reader.GetString();
        return rawValue is not null ? new JWSRenewalInfo(rawValue) : null;
    }

    public override void Write(Utf8JsonWriter writer, JWSRenewalInfo value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.RawValue);
    }
}