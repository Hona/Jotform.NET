namespace Jotform;

public partial class JotformClient 
{
    public Task<JotformResult<FormReport>?> GetReportAsync(string reportId, CancellationToken cancellationToken = default) 
        => GetResultAsync<FormReport>($"report/{reportId}",
            cancellationToken);
}