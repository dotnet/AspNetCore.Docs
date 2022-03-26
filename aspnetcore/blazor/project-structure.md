---
title: ASP.NET Core Blazor project structure
author: guardrex
description: Learn about ASP.NET Core Blazor app project structure.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/project-structure
---
# ASP.NET Core Blazor project structure

This article describes the files and folders that make up a Blazor app generated from a Blazor project template.

:::moniker range=">= aspnetcore-6.0"

## Blazor Server

Blazor Server project template: `blazorserver`

The Blazor Server template creates the initial files and directory structure for a Blazor Server app. The app is populated with demonstration code for a `FetchData` component that loads data from a registered service, `WeatherForecastService`, and user interaction with a `Counter` component.

* `Data` folder: Contains the `WeatherForecast` class and implementation of the `WeatherForecastService` that provides example weather data to the app's `FetchData` component.

* `Pages` folder: Contains the routable components/pages (`.razor`) that make up the Blazor app and the root Razor page of a Blazor Server app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following:
  * `_Host.cshtml`: The root page of the app implemented as a Razor Page:
    * When any page of the app is initially requested, this page is rendered and returned in the response.
    * The Host page specifies where the root `App` component (`App.razor`) is rendered.
  * `_Layout.cshtml`: The layout page for the `_Host.cshtml` root page of the app.
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `Error` component (`Error.razor`): Rendered when an unhandled exception occurs in the app.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.

> [!NOTE]
> JavaScript (JS) files added to the `Pages/_Layout.cshtml` file should appear before the closing `</body>` tag. The order that custom JS code is loaded from JS files is important in some scenarios. For example, ensure that JS files with interop methods are included before Blazor framework JS files.

* `Properties/launchSettings.json`: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson).

