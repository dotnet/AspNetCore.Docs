namespace RoutingSample.Snippets
{
    public static class Program
    {
        public static void MapControllerRoute(WebApplication app)
        {
            // <snippet_MapControllerRoute>
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller:slugify=Home}/{action:slugify=Index}/{id?}");
            // </snippet_MapControllerRoute>
        }

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
