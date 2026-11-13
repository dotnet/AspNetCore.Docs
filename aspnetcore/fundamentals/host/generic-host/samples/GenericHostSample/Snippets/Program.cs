namespace GenericHostSample.Snippets;

public static class Program
{
    public static async Task HostConfigureWebHostDefaults(string[] args)
    {
        // <snippet_HostConfigureWebHostDefaults>
        await Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build()
            .RunAsync();
        // </snippet_HostConfigureWebHostDefaults>
    }

    public static void ConfigureHostConfiguration(string[] args)
    {
        // <snippet_ConfigureHostConfiguration>
        Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(hostConfig =>
            {
                hostConfig.SetBasePath(Directory.GetCurrentDirectory());
                hostConfig.AddJsonFile("hostsettings.json", optional: true);
                hostConfig.AddEnvironmentVariables(prefix: "PREFIX_");
                hostConfig.AddCommandLine(args);
            });
        // </snippet_ConfigureHostConfiguration>
    }

    public static void UseContentRoot(string[] args)
    {
        // <snippet_UseContentRoot>
        Host.CreateDefaultBuilder(args)
            .UseContentRoot("/path/to/content/root")
            // ...
            // </snippet_UseContentRoot>
            ;
    }

    public static void UseEnvironment(string[] args)
    {
        // <snippet_UseEnvironment>
        Host.CreateDefaultBuilder(args)
            .UseEnvironment("Development")
            // ...
            // </snippet_UseEnvironment>
            ;
    }

    public static void ShutdownTimeout(string[] args)
    {
        // <snippet_ShutdownTimeout>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.Configure<HostOptions>(options =>
                {
                    options.ShutdownTimeout = TimeSpan.FromSeconds(20);
                });
            });
        // </snippet_ShutdownTimeout>
    }

    public static void ConfigureWebHostDefaults(string[] args)
    {
        // <snippet_ConfigureWebHostDefaults>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                // ...
            });
        // </snippet_ConfigureWebHostDefaults>
    }

    public static void WebHostBuilder(WebHostBuilder webBuilder)
    {
        // <snippet_WebHostBuilderCaptureStartupErrors>
        webBuilder.CaptureStartupErrors(true);
        // </snippet_WebHostBuilderCaptureStartupErrors>

        // <snippet_WebHostBuilderDetailedErrors>
        webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
        // </snippet_WebHostBuilderDetailedErrors>

        // <snippet_WebHostBuilderHostingStartupAssemblies>
        webBuilder.UseSetting(
            WebHostDefaults.HostingStartupAssembliesKey, "assembly1;assembly2");
        // </snippet_WebHostBuilderHostingStartupAssemblies>

        // <snippet_WebHostBuilderHostingStartupExcludeAssemblies>
        webBuilder.UseSetting(
            WebHostDefaults.HostingStartupExcludeAssembliesKey, "assembly1;assembly2");
        // </snippet_WebHostBuilderHostingStartupExcludeAssemblies>

        // <snippet_WebHostBuilderHttpsPort>
        webBuilder.UseSetting("https_port", "8080");
        // </snippet_WebHostBuilderHttpsPort>

        // <snippet_WebHostBuilderPreferHostingUrls>
        webBuilder.PreferHostingUrls(true);
        // </snippet_WebHostBuilderPreferHostingUrls>

        // <snippet_WebHostBuilderPreventHostingStartup>
        webBuilder.UseSetting(WebHostDefaults.PreventHostingStartupKey, "true");
        // </snippet_WebHostBuilderPreventHostingStartup>

        // <snippet_WebHostBuilderUseStartup>
        webBuilder.UseStartup("StartupAssemblyName");
        // </snippet_WebHostBuilderUseStartup>

        // <snippet_WebHostBuilderUseStartupGeneric>
        webBuilder.UseStartup<Startup>();
        // </snippet_WebHostBuilderUseStartupGeneric>

        // <snippet_WebHostBuilderSuppressStatusMessages>
        webBuilder.UseSetting(WebHostDefaults.SuppressStatusMessagesKey, "true");
        // </snippet_WebHostBuilderSuppressStatusMessages>

        // <snippet_WebHostBuilderUseUrls>
        webBuilder.UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002");
        // </snippet_WebHostBuilderUseUrls>

        // <snippet_WebHostBuilderUseWebRoot>
        webBuilder.UseWebRoot("public");
        // </snippet_WebHostBuilderUseWebRoot>
    }

    public class Startup { }
}
