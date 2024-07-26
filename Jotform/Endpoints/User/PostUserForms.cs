namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Models.Shared.Form>?> PostUserFormsAsync(Dictionary<string, string> formDefinition, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();

        foreach (var (key, value) in formDefinition)
        {
            formData.Add(key, value);
        }
        
        var response = await _httpClient.PostAsync("user/forms", 
            formData.Build(), cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<JotformResult<Models.Shared.Form>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}