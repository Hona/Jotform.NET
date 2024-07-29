namespace Jotform;

public partial class JotformClient
{
    // TODO: formDefinition parameter should be documented properly or better to make it strongly type.
    /// <summary>
    /// Create new forms.
    /// Create new forms with questions, properties and email settings.
    /// </summary>
    /// <param name="formDefinition"></param>
    public async Task<JotformResult<Models.Shared.Form>?> PutUserFormsAsync(object formDefinition, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync("user/forms", formDefinition, _jsonSerializerOptions,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<Models.Shared.Form>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}