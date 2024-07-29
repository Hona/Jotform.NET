namespace Jotform;

public partial class JotformClient
{
    // TODO: Sample response seems broken from the docs page, returning void for now.
    public async Task PostFormAsync(Dictionary<string, string> formDefinition, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();

        foreach (var (key, value) in formDefinition)
        {
            formData.Add(key, value);
        }
        
        var response = await _httpClient.PostAsync("form", 
            formData.Build(), cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
    }
}