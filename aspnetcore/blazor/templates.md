---
title: ASP.NET Core Blazor templates
author: guardrex
description: Learn about ASP.NET Core Blazor app templates and Blazor project structure.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/26/2020
no-loc: [Blazor, SignalR]
uid: blazor/templates
---
# ASP.NET Core Blazor templates

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

The Blazor framework provides templates to develop apps for each of the Blazor hosting models:

* Blazor WebAssembly (`blazorwasm`)
* Blazor Server (`blazorserver`)

For more information on Blazor's hosting models, see <xref:blazor/hosting-models>.

For step-by-step instructions on creating a Blazor app from a template, see <xref:blazor/get-started>.

## Blazor project structure

The following files and folders make up a Blazor app generated from a Blazor template:

* *Program.cs* &ndash; The app's entry point that sets up the:

  * ASP.NET Core [host](xref:fundamentals/host/generic-host) (Blazor Server)
  * WebAssembly host (Blazor WebAssembly) &ndash; The code in this file is unique to apps created from the Blazor WebAssembly template (`blazorwasm`).
    * The `App` component, which is the root component of the app, is specified as the `app` DOM element to the `Add` method.
    * Services can be configured with the `ConfigureServices` method on the host builder (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>();`).
    * Configuration can be supplied via the host builder (`builder.Configuration`).

* *Startup.cs* (Blazor Server) &ndash; Contains the app's startup logic. The `Startup` class defines two methods:

  * `ConfigureServices` &ndash; Configures the app's [dependency injection (DI)](xref:fundamentals/dependency-injection) services. In Blazor Server apps, services are added by calling <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor*>, and the `WeatherForecastService` is added to the service container for use by the example `FetchData` component.
  * `Configure` &ndash; Configures the app's request handling pipeline:
    * <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub*> is called to set up an endpoint for the real-time connection with the browser. The connection is created with [SignalR](xref:signalr/introduction), which is a framework for adding real-time web functionality to apps.
    * [MapFallbackToPage("/_Host")](xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage*) is called to set up the root page of the app (*Pages/_Host.cshtml*) and enable navigation.

* *wwwroot/index.html* (Blazor WebAssembly) &ndash; The root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The `App` component (*App.razor*) is specified as the `app` DOM element to the `AddComponent` method in `Startup.Configure`.
  * The `_framework/blazor.webassembly.js` JavaScript file is loaded, which:
    * Downloads the .NET runtime, the app, and the app's dependencies.
    * Initializes the runtime to run the app.

* *App.razor* &ndash; The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The `Router` component intercepts browser navigation and renders the page that matches the requested address.

* *Pages* folder &ndash; Contains the routable components/pages (*.razor*) that make up the Blazor app and the root Razor page of a Blazor Server app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following:
  * *_Host.cshtml* (Blazor Server) &ndash; The root page of the app implemented as a Razor Page:
    * When any page of the app is initially requested, this page is rendered and returned in the response.
    * The `_framework/blazor.server.js` JavaScript file is loaded, which sets up the real-time SignalR connection between the browser and the server.
    * The Host page specifies where the root `App` component (*App.razor*) is rendered.
  * `Counter` (*Counter.razor*) &ndash; Implements the Counter page.
  * `Error` (*Error.razor*, Blazor Server app only) &ndash; Rendered when an unhandled exception occurs in the app.
  * `FetchData` (*FetchData.razor*) &ndash; Implements the Fetch data page.
  * `Index` (*Index.razor*) &ndash; Implements the Home page.

* *Shared* folder &ndash; Contains other UI components (*.razor*) used by the app:
  * `MainLayout` (*MainLayout.razor*) &ndash; The app's layout component.
  * `NavMenu` (*NavMenu.razor*) &ndash; Implements sidebar navigation. Includes the [NavLink component](xref:blazor/routing#navlink-component) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The `NavLink` component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.

* *_Imports.razor* &ndash; Includes common Razor directives to include in the app's components (*.razor*), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* *Data* folder (Blazor Server) &ndash; Contains the `WeatherForecast` class and implementation of the `WeatherForecastService` that provide example weather data to the app's `FetchData` component.

* *wwwroot* &ndash; The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets.

* *appsettings.json* (Blazor Server) &ndash; Configuration settings for the app.
