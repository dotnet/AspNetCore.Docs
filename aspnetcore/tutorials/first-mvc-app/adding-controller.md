---
title: Add a controller to an ASP.NET Core MVC app
author: rick-anderson
description: Learn how to add a controller to a simple ASP.NET Core MVC app.
ms.author: riande
ms.date: 08/05/2017
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: tutorials/first-mvc-app/adding-controller
---

# Add a controller to an ASP.NET Core MVC app

By [Rick Anderson](https://twitter.com/RickAndMSFT)

::: moniker range=">= aspnetcore-3.0"

The Model-View-Controller (MVC) architectural pattern separates an app into three main components: **M**odel, **V**iew, and **C**ontroller. The MVC pattern helps you create apps that are more testable and easier to update than traditional monolithic apps. MVC-based apps contain:

* **M**odels: Classes that represent the data of the app. The model classes use validation logic to enforce business rules for that data. Typically, model objects retrieve and store model state in a database. In this tutorial, a `Movie` model retrieves movie data from a database, provides it to the view or updates it. Updated data is written to a database.

* **V**iews: Views are the components that display the app's user interface (UI). Generally, this UI displays the model data.

* **C**ontrollers: Classes that handle browser requests. They retrieve model data and call view templates that return a response. In an MVC app, the view only displays information; the controller handles and responds to user input and interaction. For example, the controller handles route data and query-string values, and passes these values to the model. The model might use these values to query the database. For example, `https://localhost:5001/Home/Privacy` has route data of `Home` (the controller) and `Privacy` (the action method to call on the home controller). `https://localhost:5001/Movies/Edit/5` is a request to edit the movie with ID=5 using the movie controller. Route data is explained later in the tutorial.

The MVC pattern helps you create apps that separate the different aspects of the app (input logic, business logic, and UI logic), while providing a loose coupling between these elements. The pattern specifies where each kind of logic should be located in the app. The UI logic belongs in the view. Input logic belongs in the controller. Business logic belongs in the model. This separation helps you manage complexity when you build an app, because it enables you to work on one aspect of the implementation at a time without impacting the code of another. For example, you can work on the view code without depending on the business logic code.

We cover these concepts in this tutorial series and show you how to use them to build a movie app. The MVC project contains folders for the *Controllers* and *Views*.

## Add a controller

# [Visual Studio](#tab/visual-studio)

* In **Solution Explorer**, right-click **Controllers > Add > Controller**
  ![Contextual menu](adding-controller/_static/add_controller.png)

* In the **Add Scaffold** dialog box, select **MVC Controller - Empty**

  ![Add MVC controller and name it](adding-controller/_static/ac.png)

* In the **Add Empty MVC Controller dialog**, enter **HelloWorldController** and select **ADD**.

# [Visual Studio Code](#tab/visual-studio-code)

Select the **EXPLORER** icon and then control-click (right-click) **Controllers > New File** and name the new file *HelloWorldController.cs*.

  ![Contextual menu](~/tutorials/first-mvc-app-xplat/adding-controller/_static/new_file.png)

# [Visual Studio for Mac](#tab/visual-studio-mac)

In **Solution Explorer**, right-click **Controllers > Add > New File**.
![Contextual menu](~/tutorials/first-mvc-app-mac/adding-controller/_static/add_controller.png)

Select **ASP.NET Core** and **MVC Controller Class**.

Name the controller **HelloWorldController**.

![Add MVC controller and name it](~/tutorials/first-mvc-app-mac/adding-controller/_static/ac.png)

---

Replace the contents of *Controllers/HelloWorldController.cs* with the following:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_1)]

Every `public` method in a controller is callable as an HTTP endpoint. In the sample above, both methods return a string. Note the comments preceding each method.

An HTTP endpoint is a targetable URL in the web application, such as `https://localhost:5001/HelloWorld`, and combines the protocol used: `HTTPS`, the network location of the web server (including the TCP port): `localhost:5001` and the target URI `HelloWorld`.

