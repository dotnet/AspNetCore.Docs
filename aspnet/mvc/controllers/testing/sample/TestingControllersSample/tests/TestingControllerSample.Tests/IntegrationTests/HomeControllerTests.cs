using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using TestingControllersSample;
using Xunit;

namespace TestingControllerSample.Tests.IntegrationTests
{
    public class HomeControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public HomeControllerTests()
        {
            _server = new TestServer(TestServer.CreateBuilder()
                .UseEnvironment("Development")
                // needed for views to be accessed properly
                .UseServices(services =>
                {
                    var env = new TestApplicationEnvironment();
                    env.ApplicationBasePath =
                        Path.GetFullPath(Path.Combine(
                            PlatformServices.Default.Application.ApplicationBasePath, 
                            "..", "..", "src", "TestingControllersSample"));
                    env.ApplicationName = "TestingControllersSample";
                    services.AddInstance<IApplicationEnvironment>(env);
                })
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnsInitialListOfBrainstormSessions()
        {
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var testSession = Startup.GetTestSession();
            Assert.True(responseString.Contains(testSession.Name));
        }

        [Fact]
        public async Task PostAddsNewBrainstormSession()
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "/");
            var data = new Dictionary<string, string>();
            string testSessionName = Guid.NewGuid().ToString();
            data.Add("SessionName", testSessionName);

            message.Content = new FormUrlEncodedContent(data);

            var response = await _client.SendAsync(message);

            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.ToString());
        }
    }
}