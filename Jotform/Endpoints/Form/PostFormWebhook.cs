using System.Text.Json;

namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Add a new webhook.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="webhookUrl">Webhook URL is where form data will be posted when form is submitted. Example: http://my.web.tld/handle.php</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<JotformResult<Dictionary<string, string>>?> PostFormWebhookAsync(string formId, Uri webhookUrl, CancellationToken cancellationToken = default)
    {
        if (!webhookUrl.IsAbsoluteUri)
        {
            throw new ArgumentOutOfRangeException(nameof(webhookUrl), "Webhook must be an absolute URI");
        }
        
        var formData = new FormDataBuilder();
        
        formData.Add("webhookURL", webhookUrl.ToString());

        var response = await _httpClient.PostAsync($"form/{formId}/webhooks", formData.Build(), cancellationToken)
            .ConfigureAwait(false);
        
        response.EnsureSuccessStatusCode();

        try
        {
            return await response.Content.ReadFromJsonAsync<JotformResult<Dictionary<string, string>>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
        catch (JsonException)
        {
            return new JotformResult<Dictionary<string, string>>();
        }
    }
}