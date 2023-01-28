namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<FormSubmission>?> GetSubmissionAsync(string submissionId, CancellationToken cancellationToken = default) 
        => await _httpClient.GetFromJsonAsync<JotformResult<FormSubmission>>($"submission/{submissionId}", 
            _jsonSerializerOptions, cancellationToken);
}