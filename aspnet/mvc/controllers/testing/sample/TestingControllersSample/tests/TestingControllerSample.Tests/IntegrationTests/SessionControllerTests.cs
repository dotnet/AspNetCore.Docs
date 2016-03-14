using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using TestingControllersSample;
using Xunit;

namespace TestingControllerSample.Tests.IntegrationTests
{
    public class SessionControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public SessionControllerTests()
        {
            _server = new TestServer(TestServer.CreateBuilder()
                .UseEnvironment("Development")
                // needed for views to be accessed properly
                .UseServices(services =>
                {
                    var env = new TestApplicationEnvironment();
                    env.ApplicationBasePath =
                        Path.GetFullPath(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "..",
                            "..", "src", "TestingControllersSample"));
                    env.ApplicationName = "TestingControllersSample";
                    services.AddInstance<IApplicationEnvironment>(env);
                })
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task IndexReturnsCorrectSessionPage()
        {
            var response = await _client.GetAsync("/Session/Index/1");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var testSession = Startup.GetTestSession();
            Assert.True(responseString.Contains(testSession.Name));

            // ideas are loaded client-side
        }
    }
}