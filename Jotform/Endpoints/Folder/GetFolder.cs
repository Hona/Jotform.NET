namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get a list of forms in a folder, and other details about the form such as folder color.
    /// </summary>
    /// <param name="folderId">Folder ID.</param>
    public Task<JotformResult<Folder>?> GetFolderAsync(string folderId, CancellationToken cancellationToken = default) 
        => GetResultAsync<Folder>($"folder/{folderId}",
            cancellationToken);
}