* `Shared` folder: Contains the following shared components and stylesheets:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot`: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets.

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `appsettings.json` and environmental app settings files: Provide [configuration settings](xref:blazor/fundamentals/configuration) for the app.

* `Program.cs`: The app's entry point that sets up the ASP.NET Core [host](xref:fundamentals/host/generic-host) and contains the app's startup logic, including service registrations and request processing pipeline configuration:

  * Specifies the app's [dependency injection (DI)](xref:fundamentals/dependency-injection) services. Services are added by calling <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>, and the `WeatherForecastService` is added to the service container for use by the example `FetchData` component.
  * Configures the app's request handling pipeline:
    * <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> is called to set up an endpoint for the real-time connection with the browser. The connection is created with [SignalR](xref:signalr/introduction), which is a framework for adding real-time web functionality to apps.
    * [`MapFallbackToPage("/_Host")`](xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A) is called to set up the root page of the app (`Pages/_Host.cshtml`) and enable navigation.

Additional files and folders may appear in an app produced from a Blazor Server project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

## Blazor WebAssembly

Blazor WebAssembly project template: `blazorwasm`

The Blazor WebAssembly template creates the initial files and directory structure for a Blazor WebAssembly app. The app is populated with demonstration code for a `FetchData` component that loads data from a static asset, `weather.json`, and user interaction with a `Counter` component.

* `Pages` folder: Contains the routable components/pages (`.razor`) that make up the Blazor app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following components:
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.
  
* `Properties/launchSettings.json`: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson).

* `Shared` folder: Contains the following shared components and stylesheets:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot`: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets, including `appsettings.json` and environmental app settings files for [configuration settings](xref:blazor/fundamentals/configuration). The `index.html` webpage is the root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The component is rendered at the location of the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>`).

> [!NOTE]
> JavaScript (JS) files added to the `wwwroot/index.html` file should appear before the closing `</body>` tag. The order that custom JS code is loaded from JS files is important in some scenarios. For example, ensure that JS files with interop methods are included before Blazor framework JS files.

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `Program.cs`: The app's entry point that sets up the WebAssembly host:
  
  * The `App` component is the root component of the app. The `App` component is specified as the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>` in `wwwroot/index.html`) to the root component collection (`builder.RootComponents.Add<App>("#app")`).
  * [Services](xref:blazor/fundamentals/dependency-injection) are added and configured (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>()`).

Additional files and folders may appear in an app produced from a Blazor WebAssembly project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

## Additional resources

* <xref:blazor/tooling>
* <xref:blazor/hosting-models>
* <xref:fundamentals/minimal-apis>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

## Blazor Server

Blazor Server project template: `blazorserver`

The Blazor Server template creates the initial files and directory structure for a Blazor Server app. The app is populated with demonstration code for a `FetchData` component that loads data from a registered service, `WeatherForecastService`, and user interaction with a `Counter` component.

* `Data` folder: Contains the `WeatherForecast` class and implementation of the `WeatherForecastService` that provides example weather data to the app's `FetchData` component.

* `Pages` folder: Contains the routable components/pages (`.razor`) that make up the Blazor app and the root Razor page of a Blazor Server app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following:
  * `_Host.cshtml`: The root page of the app implemented as a Razor Page:
    * When any page of the app is initially requested, this page is rendered and returned in the response.
    * The Host page specifies where the root `App` component (`App.razor`) is rendered.
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `Error` component (`Error.razor`): Rendered when an unhandled exception occurs in the app.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.

> [!NOTE]
> JavaScript (JS) files added to the `Pages/_Host.cshtml` file should appear before the closing `</body>` tag. The order that custom JS code is loaded from JS files is important in some scenarios. For example, ensure that JS files with interop methods are included before Blazor framework JS files.

* `Properties/launchSettings.json`: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson).

* `Shared` folder: Contains the following shared components and stylesheets:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot`: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets.

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `appsettings.json` and environmental app settings files: Provide [configuration settings](xref:blazor/fundamentals/configuration) for the app.

* `Program.cs`: The app's entry point that sets up the ASP.NET Core [host](xref:fundamentals/host/generic-host).

* `Startup.cs`: Contains the app's startup logic. The `Startup` class defines two methods:

  * `ConfigureServices`: Configures the app's [dependency injection (DI)](xref:fundamentals/dependency-injection) services. Services are added by calling <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>, and the `WeatherForecastService` is added to the service container for use by the example `FetchData` component.
  * `Configure`: Configures the app's request handling pipeline:
    * <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> is called to set up an endpoint for the real-time connection with the browser. The connection is created with [SignalR](xref:signalr/introduction), which is a framework for adding real-time web functionality to apps.
    * [`MapFallbackToPage("/_Host")`](xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A) is called to set up the root page of the app (`Pages/_Host.cshtml`) and enable navigation.

Additional files and folders may appear in an app produced from a Blazor Server project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

## Blazor WebAssembly

Blazor WebAssembly project template: `blazorwasm`

The Blazor WebAssembly template creates the initial files and directory structure for a Blazor WebAssembly app. The app is populated with demonstration code for a `FetchData` component that loads data from a static asset, `weather.json`, and user interaction with a `Counter` component.

* `Pages` folder: Contains the routable components/pages (`.razor`) that make up the Blazor app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following components:
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.
  
* `Properties/launchSettings.json`: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson).

* `Shared` folder: Contains the following shared components and stylesheets:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot`: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets, including `appsettings.json` and environmental app settings files for [configuration settings](xref:blazor/fundamentals/configuration). The `index.html` webpage is the root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The component is rendered at the location of the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>`).

> [!NOTE]
> JavaScript (JS) files added to the `wwwroot/index.html` file should appear before the closing `</body>` tag. The order that custom JS code is loaded from JS files is important in some scenarios. For example, ensure that JS files with interop methods are included before Blazor framework JS files.

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `Program.cs`: The app's entry point that sets up the WebAssembly host:
  
  * The `App` component is the root component of the app. The `App` component is specified as the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>` in `wwwroot/index.html`) to the root component collection (`builder.RootComponents.Add<App>("#app")`).
  * [Services](xref:blazor/fundamentals/dependency-injection) are added and configured (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>()`).

Additional files and folders may appear in an app produced from a Blazor WebAssembly project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

