using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.Threading;
using System.Linq;
using static ChangeTokenSample.Utilities.Utilities;

namespace ChangeTokenSample
{
    public class Startup
    {
        #region snippet1
        private ConfigurationReloadToken _configChangeToken = new ConfigurationReloadToken();
        private byte[] _appsettingsHash = new byte[20];
        private byte[] _appsettingsEnvHash = new byte[20];
        #endregion

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IConfiguration config, IHostingEnvironment env)
        {
            #region snippet2
            ChangeToken.OnChange(
                () => config.GetReloadToken(),
                () => 
                {
                    byte[] appsettingsHash = ComputeHash("appSettings.json");
                    byte[] appsettingsEnvHash = 
                        ComputeHash($"appSettings.{env.EnvironmentName}.json");

                    if (!_appsettingsHash.SequenceEqual(appsettingsHash) || 
                        !_appsettingsEnvHash.SequenceEqual(appsettingsEnvHash))
                    {
                        _appsettingsHash = appsettingsHash;
                        _appsettingsEnvHash = appsettingsEnvHash;

                        WriteConsole("Configuration changed");
                    }

                    var previousConfigToken = Interlocked.Exchange(
                        ref _configChangeToken, new ConfigurationReloadToken());
                    previousConfigToken.OnReload();
                });
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
