namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<Folder>?> GetFolderAsync(string folderId, CancellationToken cancellationToken = default) 
        => await _httpClient.GetFromJsonAsync<JotformResult<Folder>>($"folder/{folderId}", 
            _jsonSerializerOptions, cancellationToken);
}