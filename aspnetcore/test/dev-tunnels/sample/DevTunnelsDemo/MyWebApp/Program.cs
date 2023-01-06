namespace MyWebApp;

// <snippet1>
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Tunnel URL: {Environment.
            GetEnvironmentVariable("VS_TUNNEL_URL")}");
        Console.WriteLine($"API project tunnel URL: {Environment.
            GetEnvironmentVariable("VS_TUNNEL_URL_MyWebApi")}");
// </snippet1>
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
