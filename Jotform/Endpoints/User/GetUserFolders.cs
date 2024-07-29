namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get User Folders.
    /// Get a list of form folders for this account.Returns name of the folder and owner of the folder for shared folders.
    /// </summary>
    public Task<JotformResult<GetUserFoldersResponse>?> GetUserFoldersAsync(CancellationToken cancellationToken = default)
        => GetResultAsync<GetUserFoldersResponse>("user/folders",
            cancellationToken);
}

public class Form
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("username")]
        public string Username { get; set; } = null!;

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; } = null!;

        [JsonPropertyName("new")]
        public bool New { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; } = null!;

        [JsonPropertyName("slug")]
        public string Slug { get; set; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;
    }

    public class GetUserFoldersResponse
    {
        /// <summary>
        /// id is folder ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// path is list of folders above this folder separated with comma.
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; } = null!;

        [JsonPropertyName("owner")]
        public string Owner { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// parent is the next folder above. If this folder is a root folder parent returns itself.
        /// </summary>
        [JsonPropertyName("parent")]
        public string Parent { get; set; } = null!;

        [JsonPropertyName("color")]
        public string Color { get; set; } = null!;

        /// <summary>
        /// forms lists all forms under this folder.
        /// </summary>
        [JsonPropertyName("forms")]
        public Dictionary<string, Form>? Forms { get; set; }

        /// <summary>
        /// subfolders lists all folders under this folder.
        /// </summary>
        [JsonPropertyName("subfolders")]
        public List<Folder> Subfolders { get; } = new List<Folder>();
    }

public class Folder
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("path")]
        public string Path { get; set; } = null!;

        [JsonPropertyName("owner")]
        public string Owner { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("parent")]
        public string Parent { get; set; } = null!;

        [JsonPropertyName("color")]
        public string Color { get; set; } = null!;

        [JsonPropertyName("forms")]
        public List<Form> Forms { get; } = new();

        [JsonPropertyName("subfolders")]
        public List<Folder> Subfolders { get; } = new();
    }

