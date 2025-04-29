using System.Net;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesProject.Data;
using RazorPagesProject.Services;
using RazorPagesProject.Tests.Helpers;

namespace RazorPagesProject.Tests.IntegrationTests;

// <snippet1>
[TestClass]
public class IndexPageTests {
    private static HttpClient _client;
    private static CustomWebApplicationFactory<Program>
        _factory;

    [ClassInitialize]
    public static void AssemblyInitialize(TestContext _) {
        _factory = new CustomWebApplicationFactory<Program>();
        _client = _factory.CreateClient(new WebApplicationFactoryClientOptions {
            AllowAutoRedirect = false
        });
    }

    [ClassCleanup(ClassCleanupBehavior.EndOfClass)]
    public static void AssemblyCleanup(TestContext _) {
        _factory.Dispose();
    }
    // </snippet1>

    // <snippet2>
    [TestMethod]
    public async Task Post_DeleteAllMessagesHandler_ReturnsRedirectToRoot() {
        // Arrange
        var defaultPage = await _client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

        //Act
        var response = await _client.SendAsync(
            (IHtmlFormElement)content.QuerySelector("form[id='messages']"),
            (IHtmlButtonElement)content.QuerySelector("button[id='deleteAllBtn']"));

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, defaultPage.StatusCode);
        Assert.AreEqual(HttpStatusCode.Redirect, response.StatusCode);
        Assert.AreEqual("/", response.Headers.Location.OriginalString);
    }
    // </snippet2>

    // <snippet3>
    [TestMethod]
    public async Task Post_DeleteMessageHandler_ReturnsRedirectToRoot() {
        // Arrange
        using (var scope = _factory.Services.CreateScope()) {
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
        Assert.AreEqual(HttpStatusCode.OK, defaultPage.StatusCode);
        Assert.AreEqual(HttpStatusCode.Redirect, response.StatusCode);
        Assert.AreEqual("/", response.Headers.Location.OriginalString);
    }
    // </snippet3>

    [TestMethod]
    public async Task Post_AddMessageHandler_ReturnsSuccess_WhenMissingMessageText() {
        // Arrange
        var defaultPage = await _client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
        var messageText = string.Empty;

        // Act
        var response = await _client.SendAsync(
            (IHtmlFormElement)content.QuerySelector("form[id='addMessage']"),
            (IHtmlButtonElement)content.QuerySelector("button[id='addMessageBtn']"),
            new Dictionary<string, string> {
                ["Message.Text"] = messageText
            });

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, defaultPage.StatusCode);
        // A ModelState failure returns to Page (200-OK) and doesn't redirect.
        response.EnsureSuccessStatusCode();
        Assert.IsNull(response.Headers.Location?.OriginalString);
    }

    [TestMethod]
    public async Task Post_AddMessageHandler_ReturnsSuccess_WhenMessageTextTooLong() {
        // Arrange
        var defaultPage = await _client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
        var messageText = new string('X', 201);

        // Act
        var response = await _client.SendAsync(
            (IHtmlFormElement)content.QuerySelector("form[id='addMessage']"),
            (IHtmlButtonElement)content.QuerySelector("button[id='addMessageBtn']"),
            new Dictionary<string, string> {
                ["Message.Text"] = messageText
            });

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, defaultPage.StatusCode);
        // A ModelState failure returns to Page (200-OK) and doesn't redirect.
        response.EnsureSuccessStatusCode();
        Assert.IsNull(response.Headers.Location?.OriginalString);
    }

    [TestMethod]
    public async Task Post_AnalyzeMessagesHandler_ReturnsRedirectToRoot() {
        // Arrange
        var defaultPage = await _client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

        //Act
        var response = await _client.SendAsync(
            (IHtmlFormElement)content.QuerySelector("form[id='analyze']"),
            (IHtmlButtonElement)content.QuerySelector("button[id='analyzeBtn']"));

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, defaultPage.StatusCode);
        Assert.AreEqual(HttpStatusCode.Redirect, response.StatusCode);
        Assert.AreEqual("/", response.Headers.Location.OriginalString);
    }

    // <snippet4>
    // Quote ©1975 BBC: The Doctor (Tom Baker); Pyramids of Mars
    // https://www.bbc.co.uk/programmes/p00pys55
    public class TestQuoteService : IQuoteService {
        public Task<string> GenerateQuote() {
            return Task.FromResult(
                "Something's interfering with time, Mr. Scarman, " +
                "and time is my business.");
        }
    }
    // </snippet4>

    // <snippet5>
    [TestMethod]
    public async Task Get_QuoteService_ProvidesQuoteInPage() {
        // Arrange
        var client = _factory.WithWebHostBuilder(builder => {
            builder.ConfigureTestServices(services => {
                services.AddScoped<IQuoteService, TestQuoteService>();
            });
        })
            .CreateClient();

        //Act
        var defaultPage = await client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
        var quoteElement = content.QuerySelector("#quote");

        // Assert
        Assert.AreEqual("Something's interfering with time, Mr. Scarman, " +
            "and time is my business.", quoteElement.Attributes["value"].Value);
    }
    // </snippet5>
}
