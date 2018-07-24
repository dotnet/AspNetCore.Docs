public class Startup
{
    private readonly IHostingEnvironment _env;
    private readonly IConfiguration _config;
    private readonly ILogger<Startup> _logger;

    public Startup(IHostingEnvironment env, IConfiguration config, 
        ILogger<Startup> logger)
    {
        _env = env;
        _config = config;
        _logger = logger;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_env.IsDevelopment())
        {
            // Development service configuration

            _logger.LogInformation("Development environment");
        }
        else
        {
            // Non-development service configuration

            _logger.LogInformation($"Environment: {_env.EnvironmentName}");
        }

        // Configuration is available during startup.
        // Examples:
        //   _config["key"]
        //   _config["subsection:suboption1"]
    }
}