The first comment states this is an [HTTP GET](https://www.w3schools.com/tags/ref_httpmethods.asp) method that's invoked by appending `/HelloWorld/` to the base URL. The second comment specifies an [HTTP GET](https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html) method that's invoked by appending `/HelloWorld/Welcome/` to the URL. Later on in the tutorial the scaffolding engine is used to generate `HTTP POST` methods which update data.

Run the app in non-debug mode and append "HelloWorld" to the path in the address bar. The `Index` method returns a string.

![Browser window showing an application response of This is my default action](~/tutorials/first-mvc-app/adding-controller/_static/hell1.png)

MVC invokes controller classes (and the action methods within them) depending on the incoming URL. The default [URL routing logic](xref:mvc/controllers/routing) used by MVC uses a format like this to determine what code to invoke:

`/[Controller]/[ActionName]/[Parameters]`

The routing format is set in the `Configure` method in *Startup.cs* file.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie3/Startup.cs?name=snippet_1&highlight=5)]

When you browse to the app and don't supply any URL segments, it defaults to the "Home" controller and the "Index" method specified in the template line highlighted above.

The first URL segment determines the controller class to run. So `localhost:{PORT}/HelloWorld` maps to the **HelloWorld**Controller class. The second part of the URL segment determines the action method on the class. So `localhost:{PORT}/HelloWorld/Index` would cause the `Index` method of the `HelloWorldController` class to run. Notice that you only had to browse to `localhost:{PORT}/HelloWorld` and the `Index` method was called by default. That's because `Index` is the default method that will be called on a controller if a method name isn't explicitly specified. The third part of the URL segment ( `id`) is for route data. Route data is explained later in the tutorial.

Browse to `https://localhost:{PORT}/HelloWorld/Welcome`. The `Welcome` method runs and returns the string `This is the Welcome action method...`. For this URL, the controller is `HelloWorld` and `Welcome` is the action method. You haven't used the `[Parameters]` part of the URL yet.

![Browser window showing an application response of This is the Welcome action method](~/tutorials/first-mvc-app/adding-controller/_static/welcome.png)

Modify the code to pass some parameter information from the URL to the controller. For example, `/HelloWorld/Welcome?name=Rick&numtimes=4`. Change the `Welcome` method to include two parameters as shown in the following code.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_2)]

The preceding code:

* Uses the C# optional-parameter feature to indicate that the `numTimes` parameter defaults to 1 if no value is passed for that parameter. <!-- remove for simplified -->
* Uses `HtmlEncoder.Default.Encode` to protect the app from malicious input (namely JavaScript).
* Uses [Interpolated Strings](/dotnet/articles/csharp/language-reference/keywords/interpolated-strings) in `$"Hello {name}, NumTimes is: {numTimes}"`. <!-- remove for simplified -->

Run the app and browse to:

   `https://localhost:{PORT}/HelloWorld/Welcome?name=Rick&numtimes=4`

(Replace `{PORT}` with your port number.) You can try different values for `name` and `numtimes` in the URL. The MVC [model binding](xref:mvc/models/model-binding) system automatically maps the named parameters from the query string in the address bar to parameters in your method. See [Model Binding](xref:mvc/models/model-binding) for more information.

![Browser window showing an application response of Hello Rick, NumTimes is\: 4](~/tutorials/first-mvc-app/adding-controller/_static/rick4.png)

In the image above, the URL segment (`Parameters`) isn't used, the `name` and `numTimes` parameters are passed in the [query string](https://wikipedia.org/wiki/Query_string). The `?` (question mark) in the above URL is a separator, and the query string follows. The `&` character separates field-value pairs.

Replace the `Welcome` method with the following code:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_3)]

Run the app and enter the following URL: `https://localhost:{PORT}/HelloWorld/Welcome/3?name=Rick`

This time the third URL segment matched the route parameter `id`. The `Welcome` method contains a parameter `id` that matched the URL template in the `MapControllerRoute` method. The trailing `?` (in `id?`) indicates the `id` parameter is optional.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie3/Startup.cs?name=snippet_1&highlight=5)]

In these examples the controller has been doing the "VC" portion of MVC - that is, the **V**iew and the **C**ontroller work. The controller is returning HTML directly. Generally you don't want controllers returning HTML directly, since that becomes very cumbersome to code and maintain. Instead you typically use a separate Razor view template file to generate the HTML response. You do that in the next tutorial.

