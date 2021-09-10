#define THIRD // FIRST SECOND THIRD
#if FIRST
#region snippet_
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{    
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute("blog_route", "Blog",
        "Manage/{controller}/{action}/{id?}");
app.MapControllerRoute("default_route", "{controller}/{action}/{id?}");

app.Run();
#endregion
#elif SECOND
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
#region snippet_2
app.MapControllerRoute("blog_route", "Manage/{controller}/{action}/{id?}",
        defaults: new { area = "Blog" }, constraints: new { area = "Blog" });
app.MapControllerRoute("default_route", "{controller}/{action}/{id?}");
#endregion

app.Run();
#elif THIRD
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
#region snippet_3
app.MapAreaControllerRoute(name: "duck_route",
                                     areaName: "Duck",
                                     pattern: "Manage/{controller}/{action}/{id?}");
app.MapControllerRoute(name: "default",
                             pattern: "Manage/{controller=Home}/{action=Index}/{id?}");
#endregion

app.Run();
#endif