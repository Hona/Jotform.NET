namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<FormProperties>?> PostFormPropertiesAsync(string formId, Dictionary<string, string> properties, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();
        
        foreach (var (key, value) in properties)
        {
            formData.Add(key, value);
        }
        
        var response = await _httpClient.PostAsync($"form/{formId}/properties", formData.Build(), cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<FormProperties>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}