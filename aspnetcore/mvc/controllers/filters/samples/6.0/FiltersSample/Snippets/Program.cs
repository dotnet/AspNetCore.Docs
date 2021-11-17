using FiltersSample.Snippets.Filters;

namespace FiltersSample.Snippets;

public static class Program
{
    public static void AddFilter(WebApplicationBuilder builder)
    {
        // <snippet_AddFilter>
        builder.Services.AddControllersWithViews(options =>
            options.Filters.Add<SampleActionFilter>());
        // </snippet_AddFilter>
    }
}
