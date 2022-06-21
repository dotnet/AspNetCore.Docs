#define FIRST // FIRST
#if NEVER
#elif FIRST
#region snippet1
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

string HelloName(string name) => $"Hello, {name}!";

app.MapGet("/hello/{name}", HelloName)
    .AddFilter(async (routeHandlerInvocationContext, next) =>
    {
        var name = (string)routeHandlerInvocationContext.Arguments[0]!;
        if (name == "Bob")
        {
            return Results.Problem("Bob not allowed!");
        }
        return await next(routeHandlerInvocationContext);
    });

app.Run();
#endregion
#endif

