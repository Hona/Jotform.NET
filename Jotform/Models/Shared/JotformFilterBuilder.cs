using System.Text.Json;

namespace Jotform.Models.Shared;

public class JotformFilterBuilder
{
    private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
    protected readonly Dictionary<string, object> _fields = [];

    public JotformFilterBuilder AddCriteria<TValue>(
        string field, TValue? value)
    {
        if (value is null) return this;
        if (value is DateTime dateTime)
            _fields.Add(field, dateTime.ToString(DATE_FORMAT));
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
        string field, DateTime? value, bool minusOneSecond = false)
    {
        if (value is null) return this;
        return AddCriteria(field, "gt", 
            minusOneSecond ? value?.AddSeconds(-1.0) : value);
    }

    public JotformFilterBuilder AddLessThan(
        string field, DateTime? value, bool plusOneSecondOrDay = false)
    {
        if (value is null) return this;
        var dateTime = value.Value;
        if (plusOneSecondOrDay)
        {
            dateTime = dateTime.TimeOfDay == TimeSpan.Zero
                ? dateTime.AddDays(1)
                : dateTime.AddSeconds(1);

        }
        return AddCriteria(field, "lt", dateTime);
    }

    public JotformFilterBuilder AddDateRange(
        string field, DateTime? start, DateTime? end, 
        bool minusOneSecondFromStart = true, 
        bool plusOneSecondOrDayToEnd = true)
    {
        return AddGreaterThan(field, start, minusOneSecondFromStart)
            .AddLessThan(field, end, plusOneSecondOrDayToEnd);
    }

    public JotformFilterBuilder AddCreatedAtDateRange(
        DateTime? start, DateTime? end, 
        bool minusOneSecondFromStart = true,
        bool plusOneSecondOrDayToEnd = true)
    {
        return AddDateRange("created_at", start, end,
            minusOneSecondFromStart, plusOneSecondOrDayToEnd);
    }

    public JotformFilterBuilder AddUpdatedAtDateRange(
        DateTime? start, DateTime? end,
        bool minusOneSecondFromStart = true,
        bool plusOneSecondOrDayToEnd = true)
    {
        return AddDateRange("updated_at", start, end,
            minusOneSecondFromStart, plusOneSecondOrDayToEnd);
    }

    public string? Build()
    {
        if (_fields.Count == 0) return null;
        return JsonSerializer.Serialize(_fields);
    }
}