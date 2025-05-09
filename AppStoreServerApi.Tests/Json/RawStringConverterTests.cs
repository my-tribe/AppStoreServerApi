using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Tests.Json;

public class RawStringConverterTests
{
    [JsonConverter(typeof(RawStringConverter<RawStringType>))]
    public record RawStringType(string RawValue) : IRawString<RawStringType>
    {
        static RawStringType IRawString<RawStringType>.FromRaw(string rawValue) => new(rawValue);
        string IRawString<RawStringType>.IntoRaw() => RawValue;
    }

    public record WrapperObject(
        [property: JsonPropertyName("inner")] RawStringType Inner
    );

    [Fact]
    public void RawStringConverter_SerializeAndDeserialize_Correct()
    {
        const string desiredJsonSourceObject = @"{""inner"":""rawStringValue""}";

        var sourceObject = new WrapperObject(new RawStringType("rawStringValue"));

        var jsonSourceObject = JsonSerializer.Serialize(sourceObject);

        Assert.Equal(desiredJsonSourceObject, jsonSourceObject);

        var deserializedObject = JsonSerializer.Deserialize<WrapperObject>(jsonSourceObject);

        Assert.Equal(sourceObject, deserializedObject);
    }
}