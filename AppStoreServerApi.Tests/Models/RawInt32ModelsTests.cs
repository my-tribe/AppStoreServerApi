using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Tests.Models;

public class RawInt32ModelsTests
{
    [Theory]
    [MemberData(nameof(RawInt32Types))]
    public void RawInt32_Conversion_ShouldBeSymmetric(Type valueType)
    {
        var method = typeof(RawInt32ModelsTests)
            .GetMethod(nameof(AssertRawInt32ConversionIsSymmetric), BindingFlags.NonPublic | BindingFlags.Static)!
            .MakeGenericMethod(valueType);
        method.Invoke(null, null);
    }

    [Theory]
    [MemberData(nameof(RawInt32Types))]
    public void RawInt32_Serialization_ShouldBeSymmetryc(Type valueType)
    {
        var method = typeof(RawInt32ModelsTests)
            .GetMethod(nameof(AssertRawInt32Serialization), BindingFlags.NonPublic | BindingFlags.Static)!
            .MakeGenericMethod(valueType);
        method.Invoke(null, null);
    }

    private static void AssertRawInt32ConversionIsSymmetric<T>() where T : class, IRawInt32<T>
    {
        const int validValue = 100500;
        var instance = T.FromRaw(validValue);
        var rawValue = instance.IntoRaw();
        Assert.Equal(validValue, rawValue);
    }

    private record Wrapper<T>(
        [property: JsonPropertyName("inner")] T Inner);
    private static void AssertRawInt32Serialization<T>() where T : class, IRawInt32<T>
    {
        const string jsonValue = @"{""inner"":100500}";
        var deserializedObject = JsonSerializer.Deserialize<Wrapper<T>>(jsonValue);
        var serializedJsonValue = JsonSerializer.Serialize(deserializedObject);
        Assert.Equal(jsonValue, serializedJsonValue);
    }

    public static IEnumerable<object[]> RawInt32Types => GetRawInt32Types();
    private static IEnumerable<object[]> GetRawInt32Types()
    {
        var interfaceType = typeof(IRawInt32<>);
        var assembly = typeof(IRawInt32<>).Assembly;

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