using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNet.TestHost;
using TestingControllersSample;
using TestingControllersSample.ClientModels;
using TestingControllersSample.Core.Model;
using Xunit;

namespace TestingControllerSample.Tests.IntegrationTests
{
    public class ApiIdeasControllerTests
    {
        private readonly HttpClient _client;

        public ApiIdeasControllerTests()
        {
            var server = new TestServer(TestServer.CreateBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();

            // client always expects json results
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        internal class NewIdeaDto
        {
            public NewIdeaDto(string name, string description, int sessionId)
            {
                Name = name;
                Description = description;
                SessionId = sessionId;
            }

            public string Name { get; set; }
            public string Description { get; set; }
            public int SessionId { get; set; }
        }

        [Fact]
        public async Task CreatePostReturnsBadRequestForMissingNameValue()
        {
            var newIdea = new NewIdeaDto("", "Description", 1);
            var response = await _client.PostAsJsonAsync("/api/ideas/create", newIdea);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreatePostReturnsBadRequestForMissingDescriptionValue()
        {
            var newIdea = new NewIdeaDto("Name", "", 1);
            var response = await _client.PostAsJsonAsync("/api/ideas/create", newIdea);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreatePostReturnsBadRequestForSessionIdValueTooSmall()
        {
            var newIdea = new NewIdeaDto("Name", "Description", 0);
            var response = await _client.PostAsJsonAsync("/api/ideas/create", newIdea);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreatePostReturnsBadRequestForSessionIdValueTooLarge()
        {
            var newIdea = new NewIdeaDto("Name", "Description", 1000001);
            var response = await _client.PostAsJsonAsync("/api/ideas/create", newIdea);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreatePostReturnsNotFoundForInvalidSession()
        {
            var newIdea = new NewIdeaDto("Name", "Description", 123);
            var response = await _client.PostAsJsonAsync("/api/ideas/create", newIdea);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreatePostReturnsCreatedIdeaWithCorrectInputs()
        {
            var testIdeaName = Guid.NewGuid().ToString();
            var newIdea = new NewIdeaDto(testIdeaName, "Description", 1);
           
            var response = await _client.PostAsJsonAsync("/api/ideas/create", newIdea);
            response.EnsureSuccessStatusCode();

            var returnedSession = await response.Content.ReadAsJsonAsync<BrainstormSession>();
            Assert.Equal(2, returnedSession.Ideas.Count);
            Assert.True(returnedSession.Ideas.Any(i => i.Name == testIdeaName));
        }

        [Fact]
        public async Task ForSessionReturnsNotFoundForBadSessionId()
        {
            var response = await _client.GetAsync("/api/ideas/forsession/500");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task ForSessionReturnsIdeasForValidSessionId()
        {
            var response = await _client.GetAsync("/api/ideas/forsession/1");
            response.EnsureSuccessStatusCode();

            var ideaList = await response.Content.ReadAsJsonAsync<List<IdeaDTO>>();
            var firstIdea = ideaList.First();
            var testSession = Startup.GetTestSession();
            Assert.Equal(testSession.Ideas.First().Name, firstIdea.name);
        }

    }
}