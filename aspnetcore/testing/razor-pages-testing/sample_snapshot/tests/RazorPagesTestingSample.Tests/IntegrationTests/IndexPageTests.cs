using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace RazorPagesTestingSample.Tests.IntegrationTests
{
    public class IndexPageTests : IClassFixture<TestFixture<RazorPagesTestingSample.Startup>>
    {
        private readonly HttpClient _client;

        public IndexPageTests(TestFixture<RazorPagesTestingSample.Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Request_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Post_DeleteAllMessagesHandler_ReturnsRedirectToRoot()
        {
            // Arrange
            var content = await Utilities.GetRequestContentAsync(_client, "/", new Dictionary<string, string>());

            //Act
            var response = await _client.PostAsync("?handler=DeleteAllMessages", content);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task Post_AddMessageHandler_ReturnsRedirectToRoot()
        {
            // Arrange
            var data = new Dictionary<string, string>()
            {
                { "Message.Text", "Test message to add." }
            };
            var content = await Utilities.GetRequestContentAsync(_client, "/", data);

            // Act
            var response = await _client.PostAsync("?handler=AddMessage", content);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task Post_AddMessageHandler_ReturnsSuccessStatusCode_WhenModelStateFailsOnMissingMessageText()
        {
            // Arrange
            var data = new Dictionary<string, string>()
            {   
                { "Message.Text", string.Empty }
            };
            var content = await Utilities.GetRequestContentAsync(_client, "/", data);

            // Act
            var response = await _client.PostAsync("?handler=AddMessage", content);

            // Assert
            // A ModelState failure returns to Page (200-OK) and doesn't redirect.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Null(response.Headers.Location?.OriginalString);
        }

        [Fact]
        public async Task Post_AddMessageHandler_ReturnsSuccessStatusCode_WhenModelStateFailsOnMessageTextTooLong()
        {
            // Arrange
            var data = new Dictionary<string, string>()
            {   
                { "Message.Text", new string('X', 201) }
            };
            var content = await Utilities.GetRequestContentAsync(_client, "/", data);

            // Act
            var response = await _client.PostAsync("?handler=AddMessage", content);

            // Assert
            // A ModelState failure returns to Page (200-OK) and doesn't redirect.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Null(response.Headers.Location?.OriginalString);
        }

        [Fact]
        public async Task Post_DeleteMessageHandler_ReturnsRedirectToRoot()
        {
            // Arrange
            var recId = 1;
            var content = await Utilities.GetRequestContentAsync(_client, "/", new Dictionary<string, string>());

            //Act
            var response = await _client.PostAsync($"?id={recId}&handler=DeleteMessage", content);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task Post_AnalyzeMessagesHandler_ReturnsRedirectToRoot()
        {
            // Arrange
            var content = await Utilities.GetRequestContentAsync(_client, "/", new Dictionary<string, string>());

            //Act
            var response = await _client.PostAsync("?handler=AnalyzeMessages", content);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/", response.Headers.Location.OriginalString);
        }
    }
}
