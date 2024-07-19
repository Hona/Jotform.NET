using Jotform.Tests.Fixtures;

namespace Jotform.Tests;

[Collection(nameof(HttpClientFixture))]
public class CreateClientTests
{
    private static HttpClient GetClient()
    {
        return HttpClientFixture.ResetBaseAddress();
    }

    [Fact]
    public void NewJotformClient_WithApiKey_ShouldNotError()
    {
        // Act
        var jotformClient = new JotformClient(GetClient(),
            "1234567890abcdef1234567890abcdef");
        
        // Assert
        jotformClient.Should().NotBeNull();
    }

    [Fact]
    public void NewJotformClient_WithEnterpriseSubdomain_ShouldNotError()
    {
        // Act
        var jotformClient = new JotformClient(GetClient(),
            "1234567890abcdef1234567890abcdef", "subdomain");
        
        // Assert
        jotformClient.Should().NotBeNull();
    }
}