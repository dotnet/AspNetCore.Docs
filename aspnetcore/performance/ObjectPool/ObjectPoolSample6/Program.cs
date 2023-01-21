using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;
using ObjectPoolSample;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
builder.Services.TryAddSingleton<ObjectPool<StringBuilder>>(serviceProvider =>
{
    var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
    var policy = new Microsoft.Extensions.ObjectPool.StringBuilderPooledObjectPolicy();
    return provider.Create(policy);
});

builder.Services.AddWebEncoders();

var app = builder.Build();

// Test using /?firstname=Steve&lastName=Gordon&day=28&month=9
app.UseMiddleware<BirthdayMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
