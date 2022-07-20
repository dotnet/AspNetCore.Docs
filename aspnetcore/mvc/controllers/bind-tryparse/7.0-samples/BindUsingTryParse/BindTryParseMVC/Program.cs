using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

//         // GET /WeatherForecast/RangeWithCulture?range=20/07/2022-25/07/2022&culture=en-GB

DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat;
var now = DateTime.Now.ToString("d", dtfi);
var fiveDays = DateTime.Now.AddDays(5).ToString("d", dtfi);
var redirectDateRange = $"/WeatherForecast/RangeWithCulture?range={now}" +
                        $"-{fiveDays}" +
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
