---
title: ASP.NET Core Blazor project structure
author: guardrex
description: Learn about ASP.NET Core Blazor app project structure.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/project-structure
---
# ASP.NET Core Blazor project structure

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes the files and folders that make up a Blazor app generated from a Blazor project template.

:::moniker range=">= aspnetcore-8.0"

## Blazor Web App

Blazor Web App project template: `blazor`

The Blazor Web App project template provides a single starting point for using Razor components to build any style of web UI, both server-side rendered and client-side rendered. It combines the strengths of the existing Blazor Server and Blazor WebAssembly hosting models with server-side rendering, streaming rendering, enhanced navigation and form handling, and the ability to add interactivity using either Blazor Server or Blazor WebAssembly on a per-component basis.

If both the WebAssembly and Server render modes are selected on app creation, the project template uses the Auto render mode. The automatic rendering mode initially uses the Server render mode while the .NET app bundle and runtime are download to the browser. After the .NET WebAssembly runtime is activated, automatic render mode (Auto) switches to the WebAssembly render mode.

By default, the Blazor Web App template enables both Static and Interactive Server rendering using a single project. If you also enable Interactive WebAssembly rendering, the project includes an additional client project (`.Client`) for your WebAssembly-based components. The built output from the client project is downloaded to the browser and executed on the client. Any components using the WebAssembly or Auto render modes must be built from the client project.

For more information, see <xref:blazor/components/render-modes>.

