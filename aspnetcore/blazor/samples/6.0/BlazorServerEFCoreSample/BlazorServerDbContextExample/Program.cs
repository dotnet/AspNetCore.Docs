using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BlazorServerDbContextExample;
using BlazorServerDbContextExample.Data;
using BlazorServerDbContextExample.Grid;
using BlazorServerDbContextExample.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// register factory and configure the options
#region snippet1
builder.Services.AddDbContextFactory<ContactContext>(opt =>
    opt.UseSqlite($"Data Source={nameof(ContactContext.ContactsDb)}.db"));
#endregion

// pager
builder.Services.AddScoped<IPageHelper, PageHelper>();

// filters
builder.Services.AddScoped<IContactFilters, GridControls>();

// query adapter (applies filter to contact request).
builder.Services.AddScoped<GridQueryAdapter>();

// service to communicate success on edit between pages
builder.Services.AddScoped<EditSuccess>();

var app = builder.Build();

// this section sets up and seeds the database. It would NOT normally
// be done this way in production. It is here to make the sample easier,
// i.e. clone, set connection string and run.
await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<ContactContext>>();
await DatabaseUtility.EnsureDbCreatedAndSeedWithCountOfAsync(options, 500);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
