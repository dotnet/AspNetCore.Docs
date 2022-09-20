using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MinApiTests.IntegrationTests.Helpers;

namespace MinApiTests.IntegrationTests;

public class AuthorizedEndpointsIntegrationTests : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly TestWebApplicationFactory<Program> _factory;

    public AuthorizedEndpointsIntegrationTests(TestWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    public static IEnumerable<object[]> AdminFlags => new List<object[]>
    {
        new object[] { "false", HttpStatusCode.Forbidden },
        new object[] { "true", HttpStatusCode.OK }
    };

    [Theory]
    [MemberData(nameof(AdminFlags))]
    public async Task GetAdminEndpointIsReturnedForAnAuthorizedRequest(string isAdmin, HttpStatusCode code)
    {
        // Arrange
        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddAuthentication("Test")
                    .AddScheme<TestAuthenticationSchemeOptions, TestAuthHandler>("Test",
                        options => options.IsAdmin = isAdmin);
            });
        }).CreateClient();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");

        //Act
        var response = await client.GetAsync("/admin");

        // Assert
        Assert.Equal(code, response.StatusCode);
    }
}
