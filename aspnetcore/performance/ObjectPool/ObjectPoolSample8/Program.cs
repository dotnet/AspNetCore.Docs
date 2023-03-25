using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;
using ObjectPoolSample;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
builder.Services.TryAddSingleton<ObjectPool<StringBuilder>>(serviceProvider =>
{
    var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
    var policy = new StringBuilderPolicy();
    return provider.Create(policy);
});

builder.Services.AddWebEncoders();

var app = builder.Build();

// Test using /?firstname=Steve&lastName=Gordon&day=28&month=9
app.UseMiddleware<BirthdayMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();



public class ReusableStringBuilder : IResettable
{
    public StringBuilder Data { get; } = new StringBuilder();

    public bool TryReset()
    {
        Data.Clear();
        return true;
    }
}

class StringBuilderPolicy : IPooledObjectPolicy<StringBuilder>
{
    public ReusableStringBuilder? reusableStringBuilder;
    public StringBuilder Create()
    {
        reusableStringBuilder = new ReusableStringBuilder();
        return reusableStringBuilder.Data;
    }

    public bool Return(StringBuilder obj)
    {
        return reusableStringBuilder!.TryReset();
    }
}
