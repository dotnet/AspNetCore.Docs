using Microsoft.AspNetCore.Antiforgery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// <snippet_Middleware>
app.UseRouting();

app.UseAuthorization();

var antiforgery = app.Services.GetRequiredService<IAntiforgery>();

app.Use((context, next) =>
{
    var requestPath = context.Request.Path.Value;

    if (string.Equals(requestPath, "/", StringComparison.OrdinalIgnoreCase)
        || string.Equals(requestPath, "/index.html", StringComparison.OrdinalIgnoreCase))
    {
        var tokenSet = antiforgery.GetAndStoreTokens(context);
        // <snippet_CookiesAppend>
        context.Response.Cookies.Append("XSRF-TOKEN", tokenSet.RequestToken!,
            new CookieOptions { HttpOnly = false });
        // </snippet_CookiesAppend>
    }

    return next(context);
});
// </snippet_Middleware>

app.MapDefaultControllerRoute();

app.Run();
