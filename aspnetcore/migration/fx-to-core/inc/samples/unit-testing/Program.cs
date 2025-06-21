using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SystemWebAdapters;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Web;
using System.Web.Hosting;

// <snippet_UnitTestingFixture>
namespace TestProject1;

/// <summary>
/// This demonstrates an xUnit feature that ensures all tests
/// in classes marked with this collection are run sequentially.
/// </summary>
[CollectionDefinition(nameof(SystemWebAdaptersHostedTests),
    DisableParallelization = true)]
public class SystemWebAdaptersHostedTests
{
}
[Collection(nameof(SystemWebAdaptersHostedTests))]
public class RuntimeTests
{
    /// <summary>
    /// This method starts up a host in the background that
    /// makes it possible to initialize <see cref="HttpRuntime"/>
    /// and <see cref="HostingEnvironment"/> with values needed 
    /// for testing with the <paramref name="configure"/> option.
    /// </summary>
    /// <param name="configure">
    /// Configuration for the hosting and runtime options.
    /// </param>
    public static async Task<IDisposable> EnableRuntimeAsync(
        Action<SystemWebAdaptersOptions>? configure = null,
        CancellationToken token = default)
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
                           services.AddOptions
                               <SystemWebAdaptersOptions>()
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
        using (await EnableRuntimeAsync(options =>
            options.AppDomainAppPath = "path"))
        {
            Assert.True(HostingEnvironment.IsHosted);
            Assert.Equal("path", HttpRuntime.AppDomainAppPath);
        }
        Assert.False(HostingEnvironment.IsHosted);
    }
}
// </snippet_UnitTestingFixture>