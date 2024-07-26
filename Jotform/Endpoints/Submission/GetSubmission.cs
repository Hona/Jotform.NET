namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get Submission Data.
    /// </summary>
    /// <param name="submissionId">Submission ID.</param>
    public Task<JotformResult<FormSubmission>?> GetSubmissionAsync(string submissionId, CancellationToken cancellationToken = default) 
        => GetResultAsync<FormSubmission>($"submission/{submissionId}",
            cancellationToken);
}