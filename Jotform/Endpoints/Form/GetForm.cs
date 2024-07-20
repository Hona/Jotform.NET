namespace Jotform;

public partial class JotformClient
{
    public Task<JotformResult<Models.Shared.Form>?> GetFormAsync(string formId, CancellationToken cancellationToken = default) 
        => GetResultAsync<Models.Shared.Form>($"form/{formId}",
            cancellationToken);
}