namespace Jotform.Models.Shared;

public class FormDataBuilder
{
    private readonly Dictionary<string, string> _dictionary = new();

    public FormDataBuilder Add(string key, object? value)
    {
        if (value?.ToString() is null)
        {
            return this;
        }

        _dictionary[key] = value.ToString()!;

        return this;
    }
    
    public MultipartFormDataContent Build()
    {
        var content = new MultipartFormDataContent();
        foreach (var (key, value) in _dictionary)
        {
            content.Add(new StringContent(value), key);
        }

        return content;
    }
}