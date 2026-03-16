using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Enjna.AppStoreServerLibrary;

/// <summary>
/// A JSON converter for enums that uses <see cref="EnumMemberAttribute"/> values for serialization.
/// This is needed because <see cref="JsonStringEnumConverter{TEnum}"/> does not support
/// <see cref="EnumMemberAttribute"/> in .NET 8.
/// </summary>
internal sealed class JsonEnumMemberConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
{
    private static readonly Dictionary<string, TEnum> NameToValue = new(StringComparer.OrdinalIgnoreCase);
    private static readonly Dictionary<TEnum, string> ValueToName = new();

    static JsonEnumMemberConverter()
    {
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var value = (TEnum)field.GetValue(null)!;
            var attr = field.GetCustomAttribute<EnumMemberAttribute>();
            var name = attr?.Value ?? field.Name;
            NameToValue[name] = value;
            ValueToName[value] = name;
        }
    }

    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var str = reader.GetString()!;
            if (NameToValue.TryGetValue(str, out var value))
            {
                return value;
            }
        }
        else if (reader.TokenType == JsonTokenType.Number)
        {
            var intValue = reader.GetInt32();
            return (TEnum)Enum.ToObject(typeof(TEnum), intValue);
        }

        throw new JsonException($"Unable to convert \"{reader.GetString()}\" to {typeof(TEnum)}");
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        if (ValueToName.TryGetValue(value, out var name))
        {
            writer.WriteStringValue(name);
        }
        else
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
