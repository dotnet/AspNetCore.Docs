using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestingControllersSample.Tests.IntegrationTests
{
    public class HomeControllerTests : IClassFixture<TestFixture<TestingControllersSample.Startup>>
    {
        private readonly HttpClient _client;

        public HomeControllerTests(TestFixture<TestingControllersSample.Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task ReturnsInitialListOfBrainstormSessions()
        {
            // Arrange - get a session known to exist
            var testSession = Startup.GetTestSession();

            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains(testSession.Name, responseString);
        }

        [Fact]
        public async Task PostAddsNewBrainstormSession()
        {
            // Arrange
            string testSessionName = Guid.NewGuid().ToString();
            var data = new Dictionary<string, string>();
            data.Add("SessionName", testSessionName);
            var content = new FormUrlEncodedContent(data);

            // Act
            var response = await _client.PostAsync("/", content);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.ToString());
        }
    }
}
