::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](../../tutorials/first-web-api/samples/2.0/TodoApi/Controllers/TodoController2.cs?name=snippet_todo1)]

The preceding code defines an API controller class without methods. In the next sections, methods are added to implement the API.
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](../../tutorials/first-web-api/samples/2.1/TodoApi/Controllers/TodoController2.cs?name=snippet_todo1)]

The preceding code:

* Defines an API controller class without methods.
* Creates a new Todo item when `TodoItems` is empty. You won't be able to delete all the Todo items because the constructor creates a new one if `TodoItems` is empty.

In the next sections, methods are added to implement the API. The class is annotated with an `[ApiController]` attribute to enable some convenient features. For information on features enabled by the attribute, see [Annotate class with ApiControllerAttribute](xref:web-api/index#annotate-class-with-apicontrollerattribute).
::: moniker-end

The controller's constructor uses [Dependency Injection](xref:fundamentals/dependency-injection) to inject the database context (`TodoContext`) into the controller. The database context is used in each of the [CRUD](https://wikipedia.org/wiki/Create,_read,_update_and_delete) methods in the controller. The constructor adds an item to the in-memory database if one doesn't exist.

## Get to-do items

To get to-do items, add the following methods to the `TodoController` class:

::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](../../tutorials/first-web-api/samples/2.0/TodoApi/Controllers/TodoController.cs?name=snippet_GetAll)]
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](../../tutorials/first-web-api/samples/2.1/TodoApi/Controllers/TodoController.cs?name=snippet_GetAll)]
::: moniker-end

These methods implement the two GET methods:

* `GET /api/todo`
* `GET /api/todo/{id}`

Here's a sample HTTP response for the `GetAll` method:

```json
[
  {
    "id": 1,
    "name": "Item1",
    "isComplete": false
  }
]
```

Later in the tutorial, I'll show how the HTTP response can be viewed with [Postman](https://www.getpostman.com/) or [curl](https://curl.haxx.se/docs/manpage.html).

### Routing and URL paths

The `[HttpGet]` attribute denotes a method that responds to an HTTP GET request. The URL path for each method is constructed as follows:

* Take the template string in the controller's `Route` attribute:

::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](../../tutorials/first-web-api/samples/2.0/TodoApi/Controllers/TodoController.cs?name=TodoController&highlight=3)]
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](../../tutorials/first-web-api/samples/2.1/TodoApi/Controllers/TodoController.cs?name=TodoController&highlight=3)]
::: moniker-end

* Replace `[controller]` with the name of the controller, which is the controller class name minus the "Controller" suffix. For this sample, the controller class name is **Todo**Controller and the root name is "todo". ASP.NET Core [routing](xref:mvc/controllers/routing) is case insensitive.
* If the `[HttpGet]` attribute has a route template (such as `[HttpGet("/products")]`, append that to the path. This sample doesn't use a template. For more information, see [Attribute routing with Http[Verb] attributes](xref:mvc/controllers/routing#attribute-routing-with-httpverb-attributes).

In the following `GetById` method, `"{id}"` is a placeholder variable for the unique identifier of the to-do item. When `GetById` is invoked, it assigns the value of `"{id}"` in the URL to the method's `id` parameter.

::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](../../tutorials/first-web-api/samples/2.0/TodoApi/Controllers/TodoController.cs?name=snippet_GetByID&highlight=1-2)]
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](../../tutorials/first-web-api/samples/2.1/TodoApi/Controllers/TodoController.cs?name=snippet_GetByID&highlight=1-2)]
::: moniker-end

`Name = "GetTodo"` creates a named route. Named routes:

* Enable the app to create an HTTP link using the route name.
* Are explained later in the tutorial.

### Return values

The `GetAll` method returns a collection of `TodoItem` objects. MVC automatically serializes the object to [JSON](https://www.json.org/) and writes the JSON into the body of the response message. The response code for this method is 200, assuming there are no unhandled exceptions. Unhandled exceptions are translated into 5xx errors.

::: moniker range="<= aspnetcore-2.0"
In contrast, the `GetById` method returns the more general [IActionResult type](xref:web-api/action-return-types#iactionresult-type), which represents a wide range of return types. `GetById` has two different return types:

* If no item matches the requested ID, the method returns a 404 error. Returning [NotFound](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.notfound) returns an HTTP 404 response.
* Otherwise, the method returns 200 with a JSON response body. Returning [Ok](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.ok) results in an HTTP 200 response.
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
In contrast, the `GetById` method returns the [ActionResult\<T> type](xref:web-api/action-return-types#actionresultt-type), which represents a wide range of return types. `GetById` has two different return types:

* If no item matches the requested ID, the method returns a 404 error. Returning [NotFound](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.notfound) returns an HTTP 404 response.
* Otherwise, the method returns 200 with a JSON response body. Returning `item` results in an HTTP 200 response.
::: moniker-end
