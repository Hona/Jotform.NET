namespace Jotform.Models.Shared;

public class PagedJotformResult<TResponse> : JotformResult<IReadOnlyList<TResponse>>
{
    [JsonPropertyName("resultSet")]
    public PaginationInfo PaginationInfo { get; set; }
}