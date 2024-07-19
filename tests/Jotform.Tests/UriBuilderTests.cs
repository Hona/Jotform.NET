namespace Jotform.Tests;

public class UriBuilderTests
{
    private const string BASE_URL = "http://example.com";

    [Fact]
    public void ToString_ReturnsBaseUrl_If_AddQuery_IsNeverCalled()
    {
        var builder = new UriBuilder(BASE_URL);
        builder.ToString().Should().Be(BASE_URL);
    }

    [Fact]
    public void ToString_ReturnsBaseUrl_If_AddQuery_IsCalledWithNulls()
    {
        var builder = new UriBuilder(BASE_URL);
        string? param1 = null;
        int? param2 = null;
        decimal? param3 = null;

        builder.AddQuery("param1", param1);
        builder.AddQuery("param2", param2);
        builder.AddQuery("param3", param3);

        builder.ToString().Should().Be(BASE_URL);
    }

    [Fact]
    public void ToString_ReturnsUrlWithQuery_If_AddQuery_IsCalledWithNonEmptyString()
    {        
        var builder = new UriBuilder(BASE_URL);
        string? param = "value";
        var query = $"param=value";
        var urlWithQuery = $"{BASE_URL}?{query}";

        builder.AddQuery(nameof(param), param);

        builder.ToString().Should().Be(urlWithQuery);
    }

    [Fact]
    public void ToString_ReturnsUrlWithQuery_If_AddQuery_IsCalledWithValidInteger()
    {
        var builder = new UriBuilder(BASE_URL);
        int? param = 0;
        var query = $"param=0";
        var urlWithQuery = $"{BASE_URL}?{query}";

        builder.AddQuery(nameof(param), param);

        builder.ToString().Should().Be(urlWithQuery);
    }

    [Fact]
    public void ToString_ReturnsUrlWithQuery_If_AddQuery_IsCalledWithValidDecimal()
    {
        var builder = new UriBuilder(BASE_URL);
        decimal? param = 0.1M;
        var query = $"param=0.1";
        var urlWithQuery = $"{BASE_URL}?{query}";

        builder.AddQuery(nameof(param), param);

        builder.ToString().Should().Be(urlWithQuery);
    }

    [Fact]
    public void ToString_ReturnsUrlWithQuery_If_AddQuery_IsCalledWithNonNulls()
    {
        var builder = new UriBuilder(BASE_URL);
        string? param1 = "value";
        int? param2 = 0;
        decimal? param3 = 0.1M;
        var query = $"param1=value&param2=0&param3=0.1";
        var urlWithQuery = $"{BASE_URL}?{query}";

        builder.AddQuery("param1", param1);
        builder.AddQuery("param2", param2);
        builder.AddQuery("param3", param3);
 
        builder.ToString().Should().Be(urlWithQuery);
    }
}