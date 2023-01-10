using SampleApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddHostedService<ServiceA>();

builder.Host.UseWindowsService();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
await app.RunAsync();
