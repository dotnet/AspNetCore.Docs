using FiltersSample.Filters;

namespace FiltersSample.Snippets;

public static class Program
{
    public static void AddFilterOrder(WebApplicationBuilder builder)
    {
        // <snippet_AddFilterOrder>
        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add<GlobalSampleActionFilter>(int.MinValue);
        });
        // </snippet_AddFilterOrder>
    }
}
