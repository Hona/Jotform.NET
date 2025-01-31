using System.Text.Json;
using Jotform.Json;

namespace Jotform;

public partial class JotformClient
{
    private readonly HttpClient _httpClient;
    
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        Converters =
        {
            new JsonStringEnumConverter(),
            new IntBoolConverter()
        },
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    /// <summary>
    /// Create a new Jotform Client
    /// </summary>
    /// <param name="httpClient">The client is used to send the requests.</param>
    /// <param name="apiKey">Obtain an api key at https://www.jotform.com/myaccount/api</param>
    /// <param name="enterpriseSubdomain">For enterprise users, use 'SUBDOMAIN', from the string: 'SUBDOMAIN.jotform.com/API'</param>
    public JotformClient(HttpClient httpClient, string apiKey, string? enterpriseSubdomain = null)
    {

        if (httpClient.BaseAddress is not null)
            throw new InvalidOperationException($"Cannot create the JotformClient instance, the base address of the httpclient is already set to {httpClient.BaseAddress} .");

        var baseUrl = enterpriseSubdomain != null
            ? $"https://{enterpriseSubdomain}.jotform.com/API/"
            : "https://api.jotform.com";

        httpClient.BaseAddress = new Uri(baseUrl);
        httpClient.DefaultRequestHeaders.Add("APIKEY", apiKey);

        _httpClient = httpClient;
    }

    private Task<JotformResult<TResult>?> GetResultAsync<TResult>(
        string url, CancellationToken cancellation = default)
    {
        return _httpClient.GetFromJsonAsync<JotformResult<TResult>>(
            url, _jsonSerializerOptions, cancellation);
    }

    private Task<PagedJotformResult<TResult>?>
        GetPagedResultAsync<TResult>(string url,
        CancellationToken cancellation = default)
    {
        return _httpClient.GetFromJsonAsync<PagedJotformResult<
            TResult>>(url, _jsonSerializerOptions, cancellation);
    }
}