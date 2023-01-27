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
}