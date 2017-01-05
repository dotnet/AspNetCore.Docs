using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace PrimeWeb.IntegrationTests
{
    #region snippet_WebDefault
    public class PrimeWebDefaultRequestShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public PrimeWebDefaultRequestShould()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Act
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Hello World!",
                responseString);
        }
    }
    #endregion
}
