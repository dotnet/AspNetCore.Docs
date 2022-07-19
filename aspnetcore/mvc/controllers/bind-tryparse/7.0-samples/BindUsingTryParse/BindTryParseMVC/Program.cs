var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

//         // GET /WeatherForecast/RangeWithCulture?culture=en-GB&range=07/12/2022-07/14/2022

var redirectDateRange = $"/WeatherForecast/RangeWithCulture?range={DateTime.Now.ToShortDateString()}" +
                        $"-{DateTime.Now.AddDays(5).ToShortDateString()}" +
                        "&culture=en-GB";

app.MapGet("/", () => Results.Redirect(redirectDateRange));

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=WeatherForecast}/{action=Index}/{id?}");

app.Run();
