namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get User Settings.
    /// Get user's time zone and language.
    /// </summary>
    public Task<JotformResult<UserSettings>?> GetUserSettingsAsync(CancellationToken cancellationToken = default)
        => GetResultAsync<UserSettings>("user/settings",
            cancellationToken);
}
