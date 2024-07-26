namespace Jotform;

public partial class JotformClient
{
    // TODO: Sample response seems broken from the docs page, returning void for now.
    public async Task PutFormAsync(object formDefinition, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync("form", formDefinition, _jsonSerializerOptions, 
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
    }
}