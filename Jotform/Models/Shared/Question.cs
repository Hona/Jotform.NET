namespace Jotform.Models.Shared;

public class Question
{
    [JsonPropertyName("hint")]
    public string? Hint { get; set; }

    [JsonPropertyName("labelAlign")]
    public string? LabelAlign { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("qid")]
    public string Qid { get; set; } = string.Empty;

    [JsonPropertyName("readonly")]
    public bool? Readonly { get; set; }

    [JsonPropertyName("required")]
    public bool Required { get; set; }

    [JsonPropertyName("shrink")]
    public bool? Shrink { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// TODO: Move to enum, once all types are known... Build an example form with all types then run GET?
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// TODO: Possibly move to bool, maybe enum, only know 'None' as a value for now 
    /// </summary>
    [JsonPropertyName("validation")]
    public string? Validation { get; set; }

    [JsonPropertyName("middle")]
    public bool? Middle { get; set; }

    [JsonPropertyName("prefix")]
    public bool? Prefix { get; set; }

    /// <summary>
    /// Can be object Sublabels, or a serialized string of Sublabels
    /// </summary>
    [JsonPropertyName("sublabels")]
    public object? Sublabels { get; set; }

    [JsonPropertyName("suffix")]
    public bool? Suffix { get; set; }

    [JsonPropertyName("cols")]
    public int? Cols { get; set; }

    /// <summary>
    /// TODO: What even is this, only know value: 'None-0'...
    /// </summary>
    [JsonPropertyName("entryLimit")]
    public string? EntryLimit { get; set; }

    [JsonPropertyName("rows")]
    public int? Rows { get; set; }
}

#nullable disable
public class Sublabels
{
    [JsonPropertyName("prefix")]
    public string Prefix { get; set; }

    [JsonPropertyName("first")]
    public string First { get; set; }

    [JsonPropertyName("middle")]
    public string Middle { get; set; }

    [JsonPropertyName("last")]
    public string Last { get; set; }

    [JsonPropertyName("suffix")]
    public string Suffix { get; set; }
}