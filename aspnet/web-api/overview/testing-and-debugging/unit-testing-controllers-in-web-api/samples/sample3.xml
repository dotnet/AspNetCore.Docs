[TestMethod]
public void PostSetsLocationHeader()
{
    // Arrange
    ProductsController controller = new ProductsController(repository);

    controller.Request = new HttpRequestMessage { 
        RequestUri = new Uri("http://localhost/api/products") 
    };
    controller.Configuration = new HttpConfiguration();
    controller.Configuration.Routes.MapHttpRoute(
        name: "DefaultApi", 
        routeTemplate: "api/{controller}/{id}",
        defaults: new { id = RouteParameter.Optional });

    controller.RequestContext.RouteData = new HttpRouteData(
        route: new HttpRoute(),
        values: new HttpRouteValueDictionary { { "controller", "products" } });

    // Act
    Product product = new Product() { Id = 42, Name = "Product1" };
    var response = controller.Post(product);

    // Assert
    Assert.AreEqual("http://localhost/api/products/42", response.Headers.Location.AbsoluteUri);
}