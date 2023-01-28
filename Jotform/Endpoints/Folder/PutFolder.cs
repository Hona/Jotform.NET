namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<object>?> PutFolderAsync(string folderId, object folder, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"folder/{folderId}", folder, cancellationToken);
        
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<JotformResult<object>>(_jsonSerializerOptions, cancellationToken);
    }
}