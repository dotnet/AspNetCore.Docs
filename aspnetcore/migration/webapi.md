---
title: Migrate from ASP.NET Web API to ASP.NET Core
author: ardalis
description: Learn how to migrate a web API implementation from ASP.NET 4.x Web API to ASP.NET Core MVC.
ms.author: scaddie
ms.custom: mvc
ms.date: 05/26/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: migration/webapi
---
# Migrate from ASP.NET Web API to ASP.NET Core

By [Scott Addie](https://twitter.com/scott_addie) and [Steve Smith](https://ardalis.com/)

An ASP.NET 4.x Web API is an HTTP service that reaches a broad range of clients, including browsers and mobile devices. ASP.NET Core combines ASP.NET 4.x's MVC and Web API app models into a single programming model known as ASP.NET Core MVC. This article demonstrates the steps required to migrate from ASP.NET 4.x Web API to ASP.NET Core MVC.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/migration/webapi/sample) ([how to download](xref:index#how-to-download-a-sample))

::: moniker range=">= aspnetcore-3.0"

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

::: moniker-end

::: moniker range="<= aspnetcore-2.2"
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

* Go to **File** > **New** > **Project** > **Other Project Types** > **Visual Studio Solutions**. Select **Blank Solution**, and name the solution *WebAPIMigration*. Click the **OK** button.
* Add the existing *ProductsApp* project to the solution.
* Add a new **ASP.NET Core Web Application** project to the solution. Select the **.NET Core** target framework from the drop-down, and select the **API** project template. Name the project *ProductsCore*, and click the **OK** button.

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
::: moniker-end
