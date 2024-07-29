namespace Jotform.Models.Shared;

public class Form
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = null!;

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; } = null!;

    [JsonPropertyName("last_submission")]
    public string LastSubmission { get; set; } = null!;

    [JsonPropertyName("new")]
    public int New { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("type")]
    public FormType Type { get; set; }

    [JsonPropertyName("favorite")]
    public bool Favorite { get; set; }

    [JsonPropertyName("archived")]
    public bool Archived { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;
    
}

public enum FormType
{
    Legacy,
    Card
}