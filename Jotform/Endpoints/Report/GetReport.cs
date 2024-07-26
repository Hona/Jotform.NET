namespace Jotform;

public partial class JotformClient 
{
    /// <summary>
    /// Get more information about a data report.
    /// </summary>
    /// <param name="reportId">Report ID.</param>
    public Task<JotformResult<FormReport>?> GetReportAsync(string reportId, CancellationToken cancellationToken = default) 
        => GetResultAsync<FormReport>($"report/{reportId}",
            cancellationToken);
}