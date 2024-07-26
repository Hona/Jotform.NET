#nullable disable
namespace Jotform.Models.Shared;

public class UserSettings
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("website")]
    public string Website { get; set; }

    /// <summary>
    /// time_zone is in IANA format.
    /// </summary>
    [JsonPropertyName("time_zone")]
    public string TimeZone { get; set; }

    /// <summary>
    /// account_type list can be seen in Pricing page.
    /// </summary>
    [JsonPropertyName("account_type")]
    public string AccountType { get; set; }

    /// <summary>
    /// status can be ACTIVE, DELETED or SUSPENDED
    /// </summary>
    [JsonPropertyName("status")]
    public Status? Status { get; set; }

    /// <summary>
    /// created_at, updated_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    /// created_at, updated_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }

    [JsonPropertyName("is_verified")]
    public bool? IsVerified { get; set; }

    [Obsolete($"Use {nameof(JotformClient.GetUserUsageAsync)}() method instead")]
    [JsonPropertyName("usage")]
    public string UsageEndpoint { get; set; }

    [JsonPropertyName("industry")]
    public string Industry { get; set; }

    [JsonPropertyName("securityAnswer")]
    public string SecurityAnswer { get; set; }

    [JsonPropertyName("company")]
    public string Company { get; set; }

    /// <summary>
    /// Array that is JSON serialized as a string
    /// </summary>
    [JsonPropertyName("webhooks")]
    public string Webhooks { get; set; }

    [JsonPropertyName("doNotClone")]
    public bool DoNotClone { get; set; }

    [JsonPropertyName("avatarUrl")]
    public string AvatarUrl { get; set; }
}

