namespace Jotform.Models.Shared;

public class PaginationInfo
{
    [JsonPropertyName("offset")]
    public int Offset { get; set; }
    [JsonPropertyName("limit")]
    public int Limit { get; set; }
    [JsonPropertyName("orderby")]
    public string OrderBy { get; set; } = null!;
    [JsonPropertyName("filter")]
    public object? Filter { get; set; }
    [JsonPropertyName("count")]
    public int Count { get; set; }
}