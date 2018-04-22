using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using RazorPagesProject.Data;

namespace RazorPagesProject.Tests.IntegrationTests
{
    #region snippet1
    public class CustomWebApplicationFactory<TStartup> 
        : WebApplicationFactory<RazorPagesProject.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (AppDbContext) using an in-memory 
                // database for testing.
                services.AddDbContext<AppDbContext>(options => 
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTests");
                        options.UseInternalServiceProvider(serviceProvider);
                    });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (AppDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AppDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<IndexPageTests>>();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                        Utilities.InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the " +
                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
    #endregion

    public class IndexPageTests2 : IClassFixture<CustomWebApplicationFactory<RazorPagesProject.Startup>>
    {
        private readonly HttpClient _client;

        #region snippet2
        public IndexPageTests2(
            CustomWebApplicationFactory<RazorPagesProject.Startup> webAppFactory)
        {
            // Create an HttpClient to submit requests against the test host.
            _client = webAppFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task Request_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
        }
        #endregion

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
        public async Task Post_AddMessageHandler_ReturnsSuccess_WhenMissingMessageText()
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
            response.EnsureSuccessStatusCode();
            Assert.Null(response.Headers.Location?.OriginalString);
        }

        [Fact]
        public async Task Post_AddMessageHandler_ReturnsSuccess_WhenMessageTextTooLong()
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
            response.EnsureSuccessStatusCode();
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
