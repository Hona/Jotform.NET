using System.Text.Json;

namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Delete a webhook of a specific form
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="webhookId">Webhook ID.</param>
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