using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp1.Areas.Identity.Data;
using WebApp1.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebApp1ContextConnection");builder.Services.AddDbContext<WebApp1Context>(options =>
    options.UseSqlServer(connectionString));builder.Services.AddDefaultIdentity<WebApp1User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WebApp1Context>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
