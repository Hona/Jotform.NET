namespace Jotform;

public partial class JotformClient
{
    // TODO: questionDefinition should be documented properly or better to make it strongly type.
    /// <summary>
    /// Add new question to specified form. Form questions might have various properties (https://api.jotform.com/docs/properties/index.php). Examples: Is it required? Are there any validations such as 'numeric only'?.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="questionDefinition"></param>
    public async Task<JotformResult<Question>?> PostFormQuestionsAsync(string formId, Dictionary<string, string> questionDefinition, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();
        
        foreach (var (key, value) in questionDefinition)
        {
            formData.Add(key, value);
        }

        var response = await _httpClient.PostAsJsonAsync($"form/{formId}/questions", formData, _jsonSerializerOptions, 
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<Question>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}