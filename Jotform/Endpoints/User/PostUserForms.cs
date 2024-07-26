namespace Jotform;

public partial class JotformClient
{
    // TODO: formDefinition parameter should be documented properly or better to make it strongly type.
    /// <summary>
    /// Create a new form.
    /// Create new forms with questions, properties and email settings.
    /// </summary>
    /// <param name="formDefinition"></param>
    public async Task<JotformResult<Models.Shared.Form>?> PostUserFormsAsync(Dictionary<string, string> formDefinition, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();

        foreach (var (key, value) in formDefinition)
        {
            formData.Add(key, value);
        }
        
        var response = await _httpClient.PostAsync("user/forms", 
            formData.Build(), cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<JotformResult<Models.Shared.Form>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}