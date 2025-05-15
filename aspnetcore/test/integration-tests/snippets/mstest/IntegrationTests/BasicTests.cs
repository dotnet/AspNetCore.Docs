namespace RazorPagesProject.Tests.IntegrationTests;

// <snippet1>
[TestClass]
public class BasicTests
{
    private static CustomWebApplicationFactory<Program> _factory;

    [ClassInitialize]
    public static void AssemblyInitialize(TestContext _)
    {
        _factory = new CustomWebApplicationFactory<Program>();
    }

    [ClassCleanup(ClassCleanupBehavior.EndOfClass)]
    public static void AssemblyCleanup(TestContext _)
    {
        _factory.Dispose();
    }

    [TestMethod]
    [DataRow("/")]
    [DataRow("/Index")]
    [DataRow("/About")]
    [DataRow("/Privacy")]
    [DataRow("/Contact")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.AreEqual("text/html; charset=utf-8",
            response.Content.Headers.ContentType.ToString());
    }
}
// </snippet1>
