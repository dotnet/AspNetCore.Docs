[TestMethod]
public void GetReturnsProduct()
{
    // Arrange
    var controller = new ProductsController(repository);
    controller.Request = new HttpRequestMessage();
    controller.Configuration = new HttpConfiguration();

    // Act
    var response = controller.Get(10);

    // Assert
    Product product;
    Assert.IsTrue(response.TryGetContentValue<Product>(out product));
    Assert.AreEqual(10, product.Id);
}