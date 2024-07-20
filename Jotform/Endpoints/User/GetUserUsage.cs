namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get Monthly User Usage
    /// Get number of form submissions received this month. Also, get number of SSL form submissions, payment form submissions and upload space used by user.
    /// </summary>
    public Task<JotformResult<GetUserUsageResponse>?> GetUserUsageAsync(CancellationToken cancellationToken = default)
        => GetResultAsync<GetUserUsageResponse>("user/usage",
            cancellationToken);
}

public class GetUserUsageResponse
{
    /// <summary>
    /// Number of submissions received this month
    /// </summary>
    [JsonPropertyName("submissions")]
    public int Submissions { get; set; }

    /// <summary>
    /// Number of secure submissions received this month
    /// </summary>
    [JsonPropertyName("ssl_submissions")]
    public int SslSubmissions { get; set; }

    /// <summary>
    /// Number of payment submissions received this month
    /// </summary>
    [JsonPropertyName("payments")]
    public int Payments { get; set; }

    /// <summary>
    /// Total disk space used for uploaded files. In bytes.
    /// </summary>
    [JsonPropertyName("uploads")]
    public long Uploads { get; set; }

    /// <summary>
    /// Number of mobile submissions received this month
    /// </summary>
    [JsonPropertyName("mobile_submissions")]
    public int MobileSubmissions { get; set; }

    /// <summary>
    /// Number of form views received this month
    /// </summary>
    [JsonPropertyName("views")]
    public int Views { get; set; }

    /// <summary>
    /// Number of api calls used today.
    /// </summary>
    [JsonPropertyName("api")]
    public int Api { get; set; }
}

