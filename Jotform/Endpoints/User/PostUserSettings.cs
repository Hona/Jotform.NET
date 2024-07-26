namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<UserSettings>?> PostUserSettingsAsync(string? name = null, string? email = null, string? website = null, string? timezone = null, string? company = null, string? securityQuestion = null, string? securityAnswer = null, string? industry = null, 
        CancellationToken cancellationToken = default)
    {
        var formData = new FormDataBuilder()
            .Add("name", name)
            .Add("email", email)
            .Add("website", website)
            .Add("timezone", timezone)
            .Add("company", company)
            .Add("securityQuestion", securityQuestion)
            .Add("securityAnswer", securityAnswer)
            .Add("industry", industry)
            .Build();

        var response = await _httpClient.PostAsync("user/settings", 
            formData, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<JotformResult<UserSettings>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}