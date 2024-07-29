namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get User Information
    /// Get user account details for this Jotform user. Including user account type, avatar URL, name, email, website URL.
    /// </summary>
    public Task<JotformResult<GetUserResponse>?> GetUserAsync(
        CancellationToken cancellationToken = default)
        => GetResultAsync<GetUserResponse>("user", cancellationToken);
}

public class GetUserResponse
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

    [JsonPropertyName("status")]
    public Status Status { get; set; }

    /// <summary>
    /// created_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = null!;

    /// <summary>
    /// updated_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; } = null!;

    [JsonPropertyName("is_verified")]
    public bool IsVerified { get; set; }

    [JsonPropertyName("usage")]
    public string Usage { get; set; } = null!;

    [JsonPropertyName("industry")]
    public string Industry { get; set; } = null!;

    [JsonPropertyName("securityAnswer")]
    public string SecurityAnswer { get; set; } = null!;

    [JsonPropertyName("company")]
    public string Company { get; set; } = null!;

    [JsonPropertyName("securityQuestion")]
    public string SecurityQuestion { get; set; } = null!;

    /// <summary>
    /// JSON serialized array of webhooks (string[])
    /// </summary>
    [JsonPropertyName("webhooks")]
    public string Webhooks { get; set; } = null!;

    [JsonPropertyName("doNotClone")]
    public bool DoNotClone { get; set; }

    /// <summary>
    /// JSON serialized objection with a root node, and its tree structure
    /// </summary>
    [JsonPropertyName("folderLayout")]
    public string FolderLayout { get; set; } = null!;

    [JsonPropertyName("language")]
    public string Language { get; set; } = null!;

    [JsonPropertyName("avatarUrl")]
    public string AvatarUrl { get; set; } = null!;
}