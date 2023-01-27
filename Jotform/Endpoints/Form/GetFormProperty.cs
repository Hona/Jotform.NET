using System.Linq.Expressions;
using System.Reflection;

namespace Jotform;

public partial class JotformClient
{
    public async Task<JotformResult<FormProperties>?> GetFormPropertyAsync(string formId, Expression<Func<FormProperties, object>> property, CancellationToken cancellationToken = default)
    {
        MemberInfo GetCorrectPropertyMemberInfo<T>(Expression<Func<T, object>> expression)
        {
            if (expression.Body is MemberExpression memberExpression) {
                return memberExpression.Member;
            }

            var op = ((UnaryExpression)expression.Body).Operand;
            return ((MemberExpression)op).Member;
        }
        
        // Get the JsonPropertyName from the expression
        var selectedProperty = GetCorrectPropertyMemberInfo(property);
        
        var jsonProperty = selectedProperty.CustomAttributes
            .FirstOrDefault(x => x.AttributeType == typeof(JsonPropertyNameAttribute));
        
        if (jsonProperty is null)
        {
            throw new InvalidOperationException("JsonPropertyNameAttribute is null");
        }

        var propertyString = jsonProperty.ConstructorArguments.FirstOrDefault().Value?.ToString();
        
        return await _httpClient.GetFromJsonAsync<JotformResult<FormProperties>>($"form/{formId}/properties/{propertyString}", cancellationToken);
    }
}