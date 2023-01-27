using System.Text.Json;

namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Dictionary<string, string>>?> GetFormWebhooksAsync(string formId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<JotformResult<Dictionary<string, string>>>($"form/{formId}/webhooks",
                _jsonSerializerOptions, cancellationToken);
        }
        catch (JsonException)
        {
            return new JotformResult<Dictionary<string, string>>();
        }
    }
}