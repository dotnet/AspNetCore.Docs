public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseHttpSys(options =>
            {
                options.UrlPrefixes.Add("https://10.0.0.4:443");
            });
            webBuilder.UseStartup<Startup>();
        });
