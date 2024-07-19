namespace Jotform;

public partial class JotformClient
{
    public Task<JotformResult<Dictionary<string, Question>>?> GetFormQuestionsAsync(string formId, CancellationToken cancellationToken = default) 
        => GetResultAsync<Dictionary<string, Question>>(
            $"form/{formId}/questions", cancellationToken);
}