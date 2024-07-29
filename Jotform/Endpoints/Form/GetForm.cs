namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get basic information about a form.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    public Task<JotformResult<Models.Shared.Form>?> GetFormAsync(string formId, CancellationToken cancellationToken = default) 
        => GetResultAsync<Models.Shared.Form>($"form/{formId}",
            cancellationToken);
}