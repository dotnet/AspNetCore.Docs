using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SystemWebAdapters;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Web;
using System.Web.Hosting;

namespace TestProject1
{
    /// <summary>
    /// This is an xUnit concept that allows us to ensure all tests in classes marked with this collection are run sequentially
    /// </summary>
    [CollectionDefinition(nameof(SystemWebAdatpersHostedTests), DisableParallelization = true)]
    public class SystemWebAdatpersHostedTests
    {
    }

    [Collection(nameof(SystemWebAdatpersHostedTests))]
    public class RuntimeTests
    {
        /// <summary>
        /// This starts up a host in the background that allows us to initialize <see cref="HttpRuntime"/> and <see cref="HostingEnvironment"/>
        /// with values we want for testing with the <paramref name="configure"/> option.
        /// </summary>
        /// <param name="configure">Configuration for the hosting and runtime options.</param>
        public static async Task<IDisposable> EnableRuntimeAsync(Action<SystemWebAdaptersOptions>? configure = null, CancellationToken token = default)
            => await new HostBuilder()
               .ConfigureWebHost(webBuilder =>
               {
                   webBuilder
                       .UseTestServer()
                       .ConfigureServices(services =>
                       {
                           services.AddSystemWebAdapters();

                           if (configure is not null)
                           {
                               services.AddOptions<SystemWebAdaptersOptions>()
                                .Configure(configure);
                           }
                       })
                       .Configure(app =>
                       {
                           // No need to configure pipeline for tests
                       });
               })
               .StartAsync(token);

        [Fact]
        public async Task RuntimeEnabled()
        {
            using (await EnableRuntimeAsync(options => options.AppDomainAppPath = "path"))
            {
                Assert.True(HostingEnvironment.IsHosted);
                Assert.Equal("path", HttpRuntime.AppDomainAppPath);
            }

            Assert.False(HostingEnvironment.IsHosted);
        }
    }
}