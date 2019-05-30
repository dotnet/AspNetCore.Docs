public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>()
                    .UseHttpSys(options =>
                    {
                        options.Authentication.Schemes = 
                            AuthenticationSchemes.NTLM | 
                            AuthenticationSchemes.Negotiate;
                        options.Authentication.AllowAnonymous = false;
                    });
            });
}
