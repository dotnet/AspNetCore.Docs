namespace WebMinAPIs.Snippets;

public static class Program
{
    public static void ManualRequestBinding(WebApplication app)
    {
        // <snippet_ManualRequestBinding>
        app.MapGet("/{id}", (HttpRequest request) =>
        {
            var id = request.RouteValues["id"];
            var page = request.Query["page"];
            var customHeader = request.Headers["X-CUSTOM-HEADER"];

            // ...
        });

        app.MapPost("/", async (HttpRequest request) =>
        {
            var person = await request.ReadFromJsonAsync<Person>();

            // ...
        });
        // </snippet_ManualRequestBinding>
    }

    private record Person;
}
