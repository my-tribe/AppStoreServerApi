using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Tests.Models;

public class RawStringModelsTests
{
    [Theory]
    [MemberData(nameof(RawStringTypes))]
    public void RawString_Conversion_ShouldBeSymmetric(Type valueType)
    {
        var method = typeof(RawStringModelsTests)
            .GetMethod(nameof(AssertRawStringConversionIsSymmetric), BindingFlags.NonPublic | BindingFlags.Static)!
            .MakeGenericMethod(valueType);
        method.Invoke(null, null);
    }

    [Theory]
    [MemberData(nameof(RawStringTypes))]
    public void RawString_Serialization_ShouldBeSymmetryc(Type valueType)
    {
        var method = typeof(RawStringModelsTests)
            .GetMethod(nameof(AssertRawStringSerialization), BindingFlags.NonPublic | BindingFlags.Static)!
            .MakeGenericMethod(valueType);
        method.Invoke(null, null);
    }

    private static void AssertRawStringConversionIsSymmetric<T>() where T : class, IRawString<T>
    {
        const string validValue = "valid_value";
        var instance = T.FromRaw(validValue);
        var rawValue = instance.IntoRaw();
        Assert.Equal(validValue, rawValue);
    }

    private record Wrapper<T>(
        [property: JsonPropertyName("inner")] T Inner);
    private static void AssertRawStringSerialization<T>() where T : class, IRawString<T>
    {
        const string jsonValue = @"{""inner"":""valid_value""}";
        var deserializedObject = JsonSerializer.Deserialize<Wrapper<T>>(jsonValue);
        var serializedJsonValue = JsonSerializer.Serialize(deserializedObject);
        Assert.Equal(jsonValue, serializedJsonValue);
    }

    public static IEnumerable<object[]> RawStringTypes => GetRawStringTypes();
    private static IEnumerable<object[]> GetRawStringTypes()
    {
        var interfaceType = typeof(IRawString<>);
        var assembly = typeof(IRawString<>).Assembly;

        return assembly
            .GetTypes()
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .Where(t =>
                t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType
                ))
            .Select(t => new object[] { t });
    }

}