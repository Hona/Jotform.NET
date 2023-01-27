namespace Jotform;

public partial class JotformClient 
{
    public async Task<JotformResult<PostFormSubmissionsResponse[]>?> PutFormSubmissionsAsync(string formId, object responses, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"form/{formId}/submissions", responses, _jsonSerializerOptions, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<PostFormSubmissionsResponse[]>>(_jsonSerializerOptions, cancellationToken: cancellationToken);
    }
}