    public IConfigurationRoot Configuration { get; } 

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // <-- This loads the default appsettings.json file
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)// <-- This loads an appsettings.json file dependent on an environment variable
          .AddEnvironmentVariables();                                            // <-- This loads ASP.Net Core Environment Variables
      Configuration = builder.Build();
    }

