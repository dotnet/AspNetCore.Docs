using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp1.Areas.Identity.Data;
using WebApp1.Models;

[assembly: HostingStartup(typeof(WebApp1.Areas.Identity.IdentityHostingStartup))]
namespace WebApp1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebApp1Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebApp1ContextConnection")));

                services.AddDefaultIdentity<WebApp1User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WebApp1Context>();
            });
        }
    }
}
