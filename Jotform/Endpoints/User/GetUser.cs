
namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get User Information
    /// Get user account details for this Jotform user. Including user account type, avatar URL, name, email, website URL.
    /// </summary>
    public async Task<JotformResult<GetUserResponse>?> GetUserAsync(CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<JotformResult<GetUserResponse>>("user", 
            _jsonSerializerOptions, cancellationToken: cancellationToken);
}

public class GetUserResponse
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

    [JsonPropertyName("status")]
    public Status Status { get; set; }

    /// <summary>
    /// created_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    /// updated_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }

    [JsonPropertyName("is_verified")]
    public bool IsVerified { get; set; }

    [JsonPropertyName("usage")]
    public string Usage { get; set; }

    [JsonPropertyName("industry")]
    public string Industry { get; set; }

    [JsonPropertyName("securityAnswer")]
    public string SecurityAnswer { get; set; }

    [JsonPropertyName("company")]
    public string Company { get; set; }

    [JsonPropertyName("securityQuestion")]
    public string SecurityQuestion { get; set; }

    /// <summary>
    /// JSON serialized array of webhooks (string[])
    /// </summary>
    [JsonPropertyName("webhooks")]
    public string Webhooks { get; set; }

    [JsonPropertyName("doNotClone")]
    public bool DoNotClone { get; set; }

    /// <summary>
    /// JSON serialized objection with a root node, and its tree structure
    /// </summary>
    [JsonPropertyName("folderLayout")]
    public string FolderLayout { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("avatarUrl")]
    public string AvatarUrl { get; set; }
}