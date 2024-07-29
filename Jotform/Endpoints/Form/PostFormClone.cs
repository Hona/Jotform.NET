namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Clone a single form.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    public async Task<JotformResult<Models.Shared.Form>?> PostFormCloneAsync(string formId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync($"form/{formId}/clone", content: null, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<Models.Shared.Form>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}