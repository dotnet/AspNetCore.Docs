namespace RoutingSample.Snippets
{
    public static class Program
    {
        public static void RequireHost(WebApplication app)
        {
            // <snippet_RequireHost>
            app.MapGet("/", () => "Contoso").RequireHost("contoso.com");
            app.MapGet("/", () => "AdventureWorks").RequireHost("adventure-works.com");

            app.MapHealthChecks("/healthz").RequireHost("*:8080");
            // </snippet_RequireHost>
        }
    }
}
