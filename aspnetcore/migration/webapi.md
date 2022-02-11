---
title: Migrate from ASP.NET Web API to ASP.NET Core
author: ardalis
description: Learn how to migrate a web API implementation from ASP.NET 4.x Web API to ASP.NET Core MVC.
ms.author: scaddie
ms.custom: mvc
ms.date: 01/31/2022
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: migration/webapi
---
# Migrate from ASP.NET Web API to ASP.NET Core

ASP.NET Core combines ASP.NET 4.x's MVC and Web API app models into a single programming model known as ASP.NET Core MVC.

:::moniker range=">= aspnetcore-6.0"
This article shows how to migrate the Products controller created in [Getting Started with ASP.NET Web API 2](/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api) to ASP.NET Core.

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-6.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-6.0.md)]

---

## Create the new ASP.NET Core Web API project

# [Visual Studio](#tab/visual-studio)

1. From the **File** menu, select **New** > **Project**.
1. Enter *Web API* in the search box.
1. Select the **ASP.NET Core Web API** template and select **Next**.
1. In the **Configure your new project** dialog, name the project *ProductsCore* and select **Next**.
1. In the **Additional information** dialog:
   1. Confirm the **Framework** is **.NET 6.0 (Long-term support)**.
   1. Confirm the checkbox for **Use controllers(uncheck to use minimal APIs)** is checked.
   1. Uncheck **Enable OpenAPI support**.
   1. Select **Create**.
1. Remove the *WeatherForecast.cs* and *Controllers/WeatherForecastController.cs* example files from the new *ProductsCore* project.
1. Open *Properties\launchSettings.json*.
1. Change `launchUrl` properties from `weatherforcast` to `productscore`.

# [Visual Studio Code](#tab/visual-studio-code)

1. Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
1. Change directories (`cd`) to the folder that will contain the project folder.
1. Run the following commands to create a new web API project and open it in Visual Studio Code:

   ```dotnetcli
   dotnet new webapi -o ProductsCore --no-openapi
   cd ProductsCore
   code -r ../ProductsCore
   ```

---

## Add the ASP.NET Web API 2 controller and model to migrate

# [Visual Studio](#tab/visual-studio)

Add the example model class:

1. In **Solution Explorer**, right-click the project. Select **Add** > **New Folder**. Name the folder *Models*.
1. Right-click the **Models** folder. Select **Add** > **Class**. Name the class *Product* and select **Add**.
1. Replace the template model code with the following:

   [!code-csharp[](webapi/sample/3.x/ProductsApp/Models/Product.cs)]

Create a Products controller

1. Right-click the **Controllers** folder.
1. Select **Add > Controller...**.
1. In **Add New Scaffolded Item** dialog, select **Mvc Controller - Empty** then select **Add**.
1. Name the controller *ProductsController* and select **Add**.
1. Replace the template controller code with the following:

   [!code-csharp[](webapi/sample/3.x/ProductsApp/Controllers/ProductsController.cs)]

# [Visual Studio Code](#tab/visual-studio-code)

Copy the *Product* model:

1. Add a folder named *Models*.
1. Add a *Product* class to the *Models* folder with the following code:

   [!code-csharp[](webapi/sample/3.x/ProductsApp/Models/Product.cs)]

Copy the *ProductsController*:

1. Add a *ProductsController* class to the *Controllers* folder with the following code:

   [!code-csharp[](webapi/sample/3.x/ProductsApp/Controllers/ProductsController.cs)]

---

## The configuration for ASP.NET Core Web API

ASP.NET Core doesn't use the *App_Start* folder or the *Global.asax* file. The *web.config* file is added at publish time. For more information, see <xref:host-and-deploy/iis/web-config>.

The *Program.cs* file:

* Replaces *Global.asax*.
* Handles all app startup tasks.

For more information, see <xref:fundamentals/startup>.

The following shows the application startup code in the ASP.NET Core *Program.cs* file:

[!code-csharp[](webapi/sample/6.x/ProductsCore/Program.cs)]

## Copy the model

