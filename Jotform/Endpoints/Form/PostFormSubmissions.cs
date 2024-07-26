namespace Jotform;

public partial class JotformClient
{
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