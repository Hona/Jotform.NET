using System.Text.Json;

namespace Jotform.Json;

public class IntBoolConverter : JsonConverter<bool>
{
    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) =>
        writer.WriteBooleanValue(value);
    
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType switch
        {
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.String => int.TryParse(reader.GetString(), out var i) ? Convert.ToBoolean(i) : throw new JsonException(),
            JsonTokenType.Number => reader.TryGetInt64(out long l) ? Convert.ToBoolean(l) : reader.TryGetDouble(out var d) && Convert.ToBoolean(d),
            _ => throw new JsonException(),
        };
}