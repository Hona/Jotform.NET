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

#nullable disable
public class FormReport
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("form_id")]
    public string FormId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public object UpdatedAt { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("isProtected")]
    public bool? IsProtected { get; set; }

    [JsonPropertyName("fields")]
    public string Fields { get; set; }

    [JsonPropertyName("list_type")]
    public string ListType { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("settings")]
    public string Settings { get; set; }
}