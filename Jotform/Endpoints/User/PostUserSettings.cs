namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Update User Settings.
    /// Update user's settings like time zone and language.
    /// </summary>
    /// <param name="name">User's name Example: John Smith</param>
    /// <param name="email">User's email Example: john @smith.com</param>
    /// <param name="website">User's website Example: www.johnsmith.com</param>
    /// <param name="timezone">User's time zone Example: UTC</param>
    /// <param name="company">User's company Example: Interlogy, LLC.</param>
    /// <param name="securityQuestion">User's security question Example: What was your first car?</param>
    /// <param name="securityAnswer">User's security answer Example: Ford</param>
    /// <param name="industry">User's industry Example: Education</param>
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