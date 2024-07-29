namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get Sub-User Account List.
    /// Get a list of sub users for this accounts and list of forms and form folders with access privileges.
    /// </summary>
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
    public string ResourceId { get; set; } = null!;

    /// <summary>
    /// access_type is full or readOnly. readOnly means form cannot be changed by the sub-user. Only submissions can be viewed.
    /// </summary>
    [JsonPropertyName("access_type")]
    public string AccessType { get; set; } = null!;

    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;
}

public class GetSubUsersResponse
{
    /// <summary>
    /// owner the parent account that created this sub-user.
    /// </summary>
    [JsonPropertyName("owner")]
    public string Owner { get; set; } = null!;

    /// <summary>
    /// status can be LIVE, DELETED or PENDING. If the user has not accepted the invitation sub-user is in PENDING status.
    /// </summary>
    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;

    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    /// <summary>
    /// created_at: YYYY-MM-DD HH:MM:SS
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = null!;

    [JsonPropertyName("permissions")]
    public List<Permission> Permissions { get; } = new();
}