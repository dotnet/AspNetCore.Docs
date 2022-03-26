using MiddlewareExtensibilitySample.Data;

namespace MiddlewareExtensibilitySample.Middleware;

// <snippet_Class>
public class ConventionalMiddleware
{
    private readonly RequestDelegate _next;

    public ConventionalMiddleware(RequestDelegate next)
        => _next = next;

    public async Task InvokeAsync(HttpContext context, SampleDbContext dbContext)
    {
        var keyValue = context.Request.Query["key"];

        if (!string.IsNullOrWhiteSpace(keyValue))
        {
            dbContext.Requests.Add(new Request("Conventional", keyValue));

            await dbContext.SaveChangesAsync();
        }

        await _next(context);
    }
}
// </snippet_Class>
