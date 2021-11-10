#define SQL_PRODUCTION
#if SQL_PRODUCTION
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<SchoolContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SchoolContext")));
}
else
{
    builder.Services.AddDbContext<SchoolContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContextSQLite")));
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endif