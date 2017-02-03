[TestMethod]
public void PostSetsLocationHeader_MockVersion()
{
    // This version uses a mock UrlHelper.

    // Arrange
    ProductsController controller = new ProductsController(repository);
    controller.Request = new HttpRequestMessage();
    controller.Configuration = new HttpConfiguration();

    string locationUrl = "http://location/";

    // Create the mock and set up the Link method, which is used to create the Location header.
    // The mock version returns a fixed string.
    var mockUrlHelper = new Mock<UrlHelper>();
    mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
    controller.Url = mockUrlHelper.Object;

    // Act
    Product product = new Product() { Id = 42 };
    var response = controller.Post(product);

    // Assert
    Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);
}