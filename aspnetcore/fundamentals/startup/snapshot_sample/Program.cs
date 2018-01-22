public class Program
{
    public static IHostingEnvironment HostingEnvironment { get; }
    public static IConfiguration Configuration { get; }

    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                HostingEnvironment = hostingContext.HostingEnvironment;
                Configuration = config.Build();
            })
            .ConfigureServices(services =>
            {
                services.AddMvc();
            })
            .Configure(app =>
            {
                if (HostingEnvironment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                }

                // Configuration is available during startup. Examples:
                // Configuration["key"]
                // Configuration["subsection:suboption1"]

                app.UseMvcWithDefaultRoute();
                app.UseStaticFiles();
            })
            .Build();
}
