namespace Jotform;

public partial class JotformClient
{
    public Task<JotformResult<string>?> DeleteSubmissionAsync(string submissionId, CancellationToken cancellationToken = default) 
        => _httpClient.DeleteFromJsonAsync<JotformResult<string>>($"submission/{submissionId}", 
            _jsonSerializerOptions, cancellationToken);
}