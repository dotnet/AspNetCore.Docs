namespace WebMinAPIs.Snippets;

public static class Program
{
    public static void ManualRequestBinding(WebApplication app)
    {
        // <snippet_ManualRequestBinding>
        app.MapGet("/{id}", (HttpContext context) =>
        {
            var id = context.Request.RouteValues["id"];
            var page = context.Request.Query["page"];
            var customHeader = context.Request.Headers["X-CUSTOM-HEADER"];

            // ...
        });

        app.MapPost("/", async (HttpContext context) =>
        {
            var person = await context.Request.ReadFromJsonAsync<Person>();

            // ...
        });
        // </snippet_ManualRequestBinding>
    }

    private record Person;
}
