[TestMethod]
public void PostMethodSetsLocationHeader()
{
    // Arrange
    var mockRepository = new Mock<IProductRepository>();
    var controller = new Products2Controller(mockRepository.Object);

    // Act
    IHttpActionResult actionResult = controller.Post(new Product { Id = 10, Name = "Product1" });
    var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Product>;

    // Assert
    Assert.IsNotNull(createdResult);
    Assert.AreEqual("DefaultApi", createdResult.RouteName);
    Assert.AreEqual(10, createdResult.RouteValues["id"]);
}