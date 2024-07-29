namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Create a folder with specified parameters.
    /// </summary>
    /// <param name="folderName">Name of the folder.</param>
    /// <param name="parentId">Parent id of the folder to be created.</param>
    /// <param name="colorHex">Color of the folder Example: #FFFFFF</param>
    public async Task<JotformResult<Folder>?> PostFolderAsync(string folderName, string? parentId = null, string? colorHex = null, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();
        
        formData.Add("name", folderName);
        formData.Add("parent", parentId);
        formData.Add("color", colorHex);
        
        var response = await _httpClient.PostAsync("folder", formData.Build(), cancellationToken)
            .ConfigureAwait(false);
        
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<JotformResult<Folder>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}