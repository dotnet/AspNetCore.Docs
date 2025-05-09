using System.Net;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using RazorPagesProject.Data;
using RazorPagesProject.Services;
using RazorPagesProject.Tests.Helpers;
using Xunit;

namespace RazorPagesProject.Tests.IntegrationTests;

// <snippet1>
public class IndexPageTests :
    IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program>
        _factory;

    public IndexPageTests(
        CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }
// </snippet1>

// <snippet2>
    [Fact]
    public async Task Post_DeleteAllMessagesHandler_ReturnsRedirectToRoot()
    {
        // Arrange
        var defaultPage = await _client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

        //Act
        var response = await _client.SendAsync(
            (IHtmlFormElement)content.QuerySelector("form[id='messages']"),
            (IHtmlButtonElement)content.QuerySelector("button[id='deleteAllBtn']"));

        // Assert
        Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        Assert.Equal("/", response.Headers.Location.OriginalString);
    }
// </snippet2>

// <snippet3>
    [Fact]
    public async Task Post_DeleteMessageHandler_ReturnsRedirectToRoot()
    {
        // Arrange
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();

            Utilities.ReinitializeDbForTests(db);
        }

        var defaultPage = await _client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

        //Act
        var response = await _client.SendAsync(
            (IHtmlFormElement)content.QuerySelector("form[id='messages']"),
            (IHtmlButtonElement)content.QuerySelector("form[id='messages']")
                .QuerySelector("div[class='panel-body']")
                .QuerySelector("button"));

        // Assert
        Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        Assert.Equal("/", response.Headers.Location.OriginalString);
    }
// </snippet3>

    [Fact]
    public async Task Post_AddMessageHandler_ReturnsSuccess_WhenMissingMessageText()
    {
        // Arrange
        var defaultPage = await _client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
        var messageText = string.Empty;

        // Act
        var response = await _client.SendAsync(
            (IHtmlFormElement)content.QuerySelector("form[id='addMessage']"),
            (IHtmlButtonElement)content.QuerySelector("button[id='addMessageBtn']"),
            new Dictionary<string, string>
            {
                ["Message.Text"] = messageText
            });

        // Assert
        Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
        // A ModelState failure returns to Page (200-OK) and doesn't redirect.
        response.EnsureSuccessStatusCode();
        Assert.Null(response.Headers.Location?.OriginalString);
    }

    [Fact]
    public async Task Post_AddMessageHandler_ReturnsSuccess_WhenMessageTextTooLong()
    {
        // Arrange
        var defaultPage = await _client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
        var messageText = new string('X', 201);

        // Act
        var response = await _client.SendAsync(
            (IHtmlFormElement)content.QuerySelector("form[id='addMessage']"),
            (IHtmlButtonElement)content.QuerySelector("button[id='addMessageBtn']"),
            new Dictionary<string, string>
            {
                ["Message.Text"] = messageText
            });

        // Assert
        Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
        // A ModelState failure returns to Page (200-OK) and doesn't redirect.
        response.EnsureSuccessStatusCode();
        Assert.Null(response.Headers.Location?.OriginalString);
    }

    [Fact]
    public async Task Post_AnalyzeMessagesHandler_ReturnsRedirectToRoot()
    {
        // Arrange
        var defaultPage = await _client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

        //Act
        var response = await _client.SendAsync(
            (IHtmlFormElement)content.QuerySelector("form[id='analyze']"),
            (IHtmlButtonElement)content.QuerySelector("button[id='analyzeBtn']"));

        // Assert
        Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        Assert.Equal("/", response.Headers.Location.OriginalString);
    }

// <snippet4>
    // Quote ©1975 BBC: The Doctor (Tom Baker); Pyramids of Mars
    // https://www.bbc.co.uk/programmes/p00pys55
    public class TestQuoteService : IQuoteService
    {
        public Task<string> GenerateQuote()
        {
            return Task.FromResult(
                "Something's interfering with time, Mr. Scarman, " +
                "and time is my business.");
        }
    }
// </snippet4>

// <snippet5>
    [Fact]
    public async Task Get_QuoteService_ProvidesQuoteInPage()
    {
        // Arrange
        var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IQuoteService, TestQuoteService>();
                });
            })
            .CreateClient();

        //Act
        var defaultPage = await client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
        var quoteElement = content.QuerySelector("#quote");

        // Assert
        Assert.Equal("Something's interfering with time, Mr. Scarman, " +
            "and time is my business.", quoteElement.Attributes["value"].Value);
    }
// </snippet5>
}
