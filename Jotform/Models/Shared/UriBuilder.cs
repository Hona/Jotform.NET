using System.Runtime.CompilerServices;

namespace Jotform.Models.Shared;

public class UriBuilder
{
    private readonly string _baseUrl;
    private readonly Dictionary<string, string> _parameters = new();

    public UriBuilder(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public UriBuilder AddQuery(string parameter, object? value)
    {
        if (value?.ToString() is null)
        {
            return this;
        }

        _parameters[parameter] = value.ToString()!;

        return this;
    }
    public UriBuilder AddQuery(string parameter, string? value)
    {
        if (value is null)
        {
            return this;
        }

        _parameters[parameter] = value;

        return this;
    }

    public override string ToString()
    {
        var query = string.Join("&", _parameters.Select(x => $"{x.Key}={x.Value}"));

        if (string.IsNullOrWhiteSpace(query))
        {
            return _baseUrl;
        }
        
        return $"{_baseUrl}?{query}";
    }
}