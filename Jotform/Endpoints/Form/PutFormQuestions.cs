namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Add new questions to specified form. Form questions might have various properties (https://api.jotform.com/docs/properties/index.php). Examples: Is it required? Are there any validations such as 'numeric only'?.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="questions">New question's properties (https://api.jotform.com/docs/properties/index.php).</param>
    public async Task<JotformResult<Dictionary<string, Question>>?> PutFormQuestionsAsync(string formId, object questions, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"form/{formId}/questions", questions, _jsonSerializerOptions, 
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<Dictionary<string, Question>>>(_jsonSerializerOptions, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }
}