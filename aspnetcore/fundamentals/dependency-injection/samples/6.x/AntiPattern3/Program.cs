#region snippet
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie();
builder.Services.AddOptions<CookieAuthenticationOptions>(
                        CookieAuthenticationDefaults.AuthenticationScheme)
        .Configure<IMyService>((options, myService) =>
        {
            options.LoginPath = myService.GetLoginPath();
        });

builder.Services.AddRazorPages();

var app = builder.Build();
#endregion
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


internal interface IMyService
{
    PathString GetLoginPath();
}