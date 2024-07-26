namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Delete a folder and its subfolders.
    /// </summary>
    /// <param name="folderId">ID of the folder.</param>
    public async Task<JotformResult<string>?> DeleteFolderAsync(string folderId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"folder/{folderId}", cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<string>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}