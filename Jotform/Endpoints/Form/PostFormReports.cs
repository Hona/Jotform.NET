namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Create new report of a form with intended fields, type and title.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="reportTitle">Report title.</param>
    /// <param name="listType">Report type</param>
    /// <param name="fields">Report fields. e.g. User IP, submission date(dt) and question IDs.</param>
    public async Task<JotformResult<FormReport>?> PostFormReportsAsync(string formId, string reportTitle, ListType listType, string[]? fields, CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder();
        
        formData.Add("title", reportTitle);
        formData.Add("list_type", listType.ToString());

        if (fields is not null)
        {
            formData.Add("fields", string.Join(",", fields));
        }
        
        var response = await _httpClient.PostAsync($"form/{formId}/reports", formData.Build(), cancellationToken)
            .ConfigureAwait(false);
        
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<FormReport>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}

public enum ListType
{
    CSV,
    Excel,
    Grid,
    Table,
    RSS
}