public class Program
{
    public static IHostingEnvironment HostingEnvironment { get; set; }
    public static IConfiguration Configuration { get; set; }

    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
            })
            .ConfigureServices(services =>
            {
                ...
            })
            .Configure(app =>
            {
                var loggerFactory = app.ApplicationServices
                    .GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<Program>();
                var env = app.ApplicationServices.GetRequiredServices<IHostingEnvironment>();
                var config = app.ApplicationServices.GetRequiredServices<IConfiguration>();

                logger.LogInformation("Logged in Configure");

                if (env.IsDevelopment())
                {
                    ...
                }
                else
                {
                    ...
                }

                var configValue = config["subsection:suboption1"];

                ...
            });
}
