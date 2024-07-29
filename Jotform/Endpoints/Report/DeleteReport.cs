namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Delete an existing report.
    /// </summary>
    /// <param name="reportId">Report ID.</param>
    public async Task<JotformResult<string>?> DeleteReportAsync(string reportId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"report/{reportId}", cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<string>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}