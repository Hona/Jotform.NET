using System.Text.Json;

namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get a list of webhooks for a form.
    /// </summary>
    /// <remarks>Webhooks can be used to send form submission data as an instant notification.</remarks>
    /// <param name="formId">Form ID.</param>
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