* Server project:

  * `Components` folder: 

    * `Layout` folder: Contains the following layout components and stylesheets:
      * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
      * `MainLayout.razor.css`: Stylesheet for the app's main layout.
      * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component indicates to the user which component is currently displayed.
      * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.

    * `Pages` folder: Contains the app's routable server-side Razor components (`.razor`). The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following:
      * `Counter` component (`Counter.razor`): Implements the *Counter* page.
      * `Error` component (`Error.razor`): Implements the *Error* page.
      * `Home` component (`Home.razor`): Implements the *Home* page.
      * `Weather` component (`Weather.razor`): Implements the *Weather forecast* page.

    * `App` component (`App.razor`): The root component of the app with HTML `<head>` markup, the `Routes` component, and the Blazor `<script>` tag.

    * `Routes` component (`Routes.razor`): Sets up routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. For client-side interactive components, the <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

    * `_Imports.razor`: Includes common Razor directives to include in the server-rendered app components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

  * `Properties` folder: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson) in the `launchSettings.json` file.

    > [!NOTE]
    > The `http` profile precedes the `https` profile in the `launchSettings.json` file. When an app is run with the .NET CLI, the app runs at an HTTP endpoint because the first profile found is `http`. The profile order eases the transition of adopting HTTPS for Linux and macOS users. If you prefer to start the app with the .NET CLI without having to pass the `-lp https` or `--launch-profile https` option to the `dotnet run` command, simply place the `https` profile above the `http` profile in the file.

  * `wwwroot` folder: The [Web Root](xref:fundamentals/index#web-root) folder for the server project containing the app's public static assets.

  * `Program.cs` file: The server project's entry point that sets up the ASP.NET Core web application [host](xref:fundamentals/host/generic-host#host-definition) and contains the app's startup logic, including service registrations, configuration, logging, and request processing pipeline.
    * Services for Razor components are added by calling <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>. `AddInteractiveServerComponents` adds services to support rendering Interactive Server components. `AddInteractiveWebAssemblyComponents` adds services to support rendering Interactive WebAssembly components.
    * <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> discovers available components and specifies the root component for the app, which by default is the `App` component (`App.razor`). `AddInteractiveServerRenderMode` configures the Server render mode for the app. `AddInteractiveWebAssemblyRenderMode` configures the WebAssembly render mode for the app.

  * App settings files (`appsettings.Development.json`, `appsettings.json`): Provide [configuration settings](xref:blazor/fundamentals/configuration) for the server project.

* Client project (`.Client`):

  * `Pages` folder: Contains the app's routable client-side Razor components (`.razor`). The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes `Counter` component (`Counter.razor`) that implements the *Counter* page.
  
  * The [Web Root](xref:fundamentals/index#web-root) folder for the client-side project containing the app's public static assets, including app settings files (`appsettings.Development.json`, `appsettings.json`) that provide [configuration settings](xref:blazor/fundamentals/configuration) for the client-side project.

  * `Program.cs` file: The client-side project's entry point that sets up the WebAssembly [host](xref:fundamentals/host/generic-host#host-definition) and contains the project's startup logic, including service registrations, configuration, logging, and request processing pipeline.

  * `_Imports.razor`: Includes common Razor directives to include in the WebAssembly-rendered app components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

Additional files and folders may appear in an app produced from a Blazor Web App project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

## Blazor Server

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

Blazor Server project templates: `blazorserver`, `blazorserver-empty`

The Blazor Server templates create the initial files and directory structure for a Blazor Server app:

* If the `blazorserver` template is used, the app is populated with the following:
  * Demonstration code for a `FetchData` component that loads data from a weather forecast service (`WeatherForecastService`) and user interaction with a `Counter` component.
  * [Bootstrap](https://getbootstrap.com/) frontend toolkit.
* If the `blazorserver-empty` template is used, the app is created without demonstration code and Bootstrap.

Project structure:

* `Data` folder: Contains the `WeatherForecast` class and implementation of the `WeatherForecastService` that provides example weather data to the app's `FetchData` component.

* `Pages` folder: Contains the Blazor app's routable Razor components (`.razor`) and the root Razor page of a Blazor Server app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following:
  * `_Host.cshtml`: The root page of the app implemented as a Razor Page:
    * When any page of the app is initially requested, this page is rendered and returned in the response.
    * The Host page specifies where the root `App` component (`App.razor`) is rendered.
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `Error` component (`Error.razor`): Rendered when an unhandled exception occurs in the app.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.

* `Properties` folder: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson) in the `launchSettings.json` file.

* `Shared` folder: Contains the following shared components and stylesheets:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot` folder: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets.

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `appsettings.json` and environmental app settings files: Provide [configuration settings](xref:blazor/fundamentals/configuration) for the app.

* `Program.cs`: The app's entry point that sets up the ASP.NET Core [host](xref:fundamentals/host/generic-host) and contains the app's startup logic, including service registrations and request processing pipeline configuration:

  * Specifies the app's [dependency injection (DI)](xref:fundamentals/dependency-injection) services. Services are added by calling <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>, and the `WeatherForecastService` is added to the service container for use by the example `FetchData` component.
  * Configures the app's request handling pipeline:
    * <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> is called to set up an endpoint for the real-time connection with the browser. The connection is created with [SignalR](xref:signalr/introduction), which is a framework for adding real-time web functionality to apps.
    * [`MapFallbackToPage("/_Host")`](xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A) is called to set up the root page of the app (`Pages/_Host.cshtml`) and enable navigation.

Additional files and folders may appear in an app produced from a Blazor Server project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

Blazor Server project template: `blazorserver`

The Blazor Server template creates the initial files and directory structure for a Blazor Server app. The app is populated with demonstration code for a `FetchData` component that loads data from a registered service, `WeatherForecastService`, and user interaction with a `Counter` component.

* `Data` folder: Contains the `WeatherForecast` class and implementation of the `WeatherForecastService` that provides example weather data to the app's `FetchData` component.

* `Pages` folder: Contains the Blazor app's routable Razor components (`.razor`) and the root Razor page of a Blazor Server app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following:
  * `_Host.cshtml`: The root page of the app implemented as a Razor Page:
    * When any page of the app is initially requested, this page is rendered and returned in the response.
    * The Host page specifies where the root `App` component (`App.razor`) is rendered.
  * `_Layout.cshtml`: The layout page for the `_Host.cshtml` root page of the app.
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `Error` component (`Error.razor`): Rendered when an unhandled exception occurs in the app.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.

* `Properties` folder: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson) in the `launchSettings.json` file.

* `Shared` folder: Contains the following shared components and stylesheets:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot` folder: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets.

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `appsettings.json` and environmental app settings files: Provide [configuration settings](xref:blazor/fundamentals/configuration) for the app.

* `Program.cs`: The app's entry point that sets up the ASP.NET Core [host](xref:fundamentals/host/generic-host) and contains the app's startup logic, including service registrations and request processing pipeline configuration:

  * Specifies the app's [dependency injection (DI)](xref:fundamentals/dependency-injection) services. Services are added by calling <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>, and the `WeatherForecastService` is added to the service container for use by the example `FetchData` component.
  * Configures the app's request handling pipeline:
    * <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> is called to set up an endpoint for the real-time connection with the browser. The connection is created with [SignalR](xref:signalr/introduction), which is a framework for adding real-time web functionality to apps.
    * [`MapFallbackToPage("/_Host")`](xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A) is called to set up the root page of the app (`Pages/_Host.cshtml`) and enable navigation.

Additional files and folders may appear in an app produced from a Blazor Server project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Blazor Server project template: `blazorserver`

The Blazor Server template creates the initial files and directory structure for a Blazor Server app. The app is populated with demonstration code for a `FetchData` component that loads data from a registered service, `WeatherForecastService`, and user interaction with a `Counter` component.

* `Data` folder: Contains the `WeatherForecast` class and implementation of the `WeatherForecastService` that provides example weather data to the app's `FetchData` component.

* `Pages` folder: Contains the Blazor app's routable Razor components (`.razor`) and the root Razor page of a Blazor Server app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following:
  * `_Host.cshtml`: The root page of the app implemented as a Razor Page:
    * When any page of the app is initially requested, this page is rendered and returned in the response.
    * The Host page specifies where the root `App` component (`App.razor`) is rendered.
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `Error` component (`Error.razor`): Rendered when an unhandled exception occurs in the app.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.

* `Properties` folder: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson) in the `launchSettings.json` file.

* `Shared` folder: Contains the following shared components and stylesheets:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot` folder: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets.

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

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Blazor Server project template: `blazorserver`

The Blazor Server template creates the initial files and directory structure for a Blazor Server app. The app is populated with demonstration code for a `FetchData` component that loads data from a registered service, `WeatherForecastService`, and user interaction with a `Counter` component.

* `Data` folder: Contains the `WeatherForecast` class and implementation of the `WeatherForecastService` that provides example weather data to the app's `FetchData` component.

* `Pages` folder: Contains the Blazor app's routable Razor components (`.razor`) and the root Razor page of a Blazor Server app. The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following:
  * `_Host.cshtml`: The root page of the app implemented as a Razor Page:
    * When any page of the app is initially requested, this page is rendered and returned in the response.
    * The Host page specifies where the root `App` component (`App.razor`) is rendered.
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `Error` component (`Error.razor`): Rendered when an unhandled exception occurs in the app.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.

* `Properties` folder: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson) in the `launchSettings.json` file.

* `Shared` folder: Contains the following shared components:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot` folder: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets.

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

:::moniker-end

## Blazor WebAssembly

:::moniker range=">= aspnetcore-8.0"

Blazor WebAssembly project templates: `blazorwasm`

The Blazor WebAssembly templates create the initial files and directory structure for a standalone Blazor WebAssembly app:

* If the `blazorwasm` template is used, the app is populated with the following:
  * Demonstration code for a `Weather` component that loads data from a static asset (`weather.json`) and user interaction with a `Counter` component.
  * [Bootstrap](https://getbootstrap.com/) frontend toolkit.
* If the `blazorwasm` template can also be generated without sample pages and styling.

Project structure:

* `Components` folder:

  * `Layout` folder: Contains the following layout components and stylesheets:
    * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
    * `MainLayout.razor.css`: Stylesheet for the app's main layout.
    * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
    * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.

  * `Pages` folder: Contains the Blazor app's routable Razor components (`.razor`). The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following components:
    * `Counter` component (`Counter.razor`): Implements the Counter page.
    * `Index` component (`Index.razor`): Implements the Home page.
    * `Weather` component (`Weather.razor`): Implements the Weather page.

  * `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

  * `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.
  
* `Properties` folder: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson) in the `launchSettings.json` file.

  > [!NOTE]
  > The `http` profile precedes the `https` profile in the `launchSettings.json` file. When an app is run with the .NET CLI, the app runs at an HTTP endpoint because the first profile found is `http`. The profile order eases the transition of adopting HTTPS for Linux and macOS users. If you prefer to start the app with the .NET CLI without having to pass the `-lp https` or `--launch-profile https` option to the `dotnet run` command, simply place the `https` profile above the `http` profile in the file.

* `wwwroot` folder: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets, including `appsettings.json` and environmental app settings files for [configuration settings](xref:blazor/fundamentals/configuration) and sample weather data (`sample-data/weather.json`). The `index.html` webpage is the root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The component is rendered at the location of the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>`).

* `Program.cs`: The app's entry point that sets up the WebAssembly host:
  
  * The `App` component is the root component of the app. The `App` component is specified as the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>` in `wwwroot/index.html`) to the root component collection (`builder.RootComponents.Add<App>("#app")`).
  * [Services](xref:blazor/fundamentals/dependency-injection) are added and configured (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>()`).

Additional files and folders may appear in an app produced from a Blazor WebAssembly project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

Blazor WebAssembly project templates: `blazorwasm`, `blazorwasm-empty`

The Blazor WebAssembly templates create the initial files and directory structure for a Blazor WebAssembly app:

* If the `blazorwasm` template is used, the app is populated with the following:
  * Demonstration code for a `FetchData` component that loads data from a static asset (`weather.json`) and user interaction with a `Counter` component.
  * [Bootstrap](https://getbootstrap.com/) frontend toolkit.
* If the `blazorwasm-empty` template is used, the app is created without demonstration code and Bootstrap.

Project structure:

* `Pages` folder: Contains the Blazor app's routable Razor components (`.razor`). The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following components:
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.
  
* `Properties` folder: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson) in the `launchSettings.json` file.

* `Shared` folder: Contains the following shared components and stylesheets:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.
  * `SurveyPrompt` component (`SurveyPrompt.razor`) (*ASP.NET Core 7.0 or earlier*): Blazor survey component.

* `wwwroot` folder: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets, including `appsettings.json` and environmental app settings files for [configuration settings](xref:blazor/fundamentals/configuration). The `index.html` webpage is the root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The component is rendered at the location of the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>`).

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `Program.cs`: The app's entry point that sets up the WebAssembly host:
  
  * The `App` component is the root component of the app. The `App` component is specified as the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>` in `wwwroot/index.html`) to the root component collection (`builder.RootComponents.Add<App>("#app")`).
  * [Services](xref:blazor/fundamentals/dependency-injection) are added and configured (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>()`).

