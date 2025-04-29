namespace RazorPagesProject.Tests.IntegrationTests;

// <snippet1>
public class BasicTests {
    private CustomWebApplicationFactory<Program>
        _factory;

    [SetUp]
    public void SetUp() {
        _factory = new CustomWebApplicationFactory<Program>();
    }

    [TearDown]
    public void TearDown() {
        _factory.Dispose();
    }

    [DatapointSource]
    public string[] values = ["/", "/Index", "/About", "/Privacy", "/Contact"];

    [Theory]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url) {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.That(response.Content.Headers.ContentType.ToString(), Is.EqualTo("text/html; charset=utf-8"));
    }
}
// </snippet1>
