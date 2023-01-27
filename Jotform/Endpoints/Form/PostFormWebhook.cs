using System.Text.Json;

namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Dictionary<string, string>>?> PostFormWebhookAsync(string formId, Uri webhookUrl, CancellationToken cancellationToken = default)
    {
        if (!webhookUrl.IsAbsoluteUri)
        {
            throw new ArgumentOutOfRangeException(nameof(webhookUrl), "Webhook must be an absolute URI");
        }
        
        var formData = new FormDataBuilder();
        
        formData.Add("webhookURL", webhookUrl.ToString());

        var response = await _httpClient.PostAsync($"form/{formId}/webhooks", formData.Build(), cancellationToken);
        
        response.EnsureSuccessStatusCode();

        try
        {
            return await response.Content.ReadFromJsonAsync<JotformResult<Dictionary<string, string>>>(_jsonSerializerOptions, cancellationToken);
        }
        catch (JsonException)
        {
            return new JotformResult<Dictionary<string, string>>();
        }
    }
}