namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<HistoryLog[]>?> GetUserHistoryAsync(HistoryAction? action = null, HistoryDate? date = null, string? startDate = null, string? endDate = null,
        CancellationToken cancellationToken = default)
    {
        var url = new UriBuilder("user/history")
            .AddQuery("action", action)
            .AddQuery("date", date)
            .AddQuery("startDate", startDate)
            .AddQuery("endDate", endDate)
            .ToString();

        return await _httpClient.GetFromJsonAsync<JotformResult<HistoryLog[]>>(url, _jsonSerializerOptions, cancellationToken);
    }
}

public enum HistoryAction
{
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
    public string Type { get; set; }

    [JsonPropertyName("formID")]
    public string FormID { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("formTitle")]
    public string FormTitle { get; set; }

    [JsonPropertyName("formStatus")]
    public string FormStatus { get; set; }

    [JsonPropertyName("ip")]
    public string Ip { get; set; }

    /// <summary>
    /// timestamp is number of seconds since Jan 1st, 1970.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }
}

