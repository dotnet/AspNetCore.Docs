public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .UseHttpSys(options =>
        {
            options.UrlPrefixes.Add("https://10.0.0.4:443");
        });
