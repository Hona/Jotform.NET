namespace Jotform;

public partial class JotformClient
{
    public Task<JotformResult<Question>?> GetFormQuestionAsync(string formId, string questionId, CancellationToken cancellationToken = default) => GetResultAsync<Question>($"form/{formId}/question/{questionId}", cancellationToken);
}