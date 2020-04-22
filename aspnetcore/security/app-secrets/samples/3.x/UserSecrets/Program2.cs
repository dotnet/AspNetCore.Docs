#if never
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UserSecrets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region snippet_Host
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
                #endregion
            
            host.Run();
        }
    }
}
#endif
