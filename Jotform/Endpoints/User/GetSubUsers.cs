namespace Jotform;

public partial class JotformClient
{
    public Task<JotformResult<GetSubUsersResponse[]>?> GetSubUsersAsync(CancellationToken cancellationToken = default)
        => GetResultAsync<GetSubUsersResponse[]>("user/subusers",
            cancellationToken);
}

public enum PermissionType
{
    Form,
    Folder,
    All
}

public class Permission
{
    /// <summary>
    /// type can be FORM, FOLDER or ALL.
    /// </summary>
    [JsonPropertyName("type")]
    public PermissionType Type { get; set; }

    /// <summary>
    /// resource_id is form ID or folder ID, depending on type.
    /// </summary>
    [JsonPropertyName("resource_id")]
    public string ResourceId { get; set; }

    /// <summary>
    /// access_type is full or readOnly. readOnly means form cannot be changed by the sub-user. Only submissions can be viewed.
    /// </summary>
    [JsonPropertyName("access_type")]
    public string AccessType { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
}

public class GetSubUsersResponse
{
    /// <summary>
    /// owner the parent account that created this sub-user.
    /// </summary>
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// status can be LIVE, DELETED or PENDING. If the user has not accepted the invitation sub-user is in PENDING status.
    /// </summary>
    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    /// <summary>
    /// created_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    [JsonPropertyName("permissions")]
    public List<Permission> Permissions { get; } = new();
}

