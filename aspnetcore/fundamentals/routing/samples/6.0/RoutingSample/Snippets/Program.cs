using RoutingSample.Routing;

namespace RoutingSample.Snippets
{
    public static class Program
    {
        public static void RegexMap(WebApplication app)
        {
            // <snippet_RegexMapGet>
            app.MapGet("{message:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}",
                () => "Inline Regex Constraint Matched");
            // </snippet_RegexMapGet>

            // <snippet_RegExMapControllerRoute>
            app.MapControllerRoute(
                name: "people",
                pattern: "people/{ssn}",
                constraints: new { ssn = "^\\d{3}-\\d{2}-\\d{4}$", },
                defaults: new { controller = "People", action = "List" });
            // </snippet_RegExMapControllerRoute>
        }

        public static void AddRoutingConstraintMap(WebApplicationBuilder builder)
        {
            // <snippet_AddRoutingConstraintMap>
            builder.Services.AddRouting(options =>
                options.ConstraintMap.Add("noZeroes", typeof(NoZeroesRouteConstraint)));
            // </snippet_AddRoutingConstraintMap>
        }

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
