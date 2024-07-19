namespace Jotform;

public partial class JotformClient
{
    public Task<JotformResult<Folder>?> GetFolderAsync(string folderId, CancellationToken cancellationToken = default) 
        => GetResultAsync<Folder>($"folder/{folderId}",
            cancellationToken);
}