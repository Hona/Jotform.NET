using Jotform.Models.Shared;

namespace Jotform.Tests;

file static class AssertHelper
{
    internal static void AssertBuildReturnsNull(
        this JotformFilterBuilder builder)
    {
        builder.Build().Should().BeNull();
    }

    internal static void AssertBuildReturnsJson(this JotformFilterBuilder builder, string jsonFilter)
    {
        builder.Build().Should().Be(jsonFilter);
    }
}

public class JotformFilterBuilderTests
{
    [Fact]
    public void Build_ReturnsNull_If_NoOtherMethodIsCalled()
    {
        var builder = new JotformFilterBuilder();
        builder.AssertBuildReturnsNull();
    }

    [Fact]
    public void Build_ReturnsNull_If_OtherMethodsAreCalledWithNulls()
    {
        var builder = new JotformFilterBuilder();
        string? field1 = null;
        int? field2 = null;
        decimal? field3 = null;
        
        builder.AddCriteria("field1", field1);
        builder.AddCriteria("field2", field2);
        builder.AddCriteria("field3", field3);
        
        builder.AssertBuildReturnsNull();
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddCriteria_IsCalledWithNonEmptyString()
    {
        var builder = new JotformFilterBuilder();
        string? field = "value";
        var jsonFilter = @"{""field"":""value""}";

        builder.AddCriteria(nameof(field), field);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddCriteria_IsCalledWithValidInteger()
    {
        var builder = new JotformFilterBuilder();
        int? field = 0;
        var jsonFilter = @"{""field"":""0""}";

        builder.AddCriteria(nameof(field), field);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddCriteria_IsCalledWithValidDecimal()
    {
        var builder = new JotformFilterBuilder();
        decimal? field = 0.1M;
        var jsonFilter = @"{""field"":""0.1""}";

        builder.AddCriteria(nameof(field), field);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddCriteria_WithComparisionModifier_IsCalledWithNonEmptyString()
    {
        var builder = new JotformFilterBuilder();
        const string comparision = "eq";
        string? field = "value";
        var jsonFilter = @"{""field:eq"":""value""}";

        builder.AddCriteria(nameof(field), comparision, field);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddGreaterThan_IsCalledWithNonEmptyString()
    {
        var builder = new JotformFilterBuilder();
        string? field = "value";
        var jsonFilter = @"{""field:gt"":""value""}";

        builder.AddGreaterThan(nameof(field), field);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddLessThan_IsCalledWithNonEmptyString()
    {
        var builder = new JotformFilterBuilder();
        string? field = "value";
        var jsonFilter = @"{""field:lt"":""value""}";

        builder.AddLessThan(nameof(field), field);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddNotEqualTo_IsCalledWithNonEmptyString()
    {
        var builder = new JotformFilterBuilder();
        string? field = "value";
        var jsonFilter = @"{""field:ne"":""value""}";

        builder.AddNotEqualTo(nameof(field), field);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddMatches_IsCalledWithNonEmptyString()
    {
        var builder = new JotformFilterBuilder();
        string? field = "value";
        var jsonFilter = @"{""field:matches"":""value""}";

        builder.AddMatches(nameof(field), field);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddGreaterThan_IsCalledWithValidDate()
    {
        var builder = new JotformFilterBuilder();
        DateTime? field = new DateTime(2024, 1, 1);
        var jsonFilter = @$"{{""field:gt"":""2024-01-01 12:00:00""}}";
        
        builder.AddGreaterThan(nameof(field), field);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddGreaterThan_IsCalledWithValidDateAndMinusOneDayTrue()
    {
        var builder = new JotformFilterBuilder();
        DateTime? field = new DateTime(2024, 1, 2);
        var jsonFilter = @$"{{""field:gt"":""2024-01-01 12:00:00""}}";

        builder.AddGreaterThan(nameof(field), field, true);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddLessThan_IsCalledWithValidDate()
    {
        var builder = new JotformFilterBuilder();
        DateTime? field = new DateTime(2024, 1, 1);
        var jsonFilter = @$"{{""field:lt"":""2024-01-01 12:00:00""}}";

        builder.AddLessThan(nameof(field), field);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddLessThan_IsCalledWithValidDateAndPlusOneDayTrue()
    {
        var builder = new JotformFilterBuilder();
        DateTime? field = new DateTime(2024, 1, 1);
        var jsonFilter = @$"{{""field:lt"":""2024-01-02 12:00:00""}}";

        builder.AddLessThan(nameof(field), field, true);

        builder.AssertBuildReturnsJson(jsonFilter);
    }
}