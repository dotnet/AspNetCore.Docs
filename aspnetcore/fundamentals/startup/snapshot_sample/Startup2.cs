public class Startup
{
    public Startup(IHostingEnvironment env, IConfiguration config)
    {
        HostingEnvironment = env;
        Configuration = config;
    }

    public IHostingEnvironment HostingEnvironment { get; }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        if (HostingEnvironment.IsDevelopment())
        {
            // Development configuration
        }
        else
        {
            // Staging/Production configuration
        }

        // Configuration is available during startup. Examples:
        // Configuration["key"]
        // Configuration["subsection:suboption1"]
    }
}
