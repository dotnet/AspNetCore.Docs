[TestMethod]
public void GetReturnsNotFound()
{
    // Arrange
    var mockRepository = new Mock<IProductRepository>();
    var controller = new Products2Controller(mockRepository.Object);

    // Act
    IHttpActionResult actionResult = controller.Get(10);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
}