using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebPWrecover.Models;

[assembly: HostingStartup(typeof(WebPWrecover.Areas.Identity.IdentityHostingStartup))]
namespace WebPWrecover.Areas.Identity
{
    #region snippet1
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebPWrecoverContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebPWrecoverContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(config =>
                    {
                        config.SignIn.RequireConfirmedEmail = true;
                    })
                    .AddEntityFrameworkStores<WebPWrecoverContext>();
            });
        }
    }
    #endregion
}