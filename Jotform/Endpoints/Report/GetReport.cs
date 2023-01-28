namespace Jotform;

public partial class JotformClient 
{
    public async Task<JotformResult<FormReport>?> GetReportAsync(string reportId, CancellationToken cancellationToken = default) 
        => await _httpClient.GetFromJsonAsync<JotformResult<FormReport>>($"report/{reportId}", 
            _jsonSerializerOptions, cancellationToken);
}