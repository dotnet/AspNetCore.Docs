using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Principal;
using System.Text;

namespace WebApplication9
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region snippet_Impersonate
            app.Run(async (context) =>
            {
                try
                {
                    var user = (WindowsIdentity)context.User.Identity;

                    await context.Response
                                 .WriteAsync($"User: {user.Name}\tState: {user.ImpersonationLevel}\n");

                    WindowsIdentity.RunImpersonated(user.AccessToken, () =>
                    {
                        var impersonatedUser = WindowsIdentity.GetCurrent();
                        var message =
                            $"User: {impersonatedUser.Name}\tState: {impersonatedUser.ImpersonationLevel}";

                        var bytes = Encoding.UTF8.GetBytes(message);
                        context.Response.Body.Write(bytes, 0, bytes.Length);
                    });
                }
                catch (Exception e)
                {
                    await context.Response.WriteAsync(e.ToString());
                }
            });
            #endregion
        }
    }
}
