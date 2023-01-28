namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<string>?> DeleteSubmissionAsync(string submissionId, CancellationToken cancellationToken = default) 
        => await _httpClient.DeleteFromJsonAsync<JotformResult<string>>($"submission/{submissionId}", 
            _jsonSerializerOptions, cancellationToken);
}