#nullable disable
using System.Net;

namespace Jotform.Models.Shared;

public class JotformResult<TResponse>
{
    [JsonPropertyName("responseCode")]
    public HttpStatusCode ResponseCode { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// limit-left is the number of daily api calls you can make.
    /// </summary>
    [JsonPropertyName("limit-left")] public int RemainingApiQuota { get; set; }

    [JsonPropertyName("content")]
    public TResponse Response { get; set; }

    [JsonPropertyName("duration")]
    public string Duration { get; set; }
}