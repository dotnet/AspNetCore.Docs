using HttpContextInBackgroundThread;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddHostedService<NewsletterService>();

var app = builder.Build();

app.MapGet("/send", (IEmailService service) => service.SendEmail("microsoft@aka.ms"));

app.Run();
