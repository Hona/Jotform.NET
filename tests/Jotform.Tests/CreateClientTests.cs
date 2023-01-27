namespace Jotform.Tests;

public class CreateClientTests
{
    [Fact]
    public void NewJotformClient_WithApiKey_ShouldNotError()
    {
        // Act
        var jotformClient = new JotformClient("1234567890abcdef1234567890abcdef");
        
        // Assert
        jotformClient.Should().NotBeNull();
    }

    [Fact]
    public void NewJotformClient_WithEnterpriseSubdomain_ShouldNotError()
    {
        // Act
        var jotformClient = new JotformClient("1234567890abcdef1234567890abcdef", "subdomain");
        
        // Assert
        jotformClient.Should().NotBeNull();
    }
}