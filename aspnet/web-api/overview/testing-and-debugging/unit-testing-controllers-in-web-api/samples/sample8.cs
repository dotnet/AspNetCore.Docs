[TestMethod]
public void DeleteReturnsOk()
{
    // Arrange
    var mockRepository = new Mock<IProductRepository>();
    var controller = new Products2Controller(mockRepository.Object);

    // Act
    IHttpActionResult actionResult = controller.Delete(10);

    // Assert
    Assert.IsInstanceOfType(actionResult, typeof(OkResult));
}