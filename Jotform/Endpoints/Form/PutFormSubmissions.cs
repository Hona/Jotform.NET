namespace Jotform;

public partial class JotformClient 
{
    // TODO: reponses parameter should be documented properly or better to make it strongly type.
    /// <summary>
    /// Add submissions to the form.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="responses"></param>
    public async Task<JotformResult<PostFormSubmissionsResponse[]>?> PutFormSubmissionsAsync(string formId, object responses, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"form/{formId}/submissions", responses, _jsonSerializerOptions, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<PostFormSubmissionsResponse[]>>(_jsonSerializerOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}