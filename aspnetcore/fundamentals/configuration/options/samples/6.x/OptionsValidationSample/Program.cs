#define P3   // DEFAULT MC XM P1  P2 P3
#if NEVER
#elif DEFAULT
#region snippet
using OptionsValidationSample.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddOptions<MyConfigOptions>()
            .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig))
            .ValidateDataAnnotations();

var app = builder.Build();
#endregion

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#elif MC
#region snippet_mc
using OptionsValidationSample.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddOptions<MyConfigOptions>()
            .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig))
            .ValidateDataAnnotations()
        .Validate(config =>
        {
            if (config.Key2 != 0)
            {
                return config.Key3 > config.Key2;
            }

            return true;
        }, "Key3 must be > than Key2.");   // Failure message.

var app = builder.Build();
#endregion

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#elif XM
#region snippet_xm
using Microsoft.Extensions.Options;
using OptionsValidationSample.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<MyConfigOptions>(builder.Configuration.GetSection(
                                        MyConfigOptions.MyConfig));

builder.Services.AddSingleton<IValidateOptions
                              <MyConfigOptions>, MyConfigValidation>();

var app = builder.Build();
#endregion

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#elif P1
#region snippet_p1
using OptionsValidationSample.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddOptions<MyConfigOptions>()
                .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig));

builder.Services.PostConfigure<MyConfigOptions>(myOptions =>
{
    myOptions.Key1 = "post_configured_key1_value";
});
#endregion


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#elif P2
#region snippet_p2
using OptionsValidationSample.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddOptions<MyConfigOptions>()
                .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig));

builder.Services.PostConfigure<MyConfigOptions>("MyConfig", myOptions =>
{
    myOptions.Key1 = "post_configured_key1_value";
});
#endregion


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#elif P3
#region snippet_p3
using OptionsValidationSample.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddOptions<MyConfigOptions>()
                .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig));

builder.Services.PostConfigureAll<MyConfigOptions>(myOptions =>
{
    myOptions.Key1 = "post_configured_key1_value";
});
#endregion


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endif
