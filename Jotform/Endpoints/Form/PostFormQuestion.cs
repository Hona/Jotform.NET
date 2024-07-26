namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Question>?> PostFormQuestionAsync(string formId, string questionId, Dictionary<string, string> questionDefinition, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();
        
        foreach (var (key, value) in questionDefinition)
        {
            formData.Add(key, value);
        }
        
        var response = await _httpClient.PostAsync($"form/{formId}/question/{questionId}", formData.Build(), cancellationToken).ConfigureAwait(false);
        
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<JotformResult<Question>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}