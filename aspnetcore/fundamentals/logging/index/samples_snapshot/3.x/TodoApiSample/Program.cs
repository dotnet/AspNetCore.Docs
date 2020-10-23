public static void Main(string[] args)
{
    var host = CreateHostBuilder(args).Build();

    var todoRepository = host.Services.GetRequiredService<ITodoRepository>();
    todoRepository.Add(new Core.Model.TodoItem() { Name = "Feed the dog" });
    todoRepository.Add(new Core.Model.TodoItem() { Name = "Walk the dog" });

    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Seeded the database.");

    IMyService myService = host.Services.GetRequiredService<IMyService>();
    myService.WriteLog("Logged from MyService.");

    host.Run();
}

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
