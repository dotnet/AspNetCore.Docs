using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebR2C
{
    public class Startup6
    {
        #region snippet
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JsonOptions>(o =>
            {
                o.SerializerOptions.WriteIndented = true;
            });
        }
        #endregion
    }
}
