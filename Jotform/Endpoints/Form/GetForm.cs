namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Models.Shared.Form>?> GetFormAsync(string formId, CancellationToken cancellationToken = default) 
        => await _httpClient.GetFromJsonAsync<JotformResult<Models.Shared.Form>>($"form/{formId}", 
            _jsonSerializerOptions, cancellationToken: cancellationToken);
}