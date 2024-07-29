namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get a list of form responses, answers array has the submitted data, Created_at is the date of the submission.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="offset">Start of each result set for form list. Useful for pagination. Default is 0. Example: 20</param>
    /// <param name="limit">Number of results in each result set for form list. Default is 20. Maximum is 1000. Example: 30</param>
    /// <param name="filter">Filters the query results to fetch a specific submissions range. Example: {"id:gt":"31974353596870" You can also use gt(greater than), lt(less than), ne(not equal to) commands to get more advanced filtering : Example: {"created_at:gt":"2013-01-01 00:00:00"} Example: {"workflowStatus:ne":"Approve"}</param>
    /// <param name="orderBy">Order results by a form field name.</param>
    public Task<PagedJotformResult<FormSubmission>?> GetFormSubmissionsAsync(string formId, int? offset = null, int? limit = null, string? filter = null, string? orderBy = null, CancellationToken cancellationToken = default)
    {
        var url = new UriBuilder($"form/{formId}/submissions")
            .AddQuery("offset", offset)
            .AddQuery("limit", limit)
            .AddQuery("filter", filter)
            .AddQuery("orderby", orderBy);

        return GetPagedResultAsync<FormSubmission>(url.ToString(),
            cancellationToken);
    }
}

public class FormSubmission
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("form_id")]
    public string FormId { get; set; } = null!;

    [JsonPropertyName("ip")]
    public string Ip { get; set; } = null!;

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = null!;

    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("new")]
    public bool New { get; set; }

    [JsonPropertyName("flag")]
    public bool Flag { get; set; }

    [JsonPropertyName("notes")]
    public string Notes { get; set; } = null!;

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; } = null!;

    [JsonPropertyName("answers")]
    public Dictionary<string, Answer>? Answers { get; set; }
}