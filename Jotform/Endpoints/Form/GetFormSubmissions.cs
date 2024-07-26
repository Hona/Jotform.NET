namespace Jotform;

public partial class JotformClient
{
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

#nullable disable
public class FormSubmission
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("form_id")]
        public string FormId { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("new")]
        public bool New { get; set; }

        [JsonPropertyName("flag")]
        public bool Flag { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("answers")]
        public Dictionary<string, Answer> Answers { get; set; }
    }

