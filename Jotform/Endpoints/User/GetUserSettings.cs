namespace Jotform;

public partial class JotformClient
{
    public Task<JotformResult<UserSettings>?> GetUserSettingsAsync(CancellationToken cancellationToken = default)
        => GetResultAsync<UserSettings>("user/settings",
            cancellationToken);
}