Additional files and folders may appear in an app produced from a Blazor WebAssembly project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

A *hosted Blazor WebAssembly solution* includes the following ASP.NET Core projects:

* ":::no-loc text="Client":::": The Blazor WebAssembly app.
* ":::no-loc text="Server":::": An app that serves the Blazor WebAssembly app and weather data to clients.
* ":::no-loc text="Shared":::": A project that maintains common classes, methods, and resources.

The solution is generated from the Blazor WebAssembly project template in Visual Studio with the **ASP.NET Core Hosted** checkbox selected or with the `-ho|--hosted` option using the .NET CLI's `dotnet new blazorwasm` command. For more information, see <xref:blazor/tooling>.

The project structure of the client-side app in a hosted Blazor Webassembly solution (":::no-loc text="Client":::" project) is the same as the project structure for a standalone Blazor WebAssembly app. Additional files in a hosted Blazor WebAssembly solution:

* The ":::no-loc text="Server":::" project includes a weather forecast controller at `Controllers/WeatherForecastController.cs` that returns weather data to the ":::no-loc text="Client":::" project's `FetchData` component.
* The ":::no-loc text="Shared":::" project includes a weather forecast class at `WeatherForecast.cs` that represents weather data for the ":::no-loc text="Client":::" and ":::no-loc text="Server":::" projects.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

