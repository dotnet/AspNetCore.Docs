using HttpContextInBackgroundThread;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddSingleton(typeof(IAsyncConcurrentQueue<>), typeof(AsyncConcurrentQueue<>));
builder.Services.AddHostedService<NewsletterService>();

var app = builder.Build();

app.MapGet("/send", (IEmailService service) => service.SendEmail("microsoft@aka.ms" ));

app.Run();
