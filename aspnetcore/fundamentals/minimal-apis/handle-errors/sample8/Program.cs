#define WithUseExceptionHandler // ThrowExceptions, WithUseExceptionHandler, ClientAndServerErrorResponses, ClientAndServerErrorResponsesWithUseStatusCodePages, ProblemDetails, IProblemDetailsServiceWithExceptionFallback, IProblemDetailsServiceWithStatusCodePageFallback

#if ThrowExceptions
// <snippet_ThrowExceptions>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/exception", () => 
{
    throw new InvalidOperationException("Sample Exception");
});

app.MapGet("/", () => "Test by calling /exception");

app.Run();
// </snippet_ThrowExceptions>
#elif WithUseExceptionHandler
// <snippet_WithUseExceptionHandler>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp 
    => exceptionHandlerApp.Run(async context 
        => await Results.Problem()
                     .ExecuteAsync(context)));

app.MapGet("/exception", () => 
{
    throw new InvalidOperationException("Sample Exception");
});

app.MapGet("/", () => "Test by calling /exception");

app.Run();
// </snippet_WithUseExceptionHandler>
#elif ClientAndServerErrorResponses
// <snippet_ClientAndServerErrorResponses>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/users/{id:int}", (int id) 
    => id <= 0 ? Results.BadRequest() : Results.Ok(new User(id)));

app.MapGet("/", () => "Test by calling /users/{id:int}");

app.Run();

public record User(int Id);
// </snippet_ClientAndServerErrorResponses>
#elif ClientAndServerErrorResponsesWithUseStatusCodePages
// <snippet_ClientAndServerErrorResponsesWithUseStatusCodePages>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStatusCodePages(async statusCodeContext 
    => await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode)
                 .ExecuteAsync(statusCodeContext.HttpContext));

app.MapGet("/users/{id:int}", (int id) 
    => id <= 0 ? Results.BadRequest() : Results.Ok(new User(id)) );

app.MapGet("/", () => "Test by calling /users/{id:int}");

app.Run();

public record User(int Id);
// </snippet_ClientAndServerErrorResponsesWithUseStatusCodePages>
#elif ProblemDetails
// <snippet_ProblemDetails>
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

app.MapGet("/users/{id:int}", (int id) 
    => id <= 0 ? Results.BadRequest() : Results.Ok(new User(id)));

app.MapGet("/", () => "Test by calling /users/{id:int}");

app.Run();

public record User(int Id);
// </snippet_ProblemDetails>
#elif IProblemDetailsServiceWithExceptionFallback
// <snippet_IProblemDetailsServiceWithExceptionFallback>
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
// </snippet_IProblemDetailsServiceWithExceptionFallback>
#elif IProblemDetailsServiceWithStatusCodePageFallback
// <snippet_IProblemDetailsServiceWithStatusCodePageFallback>
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

public record User(int Id);
// </snippet_IProblemDetailsServiceWithStatusCodePageFallback>
#endif 