Blazor WebAssembly project template: `blazorwasm`

The Blazor WebAssembly template creates the initial files and directory structure for a Blazor WebAssembly app. The app is populated with demonstration code for a `FetchData` component that loads data from a static asset, `weather.json`, and user interaction with a `Counter` component.

* `Pages` folder: Contains the Blazor app's routable Razor components (`.razor`). The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following components:
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.
  
* `Properties` folder: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson) in the `launchSettings.json` file.

* `Shared` folder: Contains the following shared components and stylesheets:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot` folder: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets, including `appsettings.json` and environmental app settings files for [configuration settings](xref:blazor/fundamentals/configuration). The `index.html` webpage is the root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The component is rendered at the location of the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>`).

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `Program.cs`: The app's entry point that sets up the WebAssembly host:
  
  * The `App` component is the root component of the app. The `App` component is specified as the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>` in `wwwroot/index.html`) to the root component collection (`builder.RootComponents.Add<App>("#app")`).
  * [Services](xref:blazor/fundamentals/dependency-injection) are added and configured (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>()`).

Additional files and folders may appear in an app produced from a Blazor WebAssembly project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

A *hosted Blazor WebAssembly solution* includes the following ASP.NET Core projects:

* ":::no-loc text="Client":::": The Blazor WebAssembly app.
* ":::no-loc text="Server":::": An app that serves the Blazor WebAssembly app and weather data to clients.
* ":::no-loc text="Shared":::": A project that maintains common classes, methods, and resources.

