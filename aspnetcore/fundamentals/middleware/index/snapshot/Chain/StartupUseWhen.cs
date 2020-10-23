public class Startup
{
    private void HandleBranchAndRejoin(IApplicationBuilder app, ILogger<Startup> logger)
    {
        app.Use(async (context, next) =>
        {
            var branchVer = context.Request.Query["branch"];
            logger.LogInformation("Branch used = {branchVer}", branchVer);

            // Do work that doesn't write to the Response.
            await next();
            // Do other work that doesn't write to the Response.
        });
    }

    public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
    {
        app.UseWhen(context => context.Request.Query.ContainsKey("branch"),
                               appBuilder => HandleBranchAndRejoin(appBuilder, logger));

        app.Run(async context =>
        {
            await context.Response.WriteAsync("Hello from main pipeline.");
        });
    }
}
