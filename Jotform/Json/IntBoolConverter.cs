using System.Text.Json;

namespace Jotform.Json;

public class IntBoolConverter : JsonConverter<bool>
{
    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) =>
        writer.WriteBooleanValue(value);
    
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.True:
                return true;
            case JsonTokenType.False:
                return false;
            case JsonTokenType.String:
                var stringRead = reader.GetString();
                // "1" or "0", then "Yes" or "No"
                return int.TryParse(stringRead, out var i) ? Convert.ToBoolean(i) 
                    : TryFromYesNoString(stringRead, out var yn) 
                        ? yn : throw new JsonException();
                
            case JsonTokenType.Number:
                return reader.TryGetInt64(out long l) ? Convert.ToBoolean(l) : reader.TryGetDouble(out var d) && Convert.ToBoolean(d);
            default:
                throw new JsonException();
        }
    }

    private static bool TryFromYesNoString(string? value, out bool result)
    {
        if (value is null)
        {
            result = default;
            return false;
        }
        
        if (value.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            result = true;
            return true;
        }

        if (value.Equals("no", StringComparison.OrdinalIgnoreCase))
        {
            result = false;
            return true;
        }
        
        result = default;
        return false;
    }
}