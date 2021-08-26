using Microsoft.AspNetCore.Localization;
using RP;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// This is for Step I
/// </summary>
//builder.Services.AddRequestLocalization(options =>
//{
//    options.AddSupportedCultures(new[] { "fr-FR", "it-IT", "es-ES" });
//    options.AddSupportedUICultures(new[] { "fr-FR", "it-IT", "es-ES" });
//    options.SetDefaultCulture("de-DE");
//    options.RequestCultureProviders.Clear();
//    options.RequestCultureProviders.Add(new CookieRequestCultureProvider { CookieName = ".Contoso.Culture" });
//});

/// <summary>
/// This is for Step II where, for simplicity, we remove languages to leave only two
/// </summary>
builder.Services.AddRequestLocalization(options =>
{
    options.AddSupportedCultures(new[] { "fr-FR" });
    options.AddSupportedUICultures(new[] { "fr-FR" });
    options.SetDefaultCulture("de-DE");
    options.RequestCultureProviders.Clear();
    options.RequestCultureProviders.Add(new CookieRequestCultureProvider { CookieName = ".Contoso.Culture" });
});

builder.Services.AddLocalization(options => options.ResourcesPath = "MyResources");

builder.Services.AddRazorPages()
        .AddViewLocalization()
        .AddDataAnnotationsLocalization(options =>
        {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResources));
        });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseRequestLocalization();

app.UseAuthorization();

app.MapRazorPages();

app.Run();