using System.Net;
using Jotform.Models.Shared;
using Jotform.Tests.Fixtures;

namespace Jotform.Tests;

public class SimpleIntegrationTests
{
    [Fact]
    public async Task GetUsers_WithDefaults_ShouldReturnAnObject()
    {
        // Arrange 
        var jotformClient = JotformClientFixture.JotformClient;

        // Act
        var user = await jotformClient.GetUserAsync();

        // Assert
        user.Should().NotBeNull();
        user!.ResponseCode.Should().Be(HttpStatusCode.OK);
        user.Response.Should().NotBeNull();
        user.Response.Email.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GetUserUsage_WithDefaults_ShouldReturnAnObject()
    {
        // Arrange 
        var jotformClient = JotformClientFixture.JotformClient;

        // Act
        var usage = await jotformClient.GetUserUsageAsync();

        // Assert
        usage.Should().NotBeNull();
        usage!.ResponseCode.Should().Be(HttpStatusCode.OK);
        usage.Response.Should().NotBeNull();
    }

    [Fact]
    public async Task GetUserSubmissions_WithDefaults_ShouldReturnAnObject()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;

        // Act
        var submissions = await jotformClient.GetUserSubmissionsAsync();

        // Assert
        submissions.Should().NotBeNull();
        submissions!.ResponseCode.Should().Be(HttpStatusCode.OK);
        submissions.Response.Should().NotBeNull();
        submissions.Response.Should().NotBeEmpty();
        submissions.PaginationInfo.Should().NotBeNull();
        submissions.PaginationInfo.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task GetUserSubmissions_WithOffset_ShouldReturnAnOffset()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        const int offset = 20;

        // Act
        var submissions = await jotformClient.GetUserSubmissionsAsync(offset: offset);

        // Assert
        submissions.Should().NotBeNull();
        submissions!.ResponseCode.Should().Be(HttpStatusCode.OK);
        submissions.Response.Should().NotBeNull();
        submissions.Response.Should().NotBeEmpty();
        submissions.PaginationInfo.Should().NotBeNull();
        submissions.PaginationInfo.Offset.Should().Be(offset);
    }

    [Fact]
    public async Task GetSubUsers_WithInvalidAccount_ShouldThrow()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;

        // Act
        Func<Task> act = async () => await jotformClient.GetSubUsersAsync();

