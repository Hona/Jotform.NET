namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Question>?> GetFormQuestionAsync(string formId, string questionId, CancellationToken cancellationToken = default) 
        => await _httpClient.GetFromJsonAsync<JotformResult<Question>>($"form/{formId}/question/{questionId}", 
            _jsonSerializerOptions, cancellationToken);
}