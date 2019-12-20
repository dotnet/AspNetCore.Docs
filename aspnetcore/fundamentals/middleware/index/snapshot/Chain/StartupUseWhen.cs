public class Startup
{
    private readonly ILogger<Startup> _logger;

    public Startup(ILogger<Startup> logger)
    {
        _logger = logger;
    }

    private void HandleBranchAndRejoin(IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            var branchVer = context.Request.Query["branch"];
            _logger.LogInformation("Branch used = {branchVer}", branchVer);

            // Do work that doesn't write to the Response.
            await next();
            // Do other work that doesn't write to the Response.
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseWhen(context => context.Request.Query.ContainsKey("branch"),
                               HandleBranchAndRejoin);

        app.Run(async context =>
        {
            await context.Response.WriteAsync("Hello from main pipeline.");
        });
    }
}
