namespace HandleErrorsSample.Snippets;

public static class Program
{
    public static void ConsistentEnvironments(WebApplication app)
    {
        // <snippet_ConsistentEnvironments>
        if (app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error-development");
        }
        else
        {
            app.UseExceptionHandler("/error");
        }
        // </snippet_ConsistentEnvironments>
    }
}
