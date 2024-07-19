using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Models;

namespace AppStoreServerApi.Json;

public class UserStatusConverter : JsonConverter<UserStatus>
{
    public override UserStatus? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;
        
        var rawValue = reader.GetInt32();
        return new UserStatus(rawValue);
    }

    public override void Write(Utf8JsonWriter writer, UserStatus value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.RawValue);
    }
}