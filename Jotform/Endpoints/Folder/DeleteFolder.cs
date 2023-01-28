namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<string>?> DeleteFolderAsync(string folderId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"folder/{folderId}", cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<string>>(_jsonSerializerOptions, cancellationToken);
    }
}