using BackgroundTasksWebSample.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<TimedHostedService>();

builder.Services.AddHostedService<ConsumeScopedServiceHostedService>();
builder.Services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

builder.Services.AddHostedService<QueuedHostedService>();
builder.Services.AddSingleton<IBackgroundTaskQueue>(_ =>
    new BackgroundTaskQueue(builder.Configuration.GetValue("QueueCapacity", 100)));

var app = builder.Build();

app.MapGet("/", () => "Hosted service is running in the background.");

app.MapPost("/queue", async (
    IBackgroundTaskQueue taskQueue,
    ILogger<Program> logger,
    CancellationToken cancellationToken) =>
{
    await taskQueue.QueueBackgroundWorkItemAsync(async token =>
    {
        var guid = Guid.NewGuid();

        logger.LogInformation("Queued Background Task {Guid} is starting.", guid);

        try
        {
            await Task.Delay(TimeSpan.FromSeconds(5), token);
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation("Queued Background Task {Guid} was cancelled.", guid);

            return;
        }

        logger.LogInformation("Queued Background Task {Guid} is complete.", guid);
    }, cancellationToken);

    return Results.Accepted();
});

app.Run();
