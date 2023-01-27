namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<string>?> DeleteFormQuestionAsync(string formId, string questionId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"form/{formId}/question/{questionId}", cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<string>>(_jsonSerializerOptions, cancellationToken);
    }
}