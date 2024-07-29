namespace Jotform.Models.Shared;

public class UserSettings
{
    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;

    [JsonPropertyName("website")]
    public string Website { get; set; } = null!;

    /// <summary>
    /// time_zone is in IANA format.
    /// </summary>
    [JsonPropertyName("time_zone")]
    public string TimeZone { get; set; } = null!;

    /// <summary>
    /// account_type list can be seen in Pricing page.
    /// </summary>
    [JsonPropertyName("account_type")]
    public string AccountType { get; set; } = null!;

    /// <summary>
    /// status can be ACTIVE, DELETED or SUSPENDED
    /// </summary>
    [JsonPropertyName("status")]
    public Status? Status { get; set; }

    /// <summary>
    /// created_at, updated_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = null!;

    /// <summary>
    /// created_at, updated_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; } = null!;

    [JsonPropertyName("is_verified")]
    public bool? IsVerified { get; set; }

    [Obsolete($"Use {nameof(JotformClient.GetUserUsageAsync)}() method instead")]
    [JsonPropertyName("usage")]
    public string UsageEndpoint { get; set; } = null!;

    [JsonPropertyName("industry")]
    public string Industry { get; set; } = null!;

    [JsonPropertyName("securityAnswer")]
    public string SecurityAnswer { get; set; } = null!;

    [JsonPropertyName("company")]
    public string Company { get; set; } = null!;

    /// <summary>
    /// Array that is JSON serialized as a string
    /// </summary>
    [JsonPropertyName("webhooks")]
    public string Webhooks { get; set; } = null!;

    [JsonPropertyName("doNotClone")]
    public bool DoNotClone { get; set; }

    [JsonPropertyName("avatarUrl")]
    public string AvatarUrl { get; set; } = null!;
}