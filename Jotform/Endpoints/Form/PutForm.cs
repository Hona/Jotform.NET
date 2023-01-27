namespace Jotform;

public partial class JotformClient
{
    public async Task PutFormAsync(object formDefinition, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync("form", formDefinition, _jsonSerializerOptions, 
            cancellationToken: cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}