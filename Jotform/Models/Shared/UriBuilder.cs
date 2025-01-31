using System.Reflection;

namespace Jotform.Models.Shared;

public class UriBuilder
{
    private readonly string _baseUrl;
    private readonly Dictionary<string, string> _parameters = new();

    public UriBuilder(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public UriBuilder AddQuery<TValue>(string parameter, TValue? value)
    {
        if (value is null) return this;

            
        // Instead of .ToString we want the JSON specified serialisation
        // e.g. instead of 'LastWeek' we want 'lastWeek'
        var stringValue = value is Enum enumValue 
            ? enumValue.GetType().GetField(enumValue.ToString())?.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name 
              ?? value.GetType().GetCustomAttribute<JsonPropertyNameAttribute>()?.Name
              ?? value.ToString()
            : value.GetType().GetCustomAttribute<JsonPropertyNameAttribute>()?.Name 
              ?? value.ToString();

        if (string.IsNullOrWhiteSpace(stringValue)) return this;
        _parameters[parameter] = stringValue;
        return this;
    }

    public override string ToString()
    {
        if (_parameters.Count == 0) return _baseUrl;

        var query = string.Join("&", _parameters.Select(x => $"{x.Key}={x.Value}"));

        return $"{_baseUrl}?{query}";
    }
}