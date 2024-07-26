namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get User Reports.
    /// List of URLS for reports in this account.Includes reports for all of the forms.ie.Excel, CSV, printable charts, embeddable HTML tables.
    /// </summary>
    public Task<JotformResult<GetUserReportsResponse[]>?> GetUserReportsAsync(CancellationToken cancellationToken = default)
        => GetResultAsync<GetUserReportsResponse[]>("user/reports",
            cancellationToken);
}

#nullable disable
public class GetUserReportsResponse
{
    /// <summary>
    /// id is report ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("form_id")]
    public string FormId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// created_at, updated_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    /// created_at, updated_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }

    /// <summary>
    /// fields is a comma separated list of all fields.
    /// </summary>
    [JsonPropertyName("fields")]
    public string Fields { get; set; }

    /// <summary>
    /// list_type can be excel, csv, grid, table, calendar, rss or visual.
    /// </summary>
    [JsonPropertyName("list_type")]
    public string ListType { get; set; }

    /// <summary>
    /// status can be ENABLED or DELETED
    /// </summary>
    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// isProtected is true if password protected
    /// </summary>
    [JsonPropertyName("isProtected")]
    public bool IsProtected { get; set; }
}