namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<UserSettings>?> GetUserSettingsAsync(CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<JotformResult<UserSettings>>("user/settings", _jsonSerializerOptions, cancellationToken: cancellationToken);
}
