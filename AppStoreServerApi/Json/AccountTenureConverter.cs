using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Models;

namespace AppStoreServerApi.Json;

public class AccountTenureConverter : JsonConverter<AccountTenure>
{
    public override AccountTenure? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;
        
        var rawValue = reader.GetInt32();
        return new AccountTenure(rawValue);
    }

    public override void Write(Utf8JsonWriter writer, AccountTenure value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.RawValue);
    }
}