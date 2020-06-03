---
title: Host and deploy ASP.NET Core Blazor
author: guardrex
description: Discover how to host and deploy Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/19/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: host-and-deploy/blazor/index
---
# Host and deploy ASP.NET Core Blazor

By [Luke Latham](https://github.com/guardrex), [Rainer Stropek](https://www.timecockpit.com), and [Daniel Roth](https://github.com/danroth27)

## Publish the app

Apps are published for deployment in Release configuration.

# [Visual Studio](#tab/visual-studio)

1. Select **Build** > **Publish {APPLICATION}** from the navigation bar.
1. Select the *publish target*. To publish locally, select **Folder**.
1. Accept the default location in the **Choose a folder** field or specify a different location. Select the **Publish** button.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Select **Build** > **Publish to Folder**.
1. Confirm the folder to receive the published assets and select **Publish**.

# [.NET Core CLI](#tab/netcore-cli)

Use the [dotnet publish](/dotnet/core/tools/dotnet-publish) command to publish the app with a Release configuration:

```dotnetcli
dotnet publish -c Release
```

---

Publishing the app triggers a [restore](/dotnet/core/tools/dotnet-restore) of the project's dependencies and [builds](/dotnet/core/tools/dotnet-build) the project before creating the assets for deployment. As part of the build process, unused methods and assemblies are removed to reduce app download size and load times.

Publish locations:

* Blazor WebAssembly
  * Standalone: The app is published into the */bin/Release/{TARGET FRAMEWORK}/publish/wwwroot* folder. To deploy the app as a static site, copy the contents of the *wwwroot* folder to the static site host.
  * Hosted: The client Blazor WebAssembly app is published into the */bin/Release/{TARGET FRAMEWORK}/publish/wwwroot* folder of the server app, along with any other static web assets of the server app. Deploy the contents of the *publish* folder to the host.
* Blazor Server: The app is published into the */bin/Release/{TARGET FRAMEWORK}/publish* folder. Deploy the contents of the *publish* folder to the host.

The assets in the folder are deployed to the web server. Deployment might be a manual or automated process depending on the development tools in use.

## App base path

The *app base path* is the app's root URL path. Consider the following ASP.NET Core app and Blazor sub-app:

* The ASP.NET Core app is named `MyApp`:
  * The app physically resides at *d:/MyApp*.
  * Requests are received at `https://www.contoso.com/{MYAPP RESOURCE}`.
* A Blazor app named `CoolApp` is a sub-app of `MyApp`:
  * The sub-app physically resides at *d:/MyApp/CoolApp*.
  * Requests are received at `https://www.contoso.com/CoolApp/{COOLAPP RESOURCE}`.

Without specifying additional configuration for `CoolApp`, the sub-app in this scenario has no knowledge of where it resides on the server. For example, the app can't construct correct relative URLs to its resources without knowing that it resides at the relative URL path `/CoolApp/`.

To provide configuration for the Blazor app's base path of `https://www.contoso.com/CoolApp/`, the `<base>` tag's `href` attribute is set to the relative root path in the *Pages/_Host.cshtml* file (Blazor Server) or *wwwroot/index.html* file (Blazor WebAssembly):

```html
<base href="/CoolApp/">
```

Blazor Server apps additionally set the server-side base path by calling <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase*> in the app's request pipeline of `Startup.Configure`:

```csharp
app.UsePathBase("/CoolApp");
```

By providing the relative URL path, a component that isn't in the root directory can construct URLs relative to the app's root path. Components at different levels of the directory structure can build links to other resources at locations throughout the app. The app base path is also used to intercept selected hyperlinks where the `href` target of the link is within the app base path URI space. The Blazor router handles the internal navigation.

In many hosting scenarios, the relative URL path to the app is the root of the app. In these cases, the app's relative URL base path is a forward slash (`<base href="/" />`), which is the default configuration for a Blazor app. In other hosting scenarios, such as GitHub Pages and IIS sub-apps, the app base path must be set to the server's relative URL path of the app.

To set the app's base path, update the `<base>` tag within the `<head>` tag elements of the *Pages/_Host.cshtml* file (Blazor Server) or *wwwroot/index.html* file (Blazor WebAssembly). Set the `href` attribute value to `/{RELATIVE URL PATH}/` (the trailing slash is required), where `{RELATIVE URL PATH}` is the app's full relative URL path.

For an Blazor WebAssembly app with a non-root relative URL path (for example, `<base href="/CoolApp/">`), the app fails to find its resources *when run locally*. To overcome this problem during local development and testing, you can supply a *path base* argument that matches the `href` value of the `<base>` tag at runtime. Don't include a trailing slash. To pass the path base argument when running the app locally, execute the `dotnet run` command from the app's directory with the `--pathbase` option:

```dotnetcli
dotnet run --pathbase=/{RELATIVE URL PATH (no trailing slash)}
```

For a Blazor WebAssembly app with a relative URL path of `/CoolApp/` (`<base href="/CoolApp/">`), the command is:

```dotnetcli
dotnet run --pathbase=/CoolApp
```

The Blazor WebAssembly app responds locally at `http://localhost:port/CoolApp`.

## Deployment

For deployment guidance, see the following topics:

* <xref:host-and-deploy/blazor/webassembly>
* <xref:host-and-deploy/blazor/server>
