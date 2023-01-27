namespace Jotform;

public partial class JotformClient 
{
    public async Task<JotformResult<FormProperties>?> PutFormPropertiesAsync(string formId, object formProperties, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"form/{formId}/properties", formProperties, _jsonSerializerOptions, 
            cancellationToken: cancellationToken);

        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<JotformResult<FormProperties>>(_jsonSerializerOptions, cancellationToken: cancellationToken);
    }
}