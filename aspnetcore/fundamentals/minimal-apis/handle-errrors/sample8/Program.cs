#define WithUseExceptionHandler // WithUseExceptionHandler, WithStatusCodesPage

#if WithUseExceptionHandler
// <snippet_WithUseExceptionHandler>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async httpContext =>
    {
        var pds = httpContext.RequestServices.GetService<IProblemDetailsService>();
        if (pds == null
            || !await pds.TryWriteAsync(new() { HttpContext = httpContext }))
        {
            // Fallback behavior
            await httpContext.Response.WriteAsync("Fallback: An error occurred.");
        }
    });
});

app.MapGet("/exception", () => 
{
    throw new InvalidOperationException("Sample Exception");
});

app.MapGet("/", () => "Test by calling /exception");

app.Run();
// </snippet_WithUseExceptionHandler>
#elif WithStatusCodesPage
// <snippet_WithStatusCodesPage>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseStatusCodePages(statusCodeHandlerApp =>
{
    statusCodeHandlerApp.Run(async httpContext =>
    {
        var pds = httpContext.RequestServices.GetService<IProblemDetailsService>();
        if (pds == null
            || !await pds.TryWriteAsync(new() { HttpContext = httpContext }))
        {
            // Fallback behavior
            await httpContext.Response.WriteAsync("Fallback: An error occurred.");
        }
    });
});

app.MapGet("/users/{id:int}", (int id) =>
{
    return id <= 0 ? Results.BadRequest() : Results.Ok(new User(id));
});

app.MapGet("/", () => "Test by calling /users/{id:int}");

app.Run();
// </snippet_WithStatusCodesPage>
#endif 
public record User(int Id);
