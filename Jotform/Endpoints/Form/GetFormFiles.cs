namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get a list of files uploaded on a form. Size and file type is also included.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    public Task<JotformResult<FormFile[]>?> GetFormFilesAsync(string formId, CancellationToken cancellationToken = default) 
        => GetResultAsync<FormFile[]>($"form/{formId}/files",
            cancellationToken);
}

public class FormFile
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("size")]
    public string Size { get; set; } = null!;

    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [JsonPropertyName("form_id")]
    public string FormId { get; set; } = null!;

    [JsonPropertyName("submission_id")]
    public string SubmissionId { get; set; } = null!;

    [JsonPropertyName("date")]
    public string Date { get; set; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;
}