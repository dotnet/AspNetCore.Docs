using HttpContextInBackgroundThread;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddHostedService<BulkEmailService>();
builder.Services.AddHostedService<NewsletterService>();
builder.Services.AddSingleton<IBackgroundTaskQueue>(ctx =>
{
    if (!int.TryParse(builder.Configuration["QueueCapacity"], out var queueCapacity))
        queueCapacity = 100;
    return new BackgroundTaskQueue(queueCapacity);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/send", (IEmailService service, CancellationToken token) => service.SendEmail(token));

app.Run();
