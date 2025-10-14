using System.Reflection;

namespace CustomBindingExample;

public class ValidatedParameter : IBindableFromHttpContext<ValidatedParameter>
{
    public string Value { get; init; } = default!;

    public static ValueTask<ValidatedParameter?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        // Get the value from a query parameter
        var value = context.Request.Query["value"].ToString();
        
        // Perform some basic validation here
        if (string.IsNullOrEmpty(value))
        {
            // Return an empty instance - the controller action will handle the validation failure
            return ValueTask.FromResult<ValidatedParameter?>(new ValidatedParameter
            {
                Value = string.Empty
            });
        }
        
        return ValueTask.FromResult<ValidatedParameter?>(new ValidatedParameter
        {
            Value = value
        });
    }
}