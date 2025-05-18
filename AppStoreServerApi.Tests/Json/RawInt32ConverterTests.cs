using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Tests.Json;

public class RawInt32ConverterTests
{
    [JsonConverter(typeof(RawInt32Converter<RawInt32Type>))]
    public record RawInt32Type(int RawValue) : IRawInt32<RawInt32Type>
    {
        static RawInt32Type IRawInt32<RawInt32Type>.FromRaw(int rawValue) => new(rawValue);
        int IRawInt32<RawInt32Type>.IntoRaw() => RawValue;
    }

    public record WrapperObject(
        [property: JsonPropertyName("inner")] RawInt32Type Inner
    );

    [Fact]
    public void RawInt32Converter_SerializeAndDeserialize_Correct()
    {
        const string desiredJsonSourceObject = @"{""inner"":100500}";

        var sourceObject = new WrapperObject(new RawInt32Type(100500));

        var jsonSourceObject = JsonSerializer.Serialize(sourceObject);

        Assert.Equal(desiredJsonSourceObject, jsonSourceObject);

        var deserializedObject = JsonSerializer.Deserialize<WrapperObject>(jsonSourceObject);

        Assert.Equal(sourceObject, deserializedObject);
    }
}