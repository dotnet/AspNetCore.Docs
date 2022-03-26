using Microsoft.EntityFrameworkCore;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Middleware;

// <snippet_Services>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SampleDbContext>
    (options => options.UseInMemoryDatabase("SampleDb"));

builder.Services.AddTransient<FactoryActivatedMiddleware>();
// </snippet_Services>

// <snippet_Middleware>
var app = builder.Build();

app.UseConventionalMiddleware();
app.UseFactoryActivatedMiddleware();
// </snippet_Middleware>

app.MapGet("/", async (SampleDbContext dbContext) =>
    Results.Ok(await dbContext.Requests.ToListAsync()));

app.Run();
