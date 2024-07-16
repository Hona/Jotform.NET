using System.Text.Json;

namespace Jotform.Models.Shared;

public class JotformFilterBuilder
{
    protected readonly Dictionary<string, object> _fields = new();

    public JotformFilterBuilder AddCriteria<TValue>(
        string field, TValue? value)
    {
        if (value is null) return this;
        if (value is DateTime dateTime)
            _fields.Add(field, dateTime.ToString("yyyy-MM-dd hh:mm:ss"));
        else
            _fields.Add(field, value.ToString()!);

        return this;
    }

    public JotformFilterBuilder AddCriteria(
        string field, IEnumerable<string> values)
    {
        if (!values.Any()) return this;
        _fields.Add(field, values);
        return this;
    }

    public JotformFilterBuilder AddCriteria<TValue>(
        string field, string comparision, TValue? value)
    {
        return AddCriteria(field + ":" + comparision, value);
    }

    public JotformFilterBuilder AddGreaterThan<TValue>(
        string field, TValue? value)
    {
        return AddCriteria(field, "gt", value);
    }

    public JotformFilterBuilder AddLessThan<TValue>(
        string field, TValue? value)
    {
        return AddCriteria(field, "lt", value);
    }

    public JotformFilterBuilder AddNotEqualTo<TValue>(
        string field, TValue? value)
    {
        return AddCriteria(field, "ne", value);
    }

    public JotformFilterBuilder AddMatches<TValue>(
        string field, TValue? value)
    {
        return AddCriteria(field, "matches", value);
    }

    public JotformFilterBuilder AddGreaterThan(
        string field, DateTime? value, bool minusOneDay = false)
    {
        return AddCriteria(field, "gt", 
            minusOneDay ? value?.AddDays(-1.0) : value);
    }

    public JotformFilterBuilder AddLessThan(
        string field, DateTime? value, bool plusOneDay = false)
    {
        return AddCriteria(field, "lt", 
            plusOneDay ? value?.AddDays(1.0) : value);
    }

    public JotformFilterBuilder AddDateRange(
        string field, DateTime? start, DateTime? end, 
        bool minusOneDayFromStart = true, 
        bool plusOneDayToEnd = true)
    {
        return AddGreaterThan(field, start, minusOneDayFromStart)
            .AddLessThan(field, end, plusOneDayToEnd);
    }

    public JotformFilterBuilder AddCreatedAtDateRange(
        DateTime? start, DateTime? end, 
        bool minusOneDayFromStart = true,
        bool plusOneDayToEnd = true)
    {
        return AddDateRange("created_at", start, end,
            minusOneDayFromStart, plusOneDayToEnd);
    }

    public JotformFilterBuilder AddUpdatedAtDateRange(
        DateTime? start, DateTime? end,
        bool minusOneDayFromStart = true,
        bool plusOneDayToEnd = true)
    {
        return AddDateRange("updated_at", start, end,
            minusOneDayFromStart, plusOneDayToEnd);
    }

    public string? Build()
    {
        if (_fields.Count == 0) return null;
        return JsonSerializer.Serialize(_fields);
    }
}