---
title: Adding a controller | Microsoft Docs
author: rick-anderson 
description: How to add a controller to a simple ASP.NET Core MVC app
keywords: ASP.NET Core, MVC
ms.author: riande
manager: wpickett
ms.date: 02/28/2017
ms.topic: article
ms.assetid: e04b6665-1638-4d99-1636-d666c4634666
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app-xplat/adding-controller
---
[!INCLUDE[adding-controller](../../includes/mvc-intro/adding-controller1.md)]

* In **VS Code**, select the **EXPLORER** icon and then  control-click (right-click) **Controllers > New File**

 ![Contextual menu](adding-controller/_static/new_file.png)

* Name the file *HelloWorldController.cs*

Replace the contents of *Controllers/HelloWorldController.cs* with the following:

[!code-csharp[Main](../first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_1)]

Every `public` method in a controller is callable as an HTTP endpoint. In the sample above, both methods return a string.  Note the comments preceding each method.

The first comment states this is an [HTTP GET](http://www.w3schools.com/tags/ref_httpmethods.asp) method that is invoked by appending "/HelloWorld/" to the base URL. The second comment specifies an [HTTP GET](http://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html) method that is invoked by appending "/HelloWorld/Welcome/" to the URL. Later on in the tutorial we'll use the scaffolding engine to generate `HTTP POST` methods.

Run the app and navigate to http://localhost:5000/HelloWorld

The `Index` method returns a string. You told the system to return some HTML, and it did!

![Browser window showing an application response of This is my default action](../first-mvc-app/adding-controller/_static/hell1.png)

MVC invokes controller classes (and the action methods within them) depending on the incoming URL. The default [URL routing logic](../../mvc/controllers/routing.md) used by MVC uses a format like this to determine what code to invoke:

`/[Controller]/[ActionName]/[Parameters]`

You set the format for routing in the *Startup.cs* file.

[!code-csharp[Main](../first-mvc-app/start-mvc/sample/MvcMovie/Startup.cs?name=snippet_1&highlight=5)]

When you run the app and don't supply any URL segments, it defaults to the "Home" controller and the "Index" method specified in the template line highlighted above.

The first URL segment determines the controller class to run. So `localhost:5000/HelloWorld` maps to the `HelloWorldController` class. The second part of the URL segment determines the action method on the class. So `localhost:5000/HelloWorld/Index` would cause the `Index` method of the `HelloWorldController` class to run. Notice that we only had to browse to `localhost:5000/HelloWorld` and the `Index` method was called by default. This is because `Index` is the default method that will be called on a controller if a method name is not explicitly specified. The third part of the URL segment ( `id`) is for route data. We'll see route data later on in this tutorial.

Browse to http://localhost:5000/HelloWorld/Welcome
The `Welcome` method runs and returns the string "This is the Welcome action method...". For this URL, the controller is `HelloWorld` and `Welcome` is the action method. We haven't used the `[Parameters]` part of the URL yet.

![Browser window showing an application response of This is the Welcome action method](../first-mvc-app/adding-controller/_static/welcome.png)

Let's modify the example slightly so that you can pass some parameter information  from the URL to the controller (for example, `/HelloWorld/Welcome?name=Scott&numtimes=4`).  Change the `Welcome` method  to include two parameters as shown below. Note that the code uses the C# optional-parameter feature to indicate that the `numTimes` parameter defaults to 1 if no value is passed for that parameter.

[!code-csharp[Main](../first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_2)]

The code above uses `HtmlEncoder.Default.Encode` to protect the app from malicious input (namely JavaScript). It also uses [Interpolated Strings](https://docs.microsoft.com/dotnet/articles/csharp/language-reference/keywords/interpolated-strings).

Run the app and browse to:

   http://localhost:5000/HelloWorld/Welcome?name=Rick&numtimes=4

You can try different values for `name` and `numtimes` in  the URL. The MVC [model binding](xref:mvc/models/model-binding) system automatically maps the named parameters from  the query string in the address bar to parameters in your method. See [Model Binding](xref:mvc/models/model-binding) for more information.

![Browser window showing an application response of Hello Rick, NumTimes is: 4](../first-mvc-app/adding-controller/_static/rick4.png)

In the sample above, the URL segment (`Parameters`) is not used, the `name` and `numTimes` parameters are passed as [query strings](http://en.wikipedia.org/wiki/Query_string). The `?` (question mark) in the above URL is a separator, and the query strings follow. The `&` character separates query strings.

Replace the `Welcome` method with the following code:

[!code-csharp[Main](../first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_3)]

Run the app and enter the following URL:  `http://localhost:5000/HelloWorld/Welcome/3?name=Rick`

![Browser window showing an application response of Hello Rick, ID: 3](../first-mvc-app/adding-controller/_static/rick_routedata.png)

This time the third URL segment  matched the route parameter `id`. The `Welcome`  method contains a parameter  `id` that matched the URL template in the `MapRoute` method. The trailing `?`  (in `id?`) indicates the `id` parameter is optional.

[!code-csharp[Main](../first-mvc-app/start-mvc/sample/MvcMovie/Startup.cs?name=snippet_1&highlight=5)]

In these examples the controller has been doing the "VC" portion  of MVC - that is, the view and controller work. The controller is returning HTML  directly. Generally you don't want controllers returning HTML directly, since  that becomes very cumbersome to code and maintain. Instead we'll typically use a separate Razor view template file to help generate the HTML response.

>[!div class="step-by-step"]
[Previous - Add a controller](start-mvc.md)
[Next - Add a view](adding-view.md)  