using System.Text;
using System.Text.Json;

namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Models.Shared.Form>?> PutUserFormsAsync(object formDefinition, CancellationToken cancellationToken = default)
    {
        var formData = JsonSerializer.Serialize(formDefinition, _jsonSerializerOptions);
        
        var response = await _httpClient.PutAsync("user/forms", 
            new StringContent(formData, Encoding.UTF8, "application/json"), 
            cancellationToken: cancellationToken);

        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<JotformResult<Models.Shared.Form>>(_jsonSerializerOptions, cancellationToken);
    }
}