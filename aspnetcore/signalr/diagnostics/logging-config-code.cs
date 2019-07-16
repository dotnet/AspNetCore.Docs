public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging(logging =>
        {
            logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Debug);
            logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.Debug);
        })
        .UseStartup<Startup>();