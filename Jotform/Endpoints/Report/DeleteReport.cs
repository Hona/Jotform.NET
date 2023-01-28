namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<string>?> DeleteReportAsync(string reportId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"report/{reportId}", cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<string>>(_jsonSerializerOptions, cancellationToken);
    }
}