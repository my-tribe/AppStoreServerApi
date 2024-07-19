using System.Text.Json;
using System.Text.Json.Serialization;

namespace AppStoreServerApi.Json;

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.UnixEpoch.AddMilliseconds(reader.GetInt64());
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var unixTime = value.ToUnixTimeMilliseconds();
        writer.WriteNumberValue(unixTime);
    }
}