#define Version3c // Version1 / Version2 / Version3 / Version 3b / Version 3c / Version4
using Microsoft.AspNetCore.OutputCaching;
using System.Globalization;

namespace OCMinimal;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

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
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();
        app.UseOutputCache();
        app.UseAuthorization();

        app.MapGet("/", Gravatar.WriteGravatar);

        //<oneendpoint>
        app.MapGet("/cached", Gravatar.WriteGravatar).CacheOutput();
        app.MapGet("/attribute", [OutputCache] (context) => 
            Gravatar.WriteGravatar(context));
        //</oneendpoint>

        //<selectpolicy>
        app.MapGet("/20", Gravatar.WriteGravatar).CacheOutput("Expire20");
        app.MapGet("/30", [OutputCache(PolicyName = "Expire30")] (context) => 
            Gravatar.WriteGravatar(context));
        //</selectpolicy>

        //<selectquery>
        app.MapGet("/query", Gravatar.WriteGravatar).CacheOutput("Query");
        //</selectquery>

        //<varybyvalue>
        app.MapGet("/varybyvalue", Gravatar.WriteGravatar)
            .CacheOutput(c => c.VaryByValue((context) => 
                new KeyValuePair<string, string>(
                    "time", (DateTime.Now.Second % 2)
                        .ToString(CultureInfo.InvariantCulture))));
        //</varybyvalue>

        //<etag>
        app.MapGet("/etag", async (context) =>
        {
            var etag = $"\"{Guid.NewGuid():n}\"";
            context.Response.Headers.ETag = etag;
            await Gravatar.WriteGravatar(context);

        }).CacheOutput();
        //</etag>


        // <tagendpoint>
        app.MapGet("/blog", Gravatar.WriteGravatar)
            .CacheOutput(builder => builder.Tag("tag-blog")); ;
        app.MapGet("/blog/post/{id}", Gravatar.WriteGravatar)
            .CacheOutput(builder => builder.Tag("tag-blog")); ;
        // </tagendpoint>

        // <taggroup>
        var blog = app.MapGroup("blog")
            .CacheOutput(builder => builder.Tag("tag-blog"));
        blog.MapGet("/", Gravatar.WriteGravatar);
        blog.MapGet("/post/{id}", Gravatar.WriteGravatar);
        // </taggroup>

        // <taggroupoverride>
        blog.MapGet("/post/{id}", Gravatar.WriteGravatar)
            .CacheOutput(x => x.Tag("tag-blog", "tag-blog-post-id"));
        // </taggroupoverride>

        // <evictbytag>
        app.MapPost("/purge/{tag}", async (IOutputCacheStore cache, string tag) =>
        {
            await cache.EvictByTagAsync(tag, default);
        });
        // </evictbytag>

        // <post>
        app.MapPost("/cachedpost", Gravatar.WriteGravatar)
            .CacheOutput("CachePost");
        // </post>

        // <postalt>
        app.MapPost("/cachedpost2", Gravatar.WriteGravatar);
        // </postalt>
        
        // <selectnolock>
        app.MapGet("/nolock", Gravatar.WriteGravatar)
            .CacheOutput("NoLock");
        // </selectnolock>

        app.Run();
    }
}
