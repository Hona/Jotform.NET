namespace Jotform;

public partial class JotformClient 
{
    public async Task<JotformResult<PostFormSubmissionsResponse>?> PostSubmissionAsync(string submissionId, Dictionary<string, string> responses, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();
        
        foreach (var (key, value) in responses)
        {
            formData.Add(key, value);
        }
        
        var response = await _httpClient.PostAsync($"submission/{submissionId}", formData.Build(), cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<PostFormSubmissionsResponse>>(_jsonSerializerOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}