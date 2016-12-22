[TestMethod]
public void GetReturnsProductWithSameId()
{
    // Arrange
    var mockRepository = new Mock<IProductRepository>();
    mockRepository.Setup(x => x.GetById(42))
        .Returns(new Product { Id = 42 });

    var controller = new Products2Controller(mockRepository.Object);

    // Act
    IHttpActionResult actionResult = controller.Get(42);
    var contentResult = actionResult as OkNegotiatedContentResult<Product>;

    // Assert
    Assert.IsNotNull(contentResult);
    Assert.IsNotNull(contentResult.Content);
    Assert.AreEqual(42, contentResult.Content.Id);
}