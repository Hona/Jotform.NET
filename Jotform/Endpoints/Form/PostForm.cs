namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Sample response seems broken from the docs page, return void for now
    /// </summary>
    /// <param name="formDefinition"></param>
    /// <param name="cancellationToken"></param>
    public async Task PostFormAsync(Dictionary<string, string> formDefinition, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();

        foreach (var (key, value) in formDefinition)
        {
            formData.Add(key, value);
        }
        
        var response = await _httpClient.PostAsync("form", 
            formData.Build(), cancellationToken: cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}