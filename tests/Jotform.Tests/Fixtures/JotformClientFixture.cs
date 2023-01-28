using Microsoft.Extensions.Configuration;

namespace Jotform.Tests.Fixtures;

public static class JotformClientFixture
{
    private static readonly string ApiKey;
    public static readonly string UserName;

    public static JotformClient JotformClient => new(ApiKey);

    public static readonly string FormId;
    public static readonly string QuestionId;
    public static readonly string SubmissionId;
    public static readonly string FolderId;
    static JotformClientFixture()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<SimpleIntegrationTests>()
            .Build();

        ApiKey = configuration["ApiKey"] ?? throw new InvalidOperationException();
        UserName = configuration["UserName"] ?? throw new InvalidOperationException();
        FormId = configuration["FormId"] ?? throw new InvalidOperationException();
        QuestionId = configuration["QuestionId"] ?? throw new InvalidOperationException();
        SubmissionId = configuration["SubmissionId"] ?? throw new InvalidOperationException();
        FolderId = configuration["FolderId"] ?? throw new InvalidOperationException();
    }
}