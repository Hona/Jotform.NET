using System.Text.Json;

namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Dictionary<string, string>>?> DeleteFormWebhookAsync(string formId, string webhookId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"form/{formId}/webhooks/{webhookId}", cancellationToken)
            .ConfigureAwait(false);
        
        response.EnsureSuccessStatusCode();

        try
        {
            return await response.Content.ReadFromJsonAsync<JotformResult<Dictionary<string, string>>>(_jsonSerializerOptions, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (JsonException)
        {
            return new JotformResult<Dictionary<string, string>>();
        }
    }
}