By utilizing the [Nullable feature introduced in C# 8](/dotnet/csharp/whats-new/csharp-8#nullable-reference-types), ASP.NET Core can provide additional code flow analysis and compile-time safety in the handling of reference types. For example, protecting against `null` reference exceptions.

ASP.NET Core 6.0 projects enable nullable reference types by default. For more information, see [Nullable reference types](/dotnet/csharp/nullable-references).

Examine *Models/Product.cs*. With nullable reference types enabled for the ProductCore project, helpful `non-nullable property` warnings are visible for the `Name` and `Category` properties.

In this case, the intent is that the `Name` and `Category` can be nullable types.

Add the `?` annotation to declare the `Name` and `Category` properties as nullable reference types:

```diff
public int Id { get; set; }
- public string Name { get; set; }
+ public string? Name { get; set; }
- public string Category { get; set; }
+ public string? Category { get; set; }
public decimal Price { get; set; }
```

## Migrate the controller

Update the `ProductsController` for ASP.NET Core with the following highlighted code:

[!code-csharp[](webapi/sample/6.x/ProductsCore/Controllers/ProductsController.cs?highlight=1,2,4,6,7,8,33,50,57)]

The preceding highlighted code changes the following:

* Removes using statements for the following ASP.NET 4.x components that don't exist in ASP.NET Core:

  * `ApiController` class
  * `System.Web.Http` namespace
  * `IHttpActionResult` interface

* Changes the `using ProductsApp.Models;` statement to `using ProductsCore.Models;`.
* Sets the root namespace to `ProductsCore`.
* Changes `ApiController` to <xref:Microsoft.AspNetCore.Mvc.ControllerBase>.
* Adds `using Microsoft.AspNetCore.Mvc;` to resolve the `ControllerBase` reference.
* Changes the `GetProduct` action's return type from `IHttpActionResult` to `ActionResult<Product>`. For more info, see [Controller action return types](/aspnet/web-api/action-return-types).
* Simplifies the `GetProduct` action's `return` statement to the following statement:

    ```csharp
    return product;
    ```

* Adds `[Route("api/[controller]")]` and `[ApiController]` attributes, which are explained in the next section.

## Routing

ASP.NET Core provides a minimal hosting model in which the endpoint routing middleware wraps the entire middleware pipeline, therefore routes can be added directly to the <xref:Microsoft.AspNetCore.Builder.WebApplication> without an explicit call to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> or <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> to register routes.

`UseRouting` can still be used to specify where route matching happens, but `UseRouting` doesn't need to be explicitly called if routes should be matched at the beginning of the middleware pipeline.

[!code-csharp[](webapi/sample/6.x/ProductsCore/Program.cs?highlight=15)]

**Note:** Routes added directly to the <xref:Microsoft.AspNetCore.Builder.WebApplication> execute at the ***end*** of the pipeline.

## Routing in the migrated `ProductsController`

1. The migrated `ProductsController` contains the following highlighted attributes:

    [!code-csharp[](webapi/sample/6.x/ProductsCore/Controllers/ProductsController.cs?highlight=6,7)]

    The preceding [`[Route]`](xref:Microsoft.AspNetCore.Mvc.RouteAttribute) attribute [configures the controller's attribute routing](xref:fundamentals/routing) pattern. The [`[ApiController]`](xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute) attribute makes attribute routing a requirement for all actions in this controller.

    Attribute routing supports tokens, such as [`[controller]`](mvc/controllers/routing?#token-replacement-in-route-templates-controller-action-area) and [`[action]`](mvc/controllers/routing?#token-replacement-in-route-templates-controller-action-area). At runtime, each token is replaced with the name of the controller or action, respectively, to which the attribute has been applied. The tokens:
    * Reduces or eliminates the need to use hard coded strings for the route.
    * Ensure routes remain synchronized with the corresponding controllers and actions when automatic rename refactorings are applied.
1. Enable HTTP Get requests to the `ProductController` actions:
    * Apply the [`[HttpGet]`](xref:Microsoft.AspNetCore.Mvc.HttpGetAttribute) attribute to the `GetAllProducts` action.
    * Apply the `[HttpGet("{id}")]` attribute to the `GetProduct` action.

Run the migrated project, and browse to `/api/products`.  For example: https://localhost:`<port>`/api/products. A full list of three products appears. Browse to `/api/products/1`. The first product appears.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/migration/webapi/sample/) ([how to download](xref:index#how-to-download-a-sample))

## Additional resources

* <xref:web-api/index>
* <xref:web-api/action-return-types>
* <xref:mvc/compatibility-version>

:::moniker-end

:::moniker range="< aspnetcore-5.0 >= aspnetcore-3.0"
This article demonstrates the steps required to migrate from ASP.NET 4.x Web API to ASP.NET Core MVC.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/migration/webapi/sample) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

[!INCLUDE [prerequisites](../includes/net-core-prereqs-vs-3.1.md)]

## Review ASP.NET 4.x Web API project

This article uses the *ProductsApp* project created in [Getting Started with ASP.NET Web API 2](/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api). In that project, a basic ASP.NET 4.x Web API project is configured as follows.

In *Global.asax.cs*, a call is made to `WebApiConfig.Register`:

[!code-csharp[](webapi/sample/3.x/ProductsApp/Global.asax.cs?highlight=14)]

The `WebApiConfig` class is found in the *App_Start* folder and has a static `Register` method:

[!code-csharp[](webapi/sample/3.x/ProductsApp/App_Start/WebApiConfig.cs)]

The preceding class:

* Configures [attribute routing](/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2), although it's not actually being used.
* Configures the routing table.
The sample code expects URLs to match the format `/api/{controller}/{id}`, with `{id}` being optional.

The following sections demonstrate migration of the Web API project to ASP.NET Core MVC.

## Create the destination project

Create a new blank solution in Visual Studio and add the ASP.NET 4.x Web API project to migrate:

1. From the **File** menu, select **New** > **Project**.
1. Select the **Blank Solution** template and select **Next**.
1. Name the solution *WebAPIMigration*. Select **Create**.
1. Add the existing *ProductsApp* project to the solution.

Add a new API project to migrate to:

1. Add a new **ASP.NET Core Web Application** project to the solution.
1. In the **Configure your new project** dialog, Name the project *ProductsCore*, and select **Create**.
1. In the **Create a new ASP.NET Core Web Application** dialog, confirm that **.NET Core** and **ASP.NET Core 3.1** are selected. Select the **API** project template, and select **Create**.
1. Remove the *WeatherForecast.cs* and *Controllers/WeatherForecastController.cs* example files from the new *ProductsCore* project.

The solution now contains two projects. The following sections explain migrating the *ProductsApp* project's contents to the *ProductsCore* project.

## Migrate configuration

ASP.NET Core doesn't use the *App_Start* folder or the *Global.asax* file. Additionally, the *web.config* file is added at publish time.

The `Startup` class:

* Replaces *Global.asax*.
* Handles all app startup tasks.

For more information, see <xref:fundamentals/startup>.

## Migrate models and controllers

The following code shows the `ProductsController` to be updated for ASP.NET Core:

[!code-csharp[](webapi/sample/3.x/ProductsApp/Controllers/ProductsController.cs)]

Update the `ProductsController` for ASP.NET Core:

1. Copy *Controllers/ProductsController.cs* and the *Models* folder from the original project to the new one.
1. Change the copied files' root namespace to `ProductsCore`.
1. Update the `using ProductsApp.Models;` statement to `using ProductsCore.Models;`.

The following components don't exist in ASP.NET Core:

* `ApiController` class
* `System.Web.Http` namespace
* `IHttpActionResult` interface

Make the following changes:

1. Change `ApiController` to <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. Add `using Microsoft.AspNetCore.Mvc;` to resolve the `ControllerBase` reference.
1. Delete `using System.Web.Http;`.
1. Change the `GetProduct` action's return type from `IHttpActionResult` to `ActionResult<Product>`.
1. Simplify the `GetProduct` action's `return` statement to the following:

    ```csharp
    return product;
    ```

## Configure routing

The ASP.NET Core *API* project template includes endpoint routing configuration in the generated code.

The following <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> calls:

* Register route matching and endpoint execution in the [middleware](xref:fundamentals/middleware/index) pipeline.
* Replace the *ProductsApp* project's *App_Start/WebApiConfig.cs* file.

[!code-csharp[](webapi/sample/3.x/ProductsCore/Startup.cs?name=snippet_Configure&highlight=10,14)]

Configure routing as follows:

1. Mark the `ProductsController` class with the following attributes:

    ```csharp
    [Route("api/[controller]")]
    [ApiController]
    ```

    The preceding [`[Route]`](xref:Microsoft.AspNetCore.Mvc.RouteAttribute) attribute configures the controller's attribute routing pattern. The [`[ApiController]`](xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute) attribute makes attribute routing a requirement for all actions in this controller.

    Attribute routing supports tokens, such as `[controller]` and `[action]`. At runtime, each token is replaced with the name of the controller or action, respectively, to which the attribute has been applied. The tokens:
    * Reduce the number of magic strings in the project.
    * Ensure routes remain synchronized with the corresponding controllers and actions when automatic rename refactorings are applied.
1. Enable HTTP Get requests to the `ProductController` actions:
    * Apply the [`[HttpGet]`](xref:Microsoft.AspNetCore.Mvc.HttpGetAttribute) attribute to the `GetAllProducts` action.
    * Apply the `[HttpGet("{id}")]` attribute to the `GetProduct` action.

Run the migrated project, and browse to `/api/products`. A full list of three products appears. Browse to `/api/products/1`. The first product appears.

## Additional resources

* <xref:web-api/index>
* <xref:web-api/action-return-types>
* <xref:mvc/compatibility-version>
:::moniker-end

:::moniker range="<= aspnetcore-2.2"
This article demonstrates the steps required to migrate from ASP.NET 4.x Web API to ASP.NET Core MVC.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/migration/webapi/sample) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

[!INCLUDE [prerequisites](../includes/net-core-prereqs-vs2019-2.2.md)]

## Review ASP.NET 4.x Web API project

This article uses the *ProductsApp* project created in [Getting Started with ASP.NET Web API 2](/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api). In that project, a basic ASP.NET 4.x Web API project is configured as follows.

In *Global.asax.cs*, a call is made to `WebApiConfig.Register`:

[!code-csharp[](webapi/sample/2.x/ProductsApp/Global.asax.cs?highlight=14)]

The `WebApiConfig` class is found in the *App_Start* folder and has a static `Register` method:

[!code-csharp[](webapi/sample/2.x/ProductsApp/App_Start/WebApiConfig.cs)]

This class configures [attribute routing](/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2), although it's not actually being used in the project. It also configures the routing table, which is used by ASP.NET Web API. In this case, ASP.NET 4.x Web API expects URLs to match the format `/api/{controller}/{id}`, with `{id}` being optional.

The following sections demonstrate migration of the Web API project to ASP.NET Core MVC.

## Create the destination project

Complete the following steps in Visual Studio:

* Go to **File** > **New** > **Project** > **Other Project Types** > **Visual Studio Solutions**. Select **Blank Solution**, and name the solution *WebAPIMigration*. Select the **OK** button.
* Add the existing *ProductsApp* project to the solution.
* Add a new **ASP.NET Core Web Application** project to the solution. Select the **.NET Core** target framework from the drop-down, and select the **API** project template. Name the project *ProductsCore*, and select the **OK** button.

The solution now contains two projects. The following sections explain migrating the *ProductsApp* project's contents to the *ProductsCore* project.

## Migrate configuration

ASP.NET Core doesn't use:

* *App_Start* folder or the *Global.asax* file
* *web.config* file is added at publish time.

The `Startup` class:

* Replaces *Global.asax*.
* Handles all app startup tasks.

For more information, see <xref:fundamentals/startup>.

In ASP.NET Core MVC, attribute routing is included by default when <xref:Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvc*> is called in `Startup.Configure`. The following `UseMvc` call replaces the *ProductsApp* project's *App_Start/WebApiConfig.cs* file:

[!code-csharp[](webapi/sample/2.x/ProductsCore/Startup.cs?name=snippet_Configure&highlight=13)]

## Migrate models and controllers

The following code shows the `ProductsController` update for ASP.NET Core:
[!code-csharp[](webapi/sample/2.x/ProductsApp/Controllers/ProductsController.cs)]

Update the `ProductsController` for ASP.NET Core:

1. Copy *Controllers/ProductsController.cs* from the original project to the new one.
1. Copy the *Models* folder from the original project to the new one.
1. Change the copied files' root namespace to `ProductsCore`.
1. Update the `using ProductsApp.Models;` statement to `using ProductsCore.Models;`.

The following components don't exist in ASP.NET Core:

* `ApiController` class
* `System.Web.Http` namespace
* `IHttpActionResult` interface

Make the following changes:

1. Change `ApiController` to <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. Add `using Microsoft.AspNetCore.Mvc;` to resolve the `ControllerBase` reference.
1. Delete `using System.Web.Http;`.
1. Change the `GetProduct` action's return type from `IHttpActionResult` to `ActionResult<Product>`.
1. Simplify the `GetProduct` action's `return` statement to the following:

    ```csharp
    return product;
    ```

## Configure routing

Configure routing as follows:

1. Mark the `ProductsController` class with the following attributes:

    ```csharp
    [Route("api/[controller]")]
    [ApiController]
    ```

    The preceding [`[Route]`](xref:Microsoft.AspNetCore.Mvc.RouteAttribute) attribute configures the controller's attribute routing pattern. The [`[ApiController]`](xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute) attribute makes attribute routing a requirement for all actions in this controller.

    Attribute routing supports tokens, such as `[controller]` and `[action]`. At runtime, each token is replaced with the name of the controller or action, respectively, to which the attribute has been applied. The tokens reduce the number of magic strings in the project. The tokens also ensure routes remain synchronized with the corresponding controllers and actions when automatic rename refactorings are applied.
1. Set the project's compatibility mode to ASP.NET Core 2.2:

    [!code-csharp[](webapi/sample/2.x/ProductsCore/Startup.cs?name=snippet_ConfigureServices&highlight=4)]

    The preceding change:

    * Is required to use the `[ApiController]` attribute at the controller level.
    * Opts in to potentially breaking behaviors introduced in ASP.NET Core 2.2.
1. Enable HTTP Get requests to the `ProductController` actions:
    * Apply the [`[HttpGet]`](xref:Microsoft.AspNetCore.Mvc.HttpGetAttribute) attribute to the `GetAllProducts` action.
    * Apply the `[HttpGet("{id}")]` attribute to the `GetProduct` action.

Run the migrated project, and browse to `/api/products`. A full list of three products appears. Browse to `/api/products/1`. The first product appears.

## Compatibility shim

The [Microsoft.AspNetCore.Mvc.WebApiCompatShim](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.WebApiCompatShim) library provides a compatibility shim to move ASP.NET 4.x Web API projects to ASP.NET Core. The compatibility shim extends ASP.NET Core to support a number of conventions from ASP.NET 4.x Web API 2. The sample ported previously in this document is basic enough that the compatibility shim was unnecessary. For larger projects, using the compatibility shim can be useful for temporarily bridging the API gap between ASP.NET Core and ASP.NET 4.x Web API 2.

The Web API compatibility shim is meant to be used as a temporary measure to support migrating large ASP.NET 4.x Web API projects to ASP.NET Core. Over time, projects should be updated to use ASP.NET Core patterns instead of relying on the compatibility shim.

Compatibility features included in `Microsoft.AspNetCore.Mvc.WebApiCompatShim` include:

* Adds an `ApiController` type so that controllers' base types don't need to be updated.
* Enables Web API-style model binding. ASP.NET Core MVC model binding functions similarly to that of ASP.NET 4.x MVC 5, by default. The compatibility shim changes model binding to be more similar to ASP.NET 4.x Web API 2 model binding conventions. For example, complex types are automatically bound from the request body.
* Extends model binding so that controller actions can take parameters of type `HttpRequestMessage`.
* Adds message formatters allowing actions to return results of type `HttpResponseMessage`.
* Adds additional response methods that Web API 2 actions may have used to serve responses:
  * `HttpResponseMessage` generators:
    * `CreateResponse<T>`
    * `CreateErrorResponse`
  * Action result methods:
    * `BadRequestErrorMessageResult`
    * `ExceptionResult`
    * `InternalServerErrorResult`
    * `InvalidModelStateResult`
    * `NegotiatedContentResult`
    * `ResponseMessageResult`
* Adds an instance of `IContentNegotiator` to the app's dependency injection (DI) container and makes available the content negotiation-related types from [Microsoft.AspNet.WebApi.Client](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Client/). Examples of such types include `DefaultContentNegotiator` and `MediaTypeFormatter`.

To use the compatibility shim:

1. Install the [Microsoft.AspNetCore.Mvc.WebApiCompatShim](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.WebApiCompatShim) NuGet package.
1. Register the compatibility shim's services with the app's DI container by calling `services.AddMvc().AddWebApiConventions()` in `Startup.ConfigureServices`.
1. Define web API-specific routes using `MapWebApiRoute` on the `IRouteBuilder` in the app's `IApplicationBuilder.UseMvc` call.

## Additional resources

* <xref:web-api/index>
* <xref:web-api/action-return-types>
* <xref:mvc/compatibility-version>
:::moniker-end
