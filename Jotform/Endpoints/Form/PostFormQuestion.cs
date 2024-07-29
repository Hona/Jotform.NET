namespace Jotform;

public partial class JotformClient
{
    // TODO: questionDefinition should be documented properly or better to make it strongly type.
    /// <summary>
    /// Add or edit a single question properties.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="questionId">Question ID.</param>
    /// <param name="questionDefinition"></param>
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