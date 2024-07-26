namespace Jotform;

public partial class JotformClient
{
    // TODO: reponses parameter should be documented properly or better to make it strongly type.
    /// <summary>
    /// Add a submission (submit data) to the form.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="responses"></param>
    public async Task<JotformResult<PostFormSubmissionsResponse>?> PostFormSubmissionsAsync(string formId, Dictionary<string, string> responses, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();
        
        foreach (var (key, value) in responses)
        {
            formData.Add(key, value);
        }
        
        var response = await _httpClient.PostAsync($"form/{formId}/submissions", formData.Build(), cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<PostFormSubmissionsResponse>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}

#nullable disable
public class PostFormSubmissionsResponse
{
    [JsonPropertyName("submissionID")]
    public string SubmissionID { get; set; }

    [JsonPropertyName("URL")]
    public string URL { get; set; }
}