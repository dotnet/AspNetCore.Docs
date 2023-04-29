#define WithUseExceptionHandler // WithUseExceptionHandler, WithStatusCodesPage

#if WithUseExceptionHandler
#region snippet_WithUseExceptionHandler
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async httpContext =>
    {
        var problemDetailsService = httpContext.RequestServices.GetService<IProblemDetailsService>();
        if (problemDetailsService == null
            || !await problemDetailsService.TryWriteAsync(new() { HttpContext = httpContext }))
        {
            // Your fallback behavior, since problem details were not able to be written.
            await httpContext.Response.WriteAsync("An error occurred.");
        }
    });
});

app.MapGet("/exception", () => 
{
    throw new InvalidOperationException("Sample Exception");
});

app.Run();
#endregion
#elif WithStatusCodesPage
#region snippet_WithStatusCodesPage
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseStatusCodePages(statusCodeHandlerApp =>
{
    statusCodeHandlerApp.Run(async httpContext =>
    {
        var problemDetailsService = httpContext.RequestServices.GetService<IProblemDetailsService>();
        if (problemDetailsService == null
            || !await problemDetailsService.TryWriteAsync(new() { HttpContext = httpContext }))
        {
            // Your fallback behavior, since problem details were not able to be written.
            await httpContext.Response.WriteAsync("An error occurred.");
        }
    });
});

app.MapGet("/users/{id:int}", (int id) =>
{
    return id <= 0 ? Results.BadRequest() : Results.Ok(new User(id));
});

app.Run();
#endregion
#endif 

public record User(int Id);