The solution is generated from the Blazor WebAssembly project template in Visual Studio with the **ASP.NET Core Hosted** checkbox selected or with the `-ho|--hosted` option using the .NET CLI's `dotnet new blazorwasm` command. For more information, see <xref:blazor/tooling>.

The project structure of the client-side app in a hosted Blazor Webassembly solution (":::no-loc text="Client":::" project) is the same as the project structure for a standalone Blazor WebAssembly app. Additional files in a hosted Blazor WebAssembly solution:

* The ":::no-loc text="Server":::" project includes a weather forecast controller at `Controllers/WeatherForecastController.cs` that returns weather data to the ":::no-loc text="Client":::" project's `FetchData` component.
* The ":::no-loc text="Shared":::" project includes a weather forecast class at `WeatherForecast.cs` that represents weather data for the ":::no-loc text="Client":::" and ":::no-loc text="Server":::" projects.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Blazor WebAssembly project template: `blazorwasm`

The Blazor WebAssembly template creates the initial files and directory structure for a Blazor WebAssembly app. The app is populated with demonstration code for a `FetchData` component that loads data from a static asset, `weather.json`, and user interaction with a `Counter` component.

* `Pages` folder: Contains the Blazor app's routable Razor components (`.razor`). The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following components:
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.
  
* `Properties` folder: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson) in the `launchSettings.json` file.

