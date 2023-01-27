using Microsoft.Extensions.Configuration;

namespace Jotform.Tests.Fixtures;

public static class JotformClientFixture
{
    private static readonly string ApiKey;
    public static readonly string UserName;

    public static JotformClient JotformClient => new(ApiKey);

    static JotformClientFixture()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<SimpleIntegrationTests>()
            .Build();

        ApiKey = configuration["ApiKey"] ?? throw new InvalidOperationException();
        UserName = configuration["UserName"] ?? throw new InvalidOperationException();
    }
}