using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using RazorPagesProject.Data;

namespace RazorPagesProject.Tests.IntegrationTests
{
    public class IndexPageTests : IClassFixture<WebApplicationFactory<RazorPagesProject.Startup>>
    {
        private readonly HttpClient _client;

        public IndexPageTests(
            WebApplicationFactory<RazorPagesProject.Startup> webAppFactory)
        {
            var testWebAppFactory = webAppFactory.WithWebHostBuilder(builder =>
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
            });

            // Create an HttpClient to submit requests against the test host.
            _client = testWebAppFactory.CreateDefaultClient();
        }

        #region snippet1
        [Fact]
        public async Task Request_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
        }
        #endregion
    }
}
