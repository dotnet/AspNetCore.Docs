#if never
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UserSecrets
{
    #region snippet_Program
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, builder) =>
                {
                    // Add other providers for JSON, etc.

                    if (hostContext.HostingEnvironment.IsDevelopment())
                    {
                        builder.AddUserSecrets<Program>();
                    }
                })
                .Build();
            
            host.Run();
        }
    }
    #endregion snippet_Program
}
#endif
