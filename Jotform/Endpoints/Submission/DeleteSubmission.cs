namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Delete a single submission.
    /// </summary>
    /// <param name="submissionId">Submission ID.</param>
    public Task<JotformResult<string>?> DeleteSubmissionAsync(string submissionId, CancellationToken cancellationToken = default) 
        => _httpClient.DeleteFromJsonAsync<JotformResult<string>>($"submission/{submissionId}", 
            _jsonSerializerOptions, cancellationToken);
}