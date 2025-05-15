using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Options;
using RazorPagesProject.Services;
using RazorPagesProject.Tests.Helpers;
using Xunit;

namespace RazorPagesProject.Tests.IntegrationTests;

public class AuthTests :
    IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program>
        _factory;

    public AuthTests(
        CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

// <snippet1>
    [Fact]
    public async Task Get_GithubProfilePageCanGetAGithubUser()
    {
        // Arrange
        void ConfigureTestServices(IServiceCollection services) =>
            services.AddSingleton<IGithubClient>(new TestGithubClient());
        var client = _factory
            .WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(ConfigureTestServices))
            .CreateClient();

        // Act
        var profile = await client.GetAsync("/GithubProfile");
        Assert.Equal(HttpStatusCode.OK, profile.StatusCode);
        var profileHtml = await HtmlHelpers.GetDocumentAsync(profile);

        var profileWithUserName = await client.SendAsync(
            (IHtmlFormElement)profileHtml.QuerySelector("#user-profile"),
            new Dictionary<string, string> { ["Input_UserName"] = "user" });

        // Assert
        Assert.Equal(HttpStatusCode.OK, profileWithUserName.StatusCode);
        var profileWithUserHtml =
            await HtmlHelpers.GetDocumentAsync(profileWithUserName);
        var userLogin = profileWithUserHtml.QuerySelector("#user-login");
        Assert.Equal("user", userLogin.TextContent);
    }

    public class TestGithubClient : IGithubClient
    {
        public Task<GithubUser> GetUserAsync(string userName)
        {
            if (userName == "user")
            {
                return Task.FromResult(
                    new GithubUser
                    {
                        Login = "user",
                        Company = "Contoso Blockchain",
                        Name = "John Doe"
                    });
            }
            else
            {
                return Task.FromResult<GithubUser>(null);
            }
        }
    }
// </snippet1>

// <snippet2>
    [Fact]
    public async Task Get_SecurePageRedirectsAnUnauthenticatedUser()
    {
        // Arrange
        var client = _factory.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

        // Act
        var response = await client.GetAsync("/SecurePage");

        // Assert
        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        Assert.StartsWith("http://localhost/Identity/Account/Login",
            response.Headers.Location.OriginalString);
    }
// </snippet2>

// <snippet3>
    [Fact]
    public async Task Get_SecurePageIsReturnedForAnAuthenticatedUser()
    {
        // Arrange
        var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication(defaultScheme: "TestScheme")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                            "TestScheme", options => { });
                });
            })
            .CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
            });

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(scheme: "TestScheme");

        //Act
        var response = await client.GetAsync("/SecurePage");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
// </snippet3>
}

// <snippet4>
public class TestAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public TestAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger, UrlEncoder encoder)
        : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new[] { new Claim(ClaimTypes.Name, "Test user") };
        var identity = new ClaimsIdentity(claims, "Test");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "TestScheme");

        var result = AuthenticateResult.Success(ticket);

        return Task.FromResult(result);
    }
}
// </snippet4>
