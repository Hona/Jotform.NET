namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get History.
    /// User activity log about things like forms created/modified/deleted, account logins and other operations.
    /// </summary>
    /// <param name="action">Filter results by activity performed. Default is 'all'.</param>
    /// <param name="date">Limit results by a date range. If you'd like to limit results by specific dates you can use startDate and endDate fields instead. Example: lastWeek</param>
    /// <param name="startDate">Limit results to only after a specific date. Format: MM/DD/YYYY. Example: 01/31/2013</param>
    /// <param name="endDate">Limit results to only before a specific date. Format: MM/DD/YYYY. Example: 12/31/2013</param>
    public Task<JotformResult<HistoryLog[]>?> GetUserHistoryAsync(HistoryAction? action = HistoryAction.All, HistoryDate? date = HistoryDate.LastWeek, string? startDate = null, string? endDate = null,
        CancellationToken cancellationToken = default)
    {
        var url = new UriBuilder("user/history")
            .AddQuery("action", action)
            .AddQuery("date", date)
            .AddQuery("startDate", startDate)
            .AddQuery("endDate", endDate)
            .ToString();

        return GetResultAsync<HistoryLog[]>(url, cancellationToken);
    }
}

public enum HistoryAction
{
    [JsonPropertyName("all")]
    All,
    [JsonPropertyName("userCreation")]
    UserCreation,
    [JsonPropertyName("userLogin")]
    UserLogin,
    [JsonPropertyName("formCreation")]
    FormCreation,
    [JsonPropertyName("formUpdate")]
    FormUpdate,
    [JsonPropertyName("formDelete")]
    FormDelete,
    [JsonPropertyName("formPurge")]
    FormPurge
}

public enum HistoryDate
{
    [JsonPropertyName("lastWeek")]
    LastWeek,
    [JsonPropertyName("lastMonth")]
    LastMonth,
    [JsonPropertyName("last3Months")]
    Last3Months,
    [JsonPropertyName("last6Months")]
    Last6Months,
    [JsonPropertyName("lastYear")]
    LastYear,
    [JsonPropertyName("all")]
    All
}

public enum SortBy
{
    [JsonPropertyName("ASC")]
    Ascending,
    [JsonPropertyName("DESC")]
    Descending
}

public class HistoryLog
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("formID")]
    public string FormID { get; set; } = null!;

    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [JsonPropertyName("formTitle")]
    public string FormTitle { get; set; } = null!;

    [JsonPropertyName("formStatus")]
    public string FormStatus { get; set; } = null!;

    [JsonPropertyName("ip")]
    public string Ip { get; set; } = null!;

    /// <summary>
    /// timestamp is number of seconds since Jan 1st, 1970.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }
}