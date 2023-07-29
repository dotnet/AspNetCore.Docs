using Microsoft.AspNetCore.OutputCaching;

namespace OCMinimal;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // <redis>
        builder.Services.AddStackExchangeRedisOutputCache(options =>
        {
            options.Configuration = 
                builder.Configuration.GetConnectionString("MyRedisConStr");
            options.InstanceName = "SampleInstance";
        });

        builder.Services.AddOutputCache(options =>
        {
            options.AddBasePolicy(builder => 
                builder.Expire(TimeSpan.FromSeconds(10)));
        });
        // </redis>

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();
        app.UseOutputCache();

        app.MapGet("/", Gravatar.WriteGravatar);

        app.MapGet("/cached", Gravatar.WriteGravatar).CacheOutput();
        app.MapGet("/attribute", [OutputCache] (context) => 
            Gravatar.WriteGravatar(context));

        app.Run();
    }
}
