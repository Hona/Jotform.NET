using System.Text.Json;
using Jotform.Json;

namespace Jotform;

public partial class JotformClient
{
    private readonly string _apiKey;
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
    /// <param name="apiKey">Obtain an api key at https://www.jotform.com/myaccount/api</param>
    /// <param name="enterpriseSubdomain">For enterprise users, use 'SUBDOMAIN', from the string: 'SUBDOMAIN.jotform.com/API'</param>
    public JotformClient(string apiKey, string? enterpriseSubdomain = null)
    {
        _apiKey = apiKey;
        
        var baseUrl = enterpriseSubdomain != null
            ? $"https://{enterpriseSubdomain}.jotform.com/api"
            : "https://api.jotform.com";
        
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            DefaultRequestHeaders =
            {
                { "APIKEY", _apiKey}
            }
        };
    }
}