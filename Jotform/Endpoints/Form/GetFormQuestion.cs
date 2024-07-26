namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get details about a question.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    /// <param name="questionId">Question ID.</param>
    public Task<JotformResult<Question>?> GetFormQuestionAsync(string formId, string questionId, CancellationToken cancellationToken = default) => GetResultAsync<Question>($"form/{formId}/question/{questionId}", cancellationToken);
}