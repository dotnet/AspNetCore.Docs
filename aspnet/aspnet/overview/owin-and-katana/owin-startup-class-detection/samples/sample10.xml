using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("TestingConfiguration", typeof(StartupDemo.TestStartup))]

namespace StartupDemo
{
    public class TestStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                string t = DateTime.Now.Millisecond.ToString();
                return context.Response.WriteAsync(t + " Test OWIN App");
            });
        }
    }
}