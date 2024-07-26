namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Update a folder with specified parameters. Also you can add forms to the folder.
    /// </summary>
    /// <param name="folderId">ID of the folder.</param>
    /// <param name="folder">FolderContent e.g. Name, color, parent of the specified folder. Also you can move forms to the specified folder.</param>
    public async Task<JotformResult<object>?> PutFolderAsync(string folderId, object folder, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync($"folder/{folderId}", folder, cancellationToken)
            .ConfigureAwait(false);
        
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<JotformResult<object>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}