# Adding a view to an ASP.NET Core MVC app

By [Rick Anderson](https://twitter.com/RickAndMSFT)

In this section you modify the `HelloWorldController` class to use Razor view template files to cleanly encapsulate the process of generating HTML responses to a client.

You create a view template file using Razor. Razor-based view templates have a *.cshtml* file extension. They provide an elegant way to create HTML output using C#.

Currently the `Index` method returns a string with a message that is hard-coded in the controller class. In the `HelloWorldController` class, replace the `Index` method with the following code:

[!code-csharp[Main](../../tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_4)]

The preceding code returns a `View` object. It uses a view template to generate an HTML response to the browser. Controller methods (also known as action methods) such as the `Index` method above, generally return an [IActionResult](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.iactionresult) (or a class derived from `ActionResult`), not primitive types like string.
