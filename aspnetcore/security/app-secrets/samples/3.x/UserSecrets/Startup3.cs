#if never
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserSecrets.Models;

namespace UserSecrets
{
    public class Startup
    {
        private string _moviesApiKey = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
#region snippet_BindToObjectGraph
            var moviesConfig = 
                Configuration.GetSection("Movies").Get<MovieSettings>();
            _moviesApiKey = moviesConfig.ServiceApiKey;
#endregion
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var result = string.IsNullOrEmpty(_moviesApiKey) ? "Null" : "Not Null";
                await context.Response.WriteAsync($"Secret is {result}");
            });
        }
    }
}
#endif