        // Assert
        await act.Should().ThrowAsync<HttpRequestException>();
    }

    [Fact]
    public async Task GetUserFolders_WithDefaults_ShouldReturnObject()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var folders = await jotformClient.GetUserFoldersAsync();
        
        // Assert
        folders.Should().NotBeNull();
        folders!.Response.Forms.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task GetUserReports_WithNoReports_ShouldReturnEmptyList()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var reports = await jotformClient.GetUserReportsAsync();
        
        // Assert
        reports.Should().NotBeNull();
        reports!.Response.Should().HaveCount(0);
    }

    [Fact]
    public async Task PostUserRegister_WithAny_ShouldThrowException()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        Func<Task> act = async () => await jotformClient.PostUserRegisterAsync("", "", "");
        
        // Assert
        await act.Should().ThrowAsync<NotSupportedException>();
    }
    
    [Fact]
    public async Task PostUserLogin_WithAny_ShouldThrowException()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        Func<Task> act = async () => await jotformClient.PostUserLoginAsync("", "");
        
        // Assert
        await act.Should().ThrowAsync<NotSupportedException>();
    }
    
    [Fact]
    public async Task GetUserLogout_WithAny_ShouldThrowException()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        Func<Task> act = async () => await jotformClient.GetUserLogoutAsync();
        
        // Assert
        await act.Should().ThrowAsync<NotSupportedException>();
    }

    [Fact]
    public async Task GetUserSettings_WithDefault_ReturnsObject()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var settings = await jotformClient.GetUserSettingsAsync();
        
        // Assert
        settings.Should().NotBeNull();
        settings!.ResponseCode.Should().Be(HttpStatusCode.OK);
        settings.Response.Should().NotBeNull();
    }
    
    [Fact]
    public async Task PostUserSettings_WithReadOnly_ShouldThrowException()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var result = await jotformClient.PostUserSettingsAsync(JotformClientFixture.UserName);
        
        // Assert
        result.Should().NotBeNull();
        result!.Response.Name.Should().Be(JotformClientFixture.UserName);
    }
    
    [Fact]
    public async Task GetUserHistory_WithDefaults_ReturnsObject()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var history = await jotformClient.GetUserHistoryAsync();
        
        // Assert
        history.Should().NotBeNull();
        history!.ResponseCode.Should().Be(HttpStatusCode.OK);
        history.Response.Should().NotBeNull();
        history.Response.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetUserForms_WithDefaults_ReturnsObject()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var forms = await jotformClient.GetUserFormsAsync();
        
        // Assert
        forms.Should().NotBeNull();
        forms!.ResponseCode.Should().Be(HttpStatusCode.OK);
        forms.Response.Should().NotBeNull();
        forms.Response.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetForm_WithFormId_ReturnsSingleForm()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var form = await jotformClient.GetFormAsync(JotformClientFixture.FormId);
        
        // Assert
        form.Should().NotBeNull();
        form!.ResponseCode.Should().Be(HttpStatusCode.OK);
        form.Response.Should().NotBeNull();
        form.Response.Id.Should().Be(JotformClientFixture.FormId);
    }

    [Fact]
    public async Task GetFormQuestions_WithFormId_ReturnsListOfQuestions()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var questions = await jotformClient.GetFormQuestionsAsync(JotformClientFixture.FormId);
        
        // Assert
        questions.Should().NotBeNull();
        questions!.ResponseCode.Should().Be(HttpStatusCode.OK);
        questions.Response.Should().NotBeNull();
        questions.Response.Should().NotBeEmpty();
        questions.Response.Should().AllSatisfy(x => x.Value.Qid.Should().NotBeNullOrWhiteSpace());
    }

    [Fact]
    public async Task GetFormQuestion_WithFormId_WithQuestionId_ReturnsAQuestion()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var question = await jotformClient.GetFormQuestionAsync(JotformClientFixture.FormId, JotformClientFixture.QuestionId);
        
        // Assert
        question.Should().NotBeNull();
        question!.ResponseCode.Should().Be(HttpStatusCode.OK);
        question.Response.Should().NotBeNull();
        question.Response.Qid.Should().Be(JotformClientFixture.QuestionId);
    }

    [Fact]
    public async Task GetFormProperties_WithFormId_ReturnsProperties()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var properties = await jotformClient.GetFormPropertiesAsync(JotformClientFixture.FormId);
        
        // Assert
        properties.Should().NotBeNull();
        properties!.ResponseCode.Should().Be(HttpStatusCode.OK);
        properties.Response.Should().NotBeNull();
    }

    [Fact]
    public async Task GetFormProperty_WithIntMemberExpression_ReturnsProperty()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var property = await jotformClient.GetFormPropertyAsync(JotformClientFixture.FormId, 
            x => x.FormWidth);
        
        // Assert
        property.Should().NotBeNull();
        property!.ResponseCode.Should().Be(HttpStatusCode.OK);
        property.Response.Should().NotBeNull();
        property.Response.FormWidth.Should().NotBe(default);
    }
    
    [Fact]
    public async Task GetFormProperty_WithStringMemberExpression_ReturnsProperty()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var property = await jotformClient.GetFormPropertyAsync(JotformClientFixture.FormId, 
            x => x.Background);
        
        // Assert
        property.Should().NotBeNull();
        property!.ResponseCode.Should().Be(HttpStatusCode.OK);
        property.Response.Should().NotBeNull();
        property.Response.Background.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GetFormReports_WithFormId_ReturnsList()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var report = await jotformClient.GetFormReportsAsync(JotformClientFixture.FormId);
        
        // Assert
        report.Should().NotBeNull();
        report!.ResponseCode.Should().Be(HttpStatusCode.OK);
        report.Response.Should().NotBeNull();
    }

    [Fact]
    public async Task GetFormFiles_WithFormId_ReturnsList()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var files = await jotformClient.GetFormFilesAsync(JotformClientFixture.FormId);
        
        // Assert
        files.Should().NotBeNull();
        files!.ResponseCode.Should().Be(HttpStatusCode.OK);
        files.Response.Should().NotBeNull();
    }

    [Fact]
    public async Task GetFormWebhooks_WithFormId_ReturnsList()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var webhooks = await jotformClient.GetFormWebhooksAsync(JotformClientFixture.FormId);
        
        // Assert
        webhooks.Should().NotBeNull();
        webhooks!.ResponseCode.Should().Be(HttpStatusCode.OK);
        webhooks.Response.Should().NotBeNull();
    }
    
    [Fact]
    public async Task GetFormSubmissions_WithFormId_ReturnsList()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var submissions = await jotformClient.GetFormSubmissionsAsync(JotformClientFixture.FormId);
        
        // Assert
        submissions.Should().NotBeNull();
        submissions!.ResponseCode.Should().Be(HttpStatusCode.OK);
        submissions.Response.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSubmission_WithSubmissionId_ReturnsSubmission()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var submission = await jotformClient.GetSubmissionAsync(JotformClientFixture.SubmissionId);
        
        // Assert
        submission.Should().NotBeNull();
        submission!.ResponseCode.Should().Be(HttpStatusCode.OK);
        submission.Response.Should().NotBeNull();
        submission.Response.Id.Should().Be(JotformClientFixture.SubmissionId);
    }

    [Fact]
    public async Task GetFolder_WithFolderId_ReturnsFolder()
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var folder = await jotformClient.GetFolderAsync(JotformClientFixture.FolderId);
        
        // Assert
        folder.Should().NotBeNull();
        folder!.ResponseCode.Should().Be(HttpStatusCode.OK);
        folder.Response.Should().NotBeNull();
        folder.Response.Id.Should().Be(JotformClientFixture.FolderId);
    }
    
    // Member data to get all enum values of SystemPlanType
    public static IEnumerable<object[]> SystemPlanTypeValues() =>
        Enum.GetValues(typeof(SystemPlanType))
            .Cast<SystemPlanType>()
            .Select(x => new object[] {x});

    [Theory]
    [MemberData(nameof(SystemPlanTypeValues))]
    public async Task GetSystemPlan_WithType_ReturnsData(SystemPlanType type)
    {
        // Arrange
        var jotformClient = JotformClientFixture.JotformClient;
        
        // Act
        var plan = await jotformClient.GetSystemPlanAsync(type);
        
        // Assert
        plan.Should().NotBeNull();
        plan!.ResponseCode.Should().Be(HttpStatusCode.OK);
        plan.Response.Should().NotBeNull();
        
    }
}