## Additional resources

* <xref:blazor/tooling>
* <xref:blazor/hosting-models>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

## Blazor Server

Blazor Server project template: `blazorserver`

The Blazor Server template creates the initial files and directory structure for a Blazor Server app. The app is populated with demonstration code for a `FetchData` component that loads data from a registered service, `WeatherForecastService`, and user interaction with a `Counter` component.

* `Data` folder: Contains the `WeatherForecast` class and implementation of the `WeatherForecastService` that provides example weather data to the app's `FetchData` component.

* `Pages` folder: Contains the routable components/pages (`.razor`) that make up the Blazor app and the root Razor page of a Blazor Server app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following:
  * `_Host.cshtml`: The root page of the app implemented as a Razor Page:
    * When any page of the app is initially requested, this page is rendered and returned in the response.
    * The Host page specifies where the root `App` component (`App.razor`) is rendered.
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `Error` component (`Error.razor`): Rendered when an unhandled exception occurs in the app.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.

> [!NOTE]
> JavaScript (JS) files added to the `Pages/_Host.cshtml` file should appear before the closing `</body>` tag. The order that custom JS code is loaded from JS files is important in some scenarios. For example, ensure that JS files with interop methods are included before Blazor framework JS files.

* `Properties/launchSettings.json`: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson).

* `Shared` folder: Contains the following shared components:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot`: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets.

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `appsettings.json` and environmental app settings files: Provide [configuration settings](xref:blazor/fundamentals/configuration) for the app.

* `Program.cs`: The app's entry point that sets up the ASP.NET Core [host](xref:fundamentals/host/generic-host).

* `Startup.cs`: Contains the app's startup logic. The `Startup` class defines two methods:

  * `ConfigureServices`: Configures the app's [dependency injection (DI)](xref:fundamentals/dependency-injection) services. Services are added by calling <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>, and the `WeatherForecastService` is added to the service container for use by the example `FetchData` component.
  * `Configure`: Configures the app's request handling pipeline:
    * <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> is called to set up an endpoint for the real-time connection with the browser. The connection is created with [SignalR](xref:signalr/introduction), which is a framework for adding real-time web functionality to apps.
    * [`MapFallbackToPage("/_Host")`](xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A) is called to set up the root page of the app (`Pages/_Host.cshtml`) and enable navigation.

Additional files and folders may appear in an app produced from a Blazor Server project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

## Blazor WebAssembly

Blazor WebAssembly project template: `blazorwasm`

The Blazor WebAssembly template creates the initial files and directory structure for a Blazor WebAssembly app. The app is populated with demonstration code for a `FetchData` component that loads data from a static asset, `weather.json`, and user interaction with a `Counter` component.

* `Pages` folder: Contains the routable components/pages (`.razor`) that make up the Blazor app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following components:
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.
  
* `Properties/launchSettings.json`: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson).

* `Shared` folder: Contains the following shared components:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot`: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets, including `appsettings.json` and environmental app settings files for [configuration settings](xref:blazor/fundamentals/configuration). The `index.html` webpage is the root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The component is rendered at the location of the `app` DOM element (`<app>Loading...</app>`).

> [!NOTE]
> JavaScript (JS) files added to the `wwwroot/index.html` file should appear before the closing `</body>` tag. The order that custom JS code is loaded from JS files is important in some scenarios. For example, ensure that JS files with interop methods are included before Blazor framework JS files.

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `Program.cs`: The app's entry point that sets up the WebAssembly host:

  * The `App` component is the root component of the app. The `App` component is specified as the `app` DOM element (`<app>Loading...</app>` in `wwwroot/index.html`) to the root component collection (`builder.RootComponents.Add<App>("app")`).
  * [Services](xref:blazor/fundamentals/dependency-injection) are added and configured (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>()`).

Additional files and folders may appear in an app produced from a Blazor WebAssembly project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

## Additional resources

* <xref:blazor/tooling>
* <xref:blazor/hosting-models>

:::moniker-end
