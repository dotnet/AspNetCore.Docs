using Microsoft.EntityFrameworkCore;

using App.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add the CatalogContext to the DI container
builder.Services.AddDbContext<AppDb>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AppDb")));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await AppDbSeeder.Seed(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapCustomerApi();

app.Run();
