using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Server.Kestrel;

namespace ServersDemo
{
    /// <summary>
    /// This demonstrates how the application can be launched in a console application. 
    /// Executing the "dnx run" command in the application folder will run this app.
    /// </summary>
    public class Program
    {
        private readonly IServiceProvider _serviceProvider;

        public Program(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<int> Main(string[] args)
        {
            //Add command line configuration source to read command line parameters.
            var builder = new ConfigurationBuilder();
            builder.AddCommandLine(args);
            var config = builder.Build();

            using (new WebHostBuilder(config)
                .UseServer("Microsoft.AspNet.Server.Kestrel")
                .Build()
                .Start())
            {
                Console.WriteLine("Started the server..");
                Console.WriteLine("Press any key to stop the server");
                Console.ReadLine();
            }
            return Task.FromResult(0);
        }
    }
}
