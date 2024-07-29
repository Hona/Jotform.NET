namespace Jotform;

public partial class JotformClient 
{
    // TODO: formProperties parameter should be documented properly or better to make it strongly type.
    /// <summary>
    /// Add or edit properties of a specific form
    /// </summary>
    /// <param name="formId">Form ID></param>
    /// <param name="formProperties"></param>
    public async Task<JotformResult<FormProperties>?> PutFormPropertiesAsync(string formId, object formProperties, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"form/{formId}/properties", formProperties, _jsonSerializerOptions, 
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<JotformResult<FormProperties>>(_jsonSerializerOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}