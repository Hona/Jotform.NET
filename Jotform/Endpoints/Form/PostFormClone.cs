namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Models.Shared.Form>?> PostFormCloneAsync(string formId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync($"form/{formId}/clone", content: null, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<Models.Shared.Form>>(_jsonSerializerOptions, cancellationToken);
    }
}