namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get a list of all questions on a form. Type describes in https://www.jotform.com/help/46-quick-overview-of-form-fields/. Order is the question order in the form. Text field is the question label.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    public Task<JotformResult<Dictionary<string, Question>>?> GetFormQuestionsAsync(string formId, CancellationToken cancellationToken = default) 
        => GetResultAsync<Dictionary<string, Question>>(
            $"form/{formId}/questions", cancellationToken);
}