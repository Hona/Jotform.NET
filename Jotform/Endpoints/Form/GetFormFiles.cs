namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<FormFile[]>?> GetFormFilesAsync(string formId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<JotformResult<FormFile[]>>($"form/{formId}/files", _jsonSerializerOptions, cancellationToken);
    }
}

public class FormFile
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("size")]
    public string Size { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("form_id")]
    public string FormId { get; set; }

    [JsonPropertyName("submission_id")]
    public string SubmissionId { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}