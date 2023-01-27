namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<GetUserFoldersResponse>?> GetUserFoldersAsync(CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<JotformResult<GetUserFoldersResponse>>("user/folders", _jsonSerializerOptions, cancellationToken: cancellationToken);
}

    public class Form
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("new")]
        public bool New { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class GetUserFoldersResponse
    {
        /// <summary>
        /// id is folder ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// path is list of folders above this folder separated with comma.
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// parent is the next folder above. If this folder is a root folder parent returns itself.
        /// </summary>
        [JsonPropertyName("parent")]
        public string Parent { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        /// <summary>
        /// forms lists all forms under this folder.
        /// </summary>
        [JsonPropertyName("forms")]
        public Dictionary<string, Form> Forms { get; set; }

        /// <summary>
        /// subfolders lists all folders under this folder.
        /// </summary>
        [JsonPropertyName("subfolders")]
        public List<Folder> Subfolders { get; } = new List<Folder>();
    }

public class Folder
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("parent")]
        public string Parent { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("forms")]
        public List<Form> Forms { get; } = new();

        [JsonPropertyName("subfolders")]
        public List<Folder> Subfolders { get; } = new();
    }

