---
title: "Unit Testing Controllers in ASP.NET Web API 2 | Microsoft Docs"
author: MikeWasson
description: "This topic describes some specific techniques for unit testing controllers in Web API 2. Before reading this topic, you might want to read the tutorial Unit..."
ms.author: riande
manager: wpickett
ms.date: 06/11/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-api\overview\testing-and-debugging\unit-testing-controllers-in-web-api.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/58012) | [View dev content](http://docs.aspdev.net/tutorials/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api.html) | [View prod content](http://www.asp.net/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api) | Picker: 58013

Unit Testing Controllers in ASP.NET Web API 2
====================
by [Mike Wasson](https://github.com/MikeWasson)

> This topic describes some specific techniques for unit testing controllers in Web API 2. Before reading this topic, you might want to read the tutorial [Unit Testing ASP.NET Web API 2](unit-testing-with-aspnet-web-api.md), which shows how to add a unit-test project to your solution.
> 
> ## Software versions used in the tutorial
> 
> 
> - Web API 2
> - Moq 4.2


A common pattern in unit tests is &quot;arrange-act-assert&quot;:

- Arrange: Set up any prerequisites for the test to run.
- Act: Perform the test.
- Assert: Verify that the test succeeded.

In the arrange step, you will often use mock or stub objects. That minimizes the number of dependencies, so the test is focused on testing one thing.

Here are some things that you should unit test in your Web API controllers:

- The action returns the correct type of response.
- Invalid parameters return the correct error response.
- The action calls the correct method on the repository or service layer.
- If the response includes a domain model, verify the model type.

These are some of the general things to test, but the specifics depend on your controller implementation. In particular, it makes a big difference whether your controller actions return **HttpResponseMessage** or **IHttpActionResult**. For more information about these result types, see [Action Results in Web Api 2](../getting-started-with-aspnet-web-api/action-results.md).

## Testing Actions that Return HttpResponseMessage

Here is an example of a controller whose actions return **HttpResponseMessage**.

    public class ProductsController : ApiController
    {
        IProductRepository _repository;
    
        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }
    
        public HttpResponseMessage Get(int id)
        {
            Product product = _repository.GetById(id);
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(product);
        }
    
        public HttpResponseMessage Post(Product product)
        {
            _repository.Add(product);
    
            var response = Request.CreateResponse(HttpStatusCode.Created, product);
            string uri = Url.Link("DefaultApi", new { id = product.Id });
            response.Headers.Location = new Uri(uri);
    
            return response;
        }
    }

Notice the controller uses dependency injection to inject an `IProductRepository`. That makes the controller more testable, because you can inject a mock repository. The following unit test verifies that the `Get` method writes a `Product` to the response body. Assume that `repository` is a mock `IProductRepository`.

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

It's important to set **Request** and **Configuration** on the controller. Otherwise, the test will fail with an **ArgumentNullException** or **InvalidOperationException**.

## Testing Link Generation

The `Post` method calls **UrlHelper.Link** to create links in the response. This requires a little more setup in the unit test:

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

The **UrlHelper** class needs the request URL and route data, so the test has to set values for these. Another option is mock or stub **UrlHelper**. With this approach, you replace the default value of [ApiController.Url](https://msdn.microsoft.com/en-us/library/system.web.http.apicontroller.url.aspx) with a mock or stub version that returns a fixed value.

Let's rewrite the test using the [Moq](https://github.com/Moq) framework.

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

In this version, you don't need to set up any route data, because the mock **UrlHelper** returns a constant string.

> [!NOTE] I used Moq, but the same idea applies to any mocking framework.


## Testing Actions that Return IHttpActionResult

In Web API 2, a controller action can return **IHttpActionResult**, which is analogous to **ActionResult** in ASP.NET MVC. The **IHttpActionResult** interface defines a command pattern for creating HTTP responses. Instead of creating the response directly, the controller returns an **IHttpActionResult**. Later, the pipeline invokes the **IHttpActionResult** to create the response. This approach makes it easier to write unit tests, because you can skip a lot of the setup that is needed for **HttpResponseMessage**.

Here is an example controller whose actions return **IHttpActionResult**.

    public class Products2Controller : ApiController
    {
        IProductRepository _repository;
    
        public Products2Controller(IProductRepository repository)
        {
            _repository = repository;
        }
    
        public IHttpActionResult Get(int id)
        {
            Product product = _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    
        public IHttpActionResult Post(Product product)
        {
            _repository.Add(product);
            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }
    
        public IHttpActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    
        public IHttpActionResult Put(Product product)
        {
            // Do some work (not shown).
            return Content(HttpStatusCode.Accepted, product);
        }    
    }

This example shows some common patterns using **IHttpActionResult**. Let's see how to unit test them.

### Action returns 200 (OK) with a response body

The `Get` method calls `Ok(product)` if the product is found. In the unit test, make sure the return type is **OkNegotiatedContentResult** and the returned product has the right ID.

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

Notice that the unit test doesn't execute the action result. You can assume the action result creates the HTTP response correctly. (That's why the Web API framework has its own unit tests!)

### Action returns 404 (Not Found)

The `Get` method calls `NotFound()` if the product is not found. For this case, the unit test just checks if the return type is **NotFoundResult**.

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

### Action returns 200 (OK) with no response body

The `Delete` method calls `Ok()` to return an empty HTTP 200 response. Like the previous example, the unit test checks the return type, in this case **OkResult**.

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

### Action returns 201 (Created) with a Location header

The `Post` method calls `CreatedAtRoute` to return an HTTP 201 response with a URI in the Location header. In the unit test, verify that the action sets the correct routing values.

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

### Action returns another 2xx with a response body

The `Put` method calls `Content` to return an HTTP 202 (Accepted) response with a response body. This case is similar to returning 200 (OK), but the unit test should also check the status code.

    [TestMethod]
    public void PutReturnsContentResult()
    {
        // Arrange
        var mockRepository = new Mock<IProductRepository>();
        var controller = new Products2Controller(mockRepository.Object);
    
        // Act
        IHttpActionResult actionResult = controller.Put(new Product { Id = 10, Name = "Product" });
        var contentResult = actionResult as NegotiatedContentResult<Product>;
    
        // Assert
        Assert.IsNotNull(contentResult);
        Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
        Assert.IsNotNull(contentResult.Content);
        Assert.AreEqual(10, contentResult.Content.Id);
    }

## Additional Resources

- [Mocking Entity Framework when Unit Testing ASP.NET Web API 2](mocking-entity-framework-when-unit-testing-aspnet-web-api-2.md)
- [Writing tests for an ASP.NET Web API service](https://blogs.msdn.com/b/youssefm/archive/2013/01/28/writing-tests-for-an-asp-net-webapi-service.aspx) (blog post by Youssef Moussaoui).
- [Debugging ASP.NET Web API with Route Debugger](https://blogs.msdn.com/b/webdev/archive/2013/04/04/debugging-asp-net-web-api-with-route-debugger.aspx)