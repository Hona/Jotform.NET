namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get User Submissions
    /// Get a list of all submissions for all forms on this account. The answers array has the submission data. Created_at is the date of the submission.
    /// </summary>
    public Task<PagedJotformResult<GetUserSubmissionsResponse>?> GetUserSubmissionsAsync(int? offset = null, int? limit = null, string? filter = null, string? orderBy = null, CancellationToken cancellationToken = default)
    {
        var url = new UriBuilder("user/submissions")
            .AddQuery("offset", offset)
            .AddQuery("limit", limit)
            .AddQuery("filter", filter)
            .AddQuery("orderby", orderBy);

        return GetPagedResultAsync<GetUserSubmissionsResponse>(
            url.ToString(), cancellationToken);
    }
}

public class Answer
{
    /// <summary>
    /// text is the question label on the form
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    /// type is the question type such as textbox or dropdown
    /// Most commonly used types are control_textbox, control_textarea, control_dropdown control_radio, control_checkbox, control_fileupload, control_fullname, control_email and control_datetime. Full List https://www.jotform.com/help/46-quick-overview-of-form-fields/
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// answer is the actual entry made by the submitter
    /// </summary>
    [JsonPropertyName("answer")]
    public object Response { get; set; }
    
    [JsonPropertyName("prettyFormat")]
    public string? PrettyFormat { get; set; }
}

public class GetUserSubmissionsResponse
{
    /// <summary>
    /// id is the Submission ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("form_id")]
    public string FormId { get; set; }

    /// <summary>
    /// ip address of the submitter
    /// </summary>
    [JsonPropertyName("ip")]
    public string Ip { get; set; }

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
    /// status can be ACTIVE or OVERQUOTA
    /// </summary>
    [JsonPropertyName("status")]
    public Status Status { get; set; }

    /// <summary>
    /// new is 1 if this submission is not read
    /// </summary>
    [JsonPropertyName("new")]
    public bool New { get; set; }

    [JsonPropertyName("answers")]
    public Dictionary<int, Answer> Answers { get; set; }
}