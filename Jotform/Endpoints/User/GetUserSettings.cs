namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<UserSettings>?> GetUserSettingsAsync(CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<JotformResult<UserSettings>>("user/settings", _jsonSerializerOptions, cancellationToken: cancellationToken);
}

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Root
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("is_verified")]
        public string IsVerified { get; set; }

        [JsonPropertyName("usage")]
        public string Usage { get; set; }

        [JsonPropertyName("industry")]
        public string Industry { get; set; }

        [JsonPropertyName("securityAnswer")]
        public string SecurityAnswer { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("webhooks")]
        public string Webhooks { get; set; }

        [JsonPropertyName("doNotClone")]
        public string DoNotClone { get; set; }

        [JsonPropertyName("avatarUrl")]
        public string AvatarUrl { get; set; }
    }

