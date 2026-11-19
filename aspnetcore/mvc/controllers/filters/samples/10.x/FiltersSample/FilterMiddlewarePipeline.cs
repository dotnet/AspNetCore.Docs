namespace FiltersSample;

// <snippet_Class>
public class FilterMiddlewarePipeline
{
    public void Configure(IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Append("Pipeline", "Middleware");

            await next();
        });
    }
}
// </snippet_Class>