* `Shared` folder: Contains the following shared components and stylesheets:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `MainLayout.razor.css`: Stylesheet for the app's main layout.
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `NavMenu.razor.css`: Stylesheet for the app's navigation menu.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot` folder: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets, including `appsettings.json` and environmental app settings files for [configuration settings](xref:blazor/fundamentals/configuration). The `index.html` webpage is the root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The component is rendered at the location of the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>`).

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `Program.cs`: The app's entry point that sets up the WebAssembly host:
  
  * The `App` component is the root component of the app. The `App` component is specified as the `div` DOM element with an `id` of `app` (`<div id="app">Loading...</div>` in `wwwroot/index.html`) to the root component collection (`builder.RootComponents.Add<App>("#app")`).
  * [Services](xref:blazor/fundamentals/dependency-injection) are added and configured (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>()`).

Additional files and folders may appear in an app produced from a Blazor WebAssembly project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

A *hosted Blazor WebAssembly solution* includes the following ASP.NET Core projects:

* ":::no-loc text="Client":::": The Blazor WebAssembly app.
* ":::no-loc text="Server":::": An app that serves the Blazor WebAssembly app and weather data to clients.
* ":::no-loc text="Shared":::": A project that maintains common classes, methods, and resources.

The solution is generated from the Blazor WebAssembly project template in Visual Studio with the **ASP.NET Core Hosted** checkbox selected or with the `-ho|--hosted` option using the .NET CLI's `dotnet new blazorwasm` command. For more information, see <xref:blazor/tooling>.

The project structure of the client-side app in a hosted Blazor Webassembly solution (":::no-loc text="Client":::" project) is the same as the project structure for a standalone Blazor WebAssembly app. Additional files in a hosted Blazor WebAssembly solution:

* The ":::no-loc text="Server":::" project includes a weather forecast controller at `Controllers/WeatherForecastController.cs` that returns weather data to the ":::no-loc text="Client":::" project's `FetchData` component.
* The ":::no-loc text="Shared":::" project includes a weather forecast class at `WeatherForecast.cs` that represents weather data for the ":::no-loc text="Client":::" and ":::no-loc text="Server":::" projects.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Blazor WebAssembly project template: `blazorwasm`

The Blazor WebAssembly template creates the initial files and directory structure for a Blazor WebAssembly app. The app is populated with demonstration code for a `FetchData` component that loads data from a static asset, `weather.json`, and user interaction with a `Counter` component.

* `Pages` folder: Contains the Blazor app's routable Razor components (`.razor`). The route for each page is specified using the [`@page`](xref:mvc/views/razor#page) directive. The template includes the following components:
  * `Counter` component (`Counter.razor`): Implements the Counter page.
  * `FetchData` component (`FetchData.razor`): Implements the Fetch data page.
  * `Index` component (`Index.razor`): Implements the Home page.
  
* `Properties` folder: Holds [development environment configuration](xref:fundamentals/environments#development-and-launchsettingsjson) in the `launchSettings.json` file.

* `Shared` folder: Contains the following shared components:
  * `MainLayout` component (`MainLayout.razor`): The app's [layout component](xref:blazor/components/layouts).
  * `NavMenu` component (`NavMenu.razor`): Implements sidebar navigation. Includes the [`NavLink` component](xref:blazor/fundamentals/routing#navlink-and-navmenu-components) (<xref:Microsoft.AspNetCore.Components.Routing.NavLink>), which renders navigation links to other Razor components. The <xref:Microsoft.AspNetCore.Components.Routing.NavLink> component automatically indicates a selected state when its component is loaded, which helps the user understand which component is currently displayed.
  * `SurveyPrompt` component (`SurveyPrompt.razor`): Blazor survey component.

* `wwwroot` folder: The [Web Root](xref:fundamentals/index#web-root) folder for the app containing the app's public static assets, including `appsettings.json` and environmental app settings files for [configuration settings](xref:blazor/fundamentals/configuration). The `index.html` webpage is the root page of the app implemented as an HTML page:
  * When any page of the app is initially requested, this page is rendered and returned in the response.
  * The page specifies where the root `App` component is rendered. The component is rendered at the location of the `app` DOM element (`<app>Loading...</app>`).

* `_Imports.razor`: Includes common Razor directives to include in the app's components (`.razor`), such as [`@using`](xref:mvc/views/razor#using) directives for namespaces.

* `App.razor`: The root component of the app that sets up client-side routing using the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component intercepts browser navigation and renders the page that matches the requested address.

* `Program.cs`: The app's entry point that sets up the WebAssembly host:

  * The `App` component is the root component of the app. The `App` component is specified as the `app` DOM element (`<app>Loading...</app>` in `wwwroot/index.html`) to the root component collection (`builder.RootComponents.Add<App>("app")`).
  * [Services](xref:blazor/fundamentals/dependency-injection) are added and configured (for example, `builder.Services.AddSingleton<IMyDependency, MyDependency>()`).

Additional files and folders may appear in an app produced from a Blazor WebAssembly project template when additional options are configured. For example, generating an app with ASP.NET Core Identity includes additional assets for authentication and authorization features.

A *hosted Blazor WebAssembly solution* includes the following ASP.NET Core projects:

* ":::no-loc text="Client":::": The Blazor WebAssembly app.
* ":::no-loc text="Server":::": An app that serves the Blazor WebAssembly app and weather data to clients.
* ":::no-loc text="Shared":::": A project that maintains common classes, methods, and resources.

The solution is generated from the Blazor WebAssembly project template in Visual Studio with the **ASP.NET Core Hosted** checkbox selected or with the `-ho|--hosted` option using the .NET CLI's `dotnet new blazorwasm` command. For more information, see <xref:blazor/tooling>.

The project structure of the client-side app in a hosted Blazor Webassembly solution (":::no-loc text="Client":::" project) is the same as the project structure for a standalone Blazor WebAssembly app. Additional files in a hosted Blazor WebAssembly solution:

* The ":::no-loc text="Server":::" project includes a weather forecast controller at `Controllers/WeatherForecastController.cs` that returns weather data to the ":::no-loc text="Client":::" project's `FetchData` component.
* The ":::no-loc text="Shared":::" project includes a weather forecast class at `WeatherForecast.cs` that represents weather data for the ":::no-loc text="Client":::" and ":::no-loc text="Server":::" projects.

:::moniker-end

## Location of the Blazor script

The Blazor script is served from an embedded resource in the ASP.NET Core shared framework.

:::moniker range=">= aspnetcore-8.0"

In a Blazor Web App, the Blazor script is located in the `Components/App.razor` file:

```
<script src="_framework/blazor.web.js"></script>
```

In a Blazor Server app, the Blazor script is located in the `Pages/_Host.cshtml` file:

```
<script src="_framework/blazor.server.js"></script>
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

In a Blazor Server app, the Blazor script is located in the `Pages/_Host.cshtml` file:

```
<script src="_framework/blazor.server.js"></script>
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

In a Blazor Server app, the Blazor script is located in the `Pages/_Layout.cshtml` file:

```
<script src="_framework/blazor.server.js"></script>
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In a Blazor Server app, the Blazor script is located in the `Pages/_Host.cshtml` file:

```
<script src="_framework/blazor.server.js"></script>
```

:::moniker-end

In a Blazor WebAssembly app, the Blazor script content is located in the `wwwroot/index.html` file:

```
<script src="_framework/blazor.webassembly.js"></script>
```

## Location of `<head>` and `<body>` content

:::moniker range=">= aspnetcore-8.0"

In a Blazor Web App, `<head>` and `<body>` content is located in the `Components/App.razor` file.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

In a Blazor Server app, `<head>` and `<body>` content is located in the `Pages/_Host.cshtml` file.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

In a Blazor Server app, `<head>` and `<body>` content is located in the `Pages/_Layout.cshtml` file.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In a Blazor Server app, `<head>` and `<body>` content is located in the `Pages/_Host.cshtml` file.

:::moniker-end

In a Blazor WebAssembly app, `<head>` and `<body>` content is located in the `wwwroot/index.html` file.

:::moniker range="< aspnetcore-8.0"

## Dual Blazor Server/Blazor WebAssembly app

To create an app that can run as either a Blazor Server app or a Blazor WebAssembly app, one approach is to place all of the app logic and components into a [Razor class library (RCL)](xref:blazor/components/class-libraries) and reference the RCL from separate Blazor Server and Blazor WebAssembly projects. For common services whose implementations differ based on the hosting model, define the service interfaces in the RCL and implement the services in the Blazor Server and Blazor WebAssembly projects.

:::moniker-end

## Additional resources

:::moniker range=">= aspnetcore-7.0"

* <xref:blazor/tooling>
* <xref:blazor/hosting-models>
* <xref:fundamentals/minimal-apis>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end

:::moniker range="< aspnetcore-7.0"

* <xref:blazor/tooling>
* <xref:blazor/hosting-models>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end
