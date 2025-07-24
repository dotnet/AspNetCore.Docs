#define Version2 // Version1 / Version2 / Version3 / Version 3b / Version 3c / Version4
using Microsoft.AspNetCore.OutputCaching;
using OCMinimal;
using System.Globalization;

namespace OCControllers;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

#if Version1
        //<policies1>
        builder.Services.AddOutputCache(options =>
        {
            options.AddBasePolicy(builder => 
                builder.Expire(TimeSpan.FromSeconds(10)));
            options.AddPolicy("Expire20", builder => 
                builder.Expire(TimeSpan.FromSeconds(20)));
            options.AddPolicy("Expire30", builder => 
                builder.Expire(TimeSpan.FromSeconds(30)));
        });
        //</policies1>
#endif
#if Version2
        //<policies2>
        builder.Services.AddOutputCache(options =>
        {
            options.AddBasePolicy(builder => builder
                .With(c => c.HttpContext.Request.Path.StartsWithSegments("/blog"))
                .Tag("tag-blog"));
            options.AddBasePolicy(builder => builder.Tag("tag-all"));
            options.AddPolicy("Query", builder => builder.SetVaryByQuery("culture"));
            options.AddPolicy("NoCache", builder => builder.NoCache());
            options.AddPolicy("NoLock", builder => builder.SetLocking(false));
            options.AddPolicy("VaryByValue", builder => 
                builder.VaryByValue((context) =>
                    new KeyValuePair<string, string>(
                    "time", (DateTime.Now.Second % 2)
                        .ToString(CultureInfo.InvariantCulture))));
        });
        //</policies2>
#endif
#if Version3
        //<policies3>
        builder.Services.AddOutputCache(options =>
        {
            options.AddBasePolicy(builder => builder.Cache());
        });
        //</policies3>
#endif
#if Version3b
        //<policies3b>
        builder.Services.AddOutputCache(options =>
        {
            options.AddPolicy("CachePost", MyCustomPolicy.Instance);
        });
        //</policies3b>
#endif
#if Version3c
        //<policies3c>
        builder.Services.AddOutputCache(options =>
        {
            options.AddBasePolicy(builder =>
                builder.AddPolicy<MyCustomPolicy2>(), true);
        });
        //</policies3c>
#endif
#if Version4
        //<policies4>
        builder.Services.AddOutputCache();
        //</policies4>
#endif
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseOutputCache();
        app.UseAuthorization();

        app.MapControllers();
        
        app.Run();
    }
}
