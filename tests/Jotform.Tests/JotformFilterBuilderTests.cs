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
    private static DateTime _firstDateOf2020 = new(2020, 1, 1);
    private static DateTime _lastDateOf2020 = new(2020, 12, 31);

    const string _firstDateOutput = "2020-01-01 00:00:00";
    const string _lastDateOutput = "2020-12-31 00:00:00";
    const string _firstDateMinus1SecondOutput = 
        "2019-12-31 23:59:59";
    const string _lastDatePlus1DayOutput = 
        "2021-01-01 00:00:00";

    private const string _fieldName = "field";
    private const string _fieldValue = "value";

    private static string GetExpectedFilter(string fieldValue, 
        string? comparision = null)
    {
        string fieldName = comparision is null 
            ? _fieldName : $"{_fieldName}:{comparision}";
        return $@"{{""{fieldName}"":""{fieldValue}""}}";
    }

    [Fact]
    public void Build_ReturnsNull_If_NoOtherMethodIsCalled()
    {
        var builder = new JotformFilterBuilder();
        builder.AssertBuildReturnsNull();
    }

    [Fact]
    public void Build_ReturnsNull_If_OtherMethodsAreCalledWithNulls()
    {
        string? field1 = null;
        int? field2 = null;
        decimal? field3 = null;

        var builder = new JotformFilterBuilder();        
        builder.AddCriteria(nameof(field1), field1);
        builder.AddCriteria(nameof(field2), field2);
        builder.AddCriteria(nameof(field3), field3);
        
        builder.AssertBuildReturnsNull();
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddCriteria_IsCalledWithNonNullString()
    {
        var jsonFilter = GetExpectedFilter(_fieldValue);

        var builder = new JotformFilterBuilder();
        builder.AddCriteria(_fieldName, _fieldValue);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddCriteria_IsCalledWithValidInteger()
    {
        int? fieldValue = 0;
        var jsonFilter = GetExpectedFilter("0");

        var builder = new JotformFilterBuilder();        
        builder.AddCriteria(_fieldName, fieldValue);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddCriteria_IsCalledWithValidDecimal()
    {
        decimal? fieldValue = 0.1M;
        var jsonFilter = GetExpectedFilter("0.1");

        var builder = new JotformFilterBuilder();
        builder.AddCriteria(_fieldName, fieldValue);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddCriteria_WithComparisionModifier_IsCalledWithNonNullString()
    {
        const string comparision = "eq";
        var jsonFilter = GetExpectedFilter(_fieldValue, comparision);

        var builder = new JotformFilterBuilder();        
        builder.AddCriteria(_fieldName, comparision, _fieldValue);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddGreaterThan_IsCalledWithNonNullString()
    {
        var jsonFilter = GetExpectedFilter(_fieldValue, "gt");

        var builder = new JotformFilterBuilder();
        builder.AddGreaterThan(_fieldName, _fieldValue);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddLessThan_IsCalledWithNonNullString()
    {
        var jsonFilter = GetExpectedFilter(_fieldValue, "lt");

        var builder = new JotformFilterBuilder();
        builder.AddLessThan(_fieldName, _fieldValue);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddNotEqualTo_IsCalledWithNonNullString()
    {
        var jsonFilter = GetExpectedFilter(_fieldValue, "ne");

        var builder = new JotformFilterBuilder();       
        builder.AddNotEqualTo(_fieldName, _fieldValue);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddMatches_IsCalledWithNonNullString()
    {
        var jsonFilter = GetExpectedFilter(_fieldValue, "matches");

        var builder = new JotformFilterBuilder();
        builder.AddMatches(_fieldName, _fieldValue);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddGreaterThan_IsCalledWithValidDate()
    {
        var jsonFilter = GetExpectedFilter(_firstDateOutput, "gt");

        var builder = new JotformFilterBuilder();        
        builder.AddGreaterThan(_fieldName, _firstDateOf2020);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddGreaterThan_IsCalledWithValidDateAndMinusOneSecondTrue()
    {
        var jsonFilter = GetExpectedFilter(
            _firstDateMinus1SecondOutput, "gt");

        var builder = new JotformFilterBuilder();
        builder.AddGreaterThan(_fieldName, _firstDateOf2020, true);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddLessThan_IsCalledWithValidDate()
    {
        var jsonFilter = GetExpectedFilter(_lastDateOutput, "lt");

        var builder = new JotformFilterBuilder();       
        builder.AddLessThan(_fieldName, _lastDateOf2020);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddLessThan_IsCalled_WithValidDateAndPlusOneSecondOrDayTrue()
    {
        var jsonFilter = GetExpectedFilter(
            _lastDatePlus1DayOutput, "lt");

        var builder = new JotformFilterBuilder();
        builder.AddLessThan(_fieldName, _lastDateOf2020, true);

        builder.AssertBuildReturnsJson(jsonFilter);
    }

    [Fact]
    public void Build_ReturnsValidJson_If_AddLessThan_IsCalled_WithValidDateAndPlusOneSecondOrDayTrue_2()
    {
        var jsonFilter = GetExpectedFilter(
            _lastDatePlus1DayOutput, "lt");
        var lastDateOf2020AtLastSecond = _lastDateOf2020
            .AddDays(1).AddSeconds(-1);

        var builder = new JotformFilterBuilder();
        builder.AddLessThan(_fieldName, lastDateOf2020AtLastSecond, true);

        builder.AssertBuildReturnsJson(jsonFilter);
    }
}