> [!div class="step-by-step"]
> [Previous](start-mvc.md)
> [Next](adding-view.md)

::: moniker-end

::: moniker range="< aspnetcore-3.0"

The Model-View-Controller (MVC) architectural pattern separates an app into three main components: **M**odel, **V**iew, and **C**ontroller. The MVC pattern helps you create apps that are more testable and easier to update than traditional monolithic apps. MVC-based apps contain:

* **M**odels: Classes that represent the data of the app. The model classes use validation logic to enforce business rules for that data. Typically, model objects retrieve and store model state in a database. In this tutorial, a `Movie` model retrieves movie data from a database, provides it to the view or updates it. Updated data is written to a database.

* **V**iews: Views are the components that display the app's user interface (UI). Generally, this UI displays the model data.

* **C**ontrollers: Classes that handle browser requests. They retrieve model data and call view templates that return a response. In an MVC app, the view only displays information; the controller handles and responds to user input and interaction. For example, the controller handles route data and query-string values, and passes these values to the model. The model might use these values to query the database. For example, `https://localhost:5001/Home/About` has route data of `Home` (the controller) and `About` (the action method to call on the home controller). `https://localhost:5001/Movies/Edit/5` is a request to edit the movie with ID=5 using the movie controller. Route data is explained later in the tutorial.

The MVC pattern helps you create apps that separate the different aspects of the app (input logic, business logic, and UI logic), while providing a loose coupling between these elements. The pattern specifies where each kind of logic should be located in the app. The UI logic belongs in the view. Input logic belongs in the controller. Business logic belongs in the model. This separation helps you manage complexity when you build an app, because it enables you to work on one aspect of the implementation at a time without impacting the code of another. For example, you can work on the view code without depending on the business logic code.

We cover these concepts in this tutorial series and show you how to use them to build a movie app. The MVC project contains folders for the *Controllers* and *Views*.

## Add a controller

# [Visual Studio](#tab/visual-studio)

* In **Solution Explorer**, right-click **Controllers > Add > Controller**
  ![Contextual menu](adding-controller/_static/add_controller.png)

* In the **Add Scaffold** dialog box, select **MVC Controller - Empty**

  ![Add MVC controller and name it](adding-controller/_static/ac.png)

* In the **Add Empty MVC Controller dialog**, enter **HelloWorldController** and select **ADD**.

# [Visual Studio Code](#tab/visual-studio-code)

Select the **EXPLORER** icon and then control-click (right-click) **Controllers > New File** and name the new file *HelloWorldController.cs*.

  ![Contextual menu](~/tutorials/first-mvc-app-xplat/adding-controller/_static/new_file.png)

# [Visual Studio for Mac](#tab/visual-studio-mac)

In **Solution Explorer**, right-click **Controllers > Add > New File**.
![Contextual menu](~/tutorials/first-mvc-app-mac/adding-controller/_static/add_controller.png)

Select **ASP.NET Core** and **MVC Controller Class**.

Name the controller **HelloWorldController**.

![Add MVC controller and name it](~/tutorials/first-mvc-app-mac/adding-controller/_static/ac.png)

---

Replace the contents of *Controllers/HelloWorldController.cs* with the following:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_1)]

Every `public` method in a controller is callable as an HTTP endpoint. In the sample above, both methods return a string. Note the comments preceding each method.

An HTTP endpoint is a targetable URL in the web application, such as `https://localhost:5001/HelloWorld`, and combines the protocol used: `HTTPS`, the network location of the web server (including the TCP port): `localhost:5001` and the target URI `HelloWorld`.

The first comment states this is an [HTTP GET](https://www.w3schools.com/tags/ref_httpmethods.asp) method that's invoked by appending `/HelloWorld/` to the base URL. The second comment specifies an [HTTP GET](https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html) method that's invoked by appending `/HelloWorld/Welcome/` to the URL. Later on in the tutorial the scaffolding engine is used to generate `HTTP POST` methods which update data.

Run the app in non-debug mode and append "HelloWorld" to the path in the address bar. The `Index` method returns a string.

![Browser window showing an application response of This is my default action](~/tutorials/first-mvc-app/adding-controller/_static/hell1.png)

MVC invokes controller classes (and the action methods within them) depending on the incoming URL. The default [URL routing logic](xref:mvc/controllers/routing) used by MVC uses a format like this to determine what code to invoke:

`/[Controller]/[ActionName]/[Parameters]`

The routing format is set in the `Configure` method in *Startup.cs* file.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Startup.cs?name=snippet_1&highlight=5)]

