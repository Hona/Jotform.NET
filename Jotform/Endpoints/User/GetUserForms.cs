namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get User Forms
    /// Get a list of forms for this account. Includes basic details such as title of the form, when it was created, number of new and total submissions.
    /// </summary>
    public Task<PagedJotformResult<Models.Shared.Form>?> GetUserFormsAsync(int? offset = null, int? limit = null, string? jsonFilter = null, string? orderBy = null, CancellationToken cancellationToken = default)
    {
        var url = new UriBuilder("user/forms")
            .AddQuery("offset", offset)
            .AddQuery("limit", limit)
            .AddQuery("filter", jsonFilter)
            .AddQuery("orderBy", orderBy)
            .ToString();

        return GetPagedResultAsync<Models.Shared.Form>(
            url, cancellationToken);
    }
}