namespace Jotform;

public partial class JotformClient
{
    public Task<JotformResult<FormSubmission>?> GetSubmissionAsync(string submissionId, CancellationToken cancellationToken = default) 
        => GetResultAsync<FormSubmission>($"submission/{submissionId}",
            cancellationToken);
}