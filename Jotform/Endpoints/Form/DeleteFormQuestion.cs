namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Delete a single form question.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="questionId">Question ID.</param>
    public async Task<JotformResult<string>?> DeleteFormQuestionAsync(string formId, string questionId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"form/{formId}/question/{questionId}", cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<string>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}