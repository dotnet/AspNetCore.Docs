// using Microsoft.EntityFrameworkCore;

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddEFConfiguration(
                options => options.UseInMemoryDatabase("InMemoryDb"));
        })
