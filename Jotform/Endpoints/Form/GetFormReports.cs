namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get all the reports of a specific form.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    public Task<JotformResult<FormReport[]>?> GetFormReportsAsync(string formId, CancellationToken cancellationToken = default) 
        => GetResultAsync<FormReport[]>($"form/{formId}/reports",
            cancellationToken);
}

public class FormReport
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("form_id")]
    public string FormId { get; set; } = null!;

    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = null!;

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;

    [JsonPropertyName("isProtected")]
    public bool? IsProtected { get; set; }

    [JsonPropertyName("fields")]
    public string Fields { get; set; } = null!;

    [JsonPropertyName("list_type")]
    public string ListType { get; set; } = null!;

    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("settings")]
    public string Settings { get; set; } = null!;
}