using System.Reflection;

namespace CustomBindingExample;

public class CustomBoundParameter : IBindableFromHttpContext<CustomBoundParameter>
{
    public string Value { get; init; } = default!;

    public static ValueTask<CustomBoundParameter?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        // Custom binding logic here
        // This example reads from a custom header
        var value = context.Request.Headers["X-Custom-Header"].ToString();
        
        // If no header was provided, you could fall back to a query parameter
        if (string.IsNullOrEmpty(value))
        {
            value = context.Request.Query["customValue"].ToString();
        }
        
        return ValueTask.FromResult<CustomBoundParameter?>(new CustomBoundParameter 
        {
            Value = value
        });
    }
}