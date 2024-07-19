namespace Jotform.Tests.Fixtures;

public class HttpClientFixture : IDisposable
{
    public static HttpClient HttpClient { get; } = new();

    public void Dispose()
    {
        HttpClient.Dispose();
    }

    public static HttpClient ResetBaseAddress()
    {
        HttpClient.BaseAddress = null;
        return HttpClient;
    }
}

[CollectionDefinition(nameof(HttpClientFixture))]
public class HttpClientShared : ICollectionFixture<HttpClientFixture>
{ }