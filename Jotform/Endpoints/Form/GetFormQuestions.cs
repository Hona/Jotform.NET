namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Dictionary<string, Question>>?> GetFormQuestionsAsync(string formId, CancellationToken cancellationToken = default) 
        => await _httpClient.GetFromJsonAsync<JotformResult<Dictionary<string, Question>>>($"form/{formId}/questions",
            _jsonSerializerOptions, cancellationToken: cancellationToken);
}