<!-- 
Add link to explain lambda.
Remove link for simplified tutorial.
-->

When you browse to the app and don't supply any URL segments, it defaults to the "Home" controller and the "Index" method specified in the template line highlighted above.

The first URL segment determines the controller class to run. So `localhost:{PORT}/HelloWorld` maps to the `HelloWorldController` class. The second part of the URL segment determines the action method on the class. So `localhost:{PORT}/HelloWorld/Index` would cause the `Index` method of the `HelloWorldController` class to run. Notice that you only had to browse to `localhost:{PORT}/HelloWorld` and the `Index` method was called by default. This is because `Index` is the default method that will be called on a controller if a method name isn't explicitly specified. The third part of the URL segment ( `id`) is for route data. Route data is explained later in the tutorial.

Browse to `https://localhost:{PORT}/HelloWorld/Welcome`. The `Welcome` method runs and returns the string `This is the Welcome action method...`. For this URL, the controller is `HelloWorld` and `Welcome` is the action method. You haven't used the `[Parameters]` part of the URL yet.

![Browser window showing an application response of This is the Welcome action method](~/tutorials/first-mvc-app/adding-controller/_static/welcome.png)

Modify the code to pass some parameter information from the URL to the controller. For example, `/HelloWorld/Welcome?name=Rick&numtimes=4`. Change the `Welcome` method to include two parameters as shown in the following code.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_2)]

The preceding code:

* Uses the C# optional-parameter feature to indicate that the `numTimes` parameter defaults to 1 if no value is passed for that parameter. <!-- remove for simplified -->
* Uses `HtmlEncoder.Default.Encode` to protect the app from malicious input (namely JavaScript).
* Uses [Interpolated Strings](/dotnet/articles/csharp/language-reference/keywords/interpolated-strings) in `$"Hello {name}, NumTimes is: {numTimes}"`. <!-- remove for simplified -->

Run the app and browse to:

   `https://localhost:{PORT}/HelloWorld/Welcome?name=Rick&numtimes=4`

(Replace `{PORT}` with your port number.) You can try different values for `name` and `numtimes` in the URL. The MVC [model binding](xref:mvc/models/model-binding) system automatically maps the named parameters from the query string in the address bar to parameters in your method. See [Model Binding](xref:mvc/models/model-binding) for more information.

![Browser window showing an application response of Hello Rick, NumTimes is\: 4](~/tutorials/first-mvc-app/adding-controller/_static/rick4.png)

In the image above, the URL segment (`Parameters`) isn't used, the `name` and `numTimes` parameters are passed in the [query string](https://wikipedia.org/wiki/Query_string). The `?` (question mark) in the above URL is a separator, and the query string follows. The `&` character separates field-value pairs.

Replace the `Welcome` method with the following code:

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Controllers/HelloWorldController.cs?name=snippet_3)]

Run the app and enter the following URL: `https://localhost:{PORT}/HelloWorld/Welcome/3?name=Rick`

This time the third URL segment matched the route parameter `id`. The `Welcome` method contains a parameter `id` that matched the URL template in the `MapRoute` method. The trailing `?` (in `id?`) indicates the `id` parameter is optional.

[!code-csharp[](~/tutorials/first-mvc-app/start-mvc/sample/MvcMovie/Startup.cs?name=snippet_1&highlight=5)]

In these examples the controller has been doing the "VC" portion of MVC - that is, the view and controller work. The controller is returning HTML directly. Generally you don't want controllers returning HTML directly, since that becomes very cumbersome to code and maintain. Instead you typically use a separate Razor view template file to help generate the HTML response. You do that in the next tutorial.

> [!div class="step-by-step"]
> [Previous](start-mvc.md)
> [Next](adding-view.md)

::: moniker-end
