---
title: Host and deploy ASP.NET Core Blazor
author: guardrex
description: Discover how to host and deploy Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 07/15/2020
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/host-and-deploy/index
---
# Host and deploy ASP.NET Core Blazor

::: moniker range=">= aspnetcore-6.0"

## Publish the app

Apps are published for deployment in Release configuration.

# [Visual Studio](#tab/visual-studio)

1. Select **Build** > **Publish {APPLICATION}** from the navigation bar.
1. Select the *publish target*. To publish locally, select **Folder**.
1. Accept the default location in the **Choose a folder** field or specify a different location. Select the **`Publish`** button.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Select **Build** > **Publish to Folder**.
1. Confirm the folder to receive the published assets and select **`Publish`**.

# [.NET Core CLI](#tab/netcore-cli)

Use the [`dotnet publish`](/dotnet/core/tools/dotnet-publish) command to publish the app with a Release configuration:

```dotnetcli
dotnet publish -c Release
```

---

Publishing the app triggers a [restore](/dotnet/core/tools/dotnet-restore) of the project's dependencies and [builds](/dotnet/core/tools/dotnet-build) the project before creating the assets for deployment. As part of the build process, unused methods and assemblies are removed to reduce app download size and load times.

Publish locations:

* Blazor WebAssembly
  * Standalone: The app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder. To deploy the app as a static site, copy the contents of the `wwwroot` folder to the static site host.
  * Hosted: The client Blazor WebAssembly app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder of the server app, along with any other static web assets of the server app. Deploy the contents of the `publish` folder to the host.
* Blazor Server: The app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish` folder. Deploy the contents of the `publish` folder to the host.

The assets in the folder are deployed to the web server. Deployment might be a manual or automated process depending on the development tools in use.

## App base path

The *app base path* is the app's root URL path. Consider the following ASP.NET Core app and Blazor sub-app:

* The ASP.NET Core app is named `MyApp`:
  * The app physically resides at `d:/MyApp`.
  * Requests are received at `https://www.contoso.com/{MYAPP RESOURCE}`.
* A Blazor app named `CoolApp` is a sub-app of `MyApp`:
  * The sub-app physically resides at `d:/MyApp/CoolApp`.
  * Requests are received at `https://www.contoso.com/CoolApp/{COOLAPP RESOURCE}`.

Without specifying additional configuration for `CoolApp`, the sub-app in this scenario has no knowledge of where it resides on the server. For example, the app can't construct correct relative URLs to its resources without knowing that it resides at the relative URL path `/CoolApp/`.

To provide configuration for the Blazor app's base path of `https://www.contoso.com/CoolApp/`, set the relative root path.

Blazor WebAssembly (`wwwroot/index.html`):

```html
<base href="/CoolApp/">
```

**The trailing slash is required.**

In a Blazor Server app, use ***either*** of the following approaches:

* Option 1: Use the `<base>` tag in `Pages/_Layout.cshtml` to set the app's base path:

  ```html
  <base href="/CoolApp/">
  ```
  
  **The trailing slash is required.**

* Option 2: Call <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A> in the app's request pipeline (`Program.cs`):

  ```csharp
  app.UsePathBase("/CoolApp");
  ```

By providing the relative URL path, a component that isn't in the root directory can construct URLs relative to the app's root path. Components at different levels of the directory structure can build links to other resources at locations throughout the app. The app base path is also used to intercept selected hyperlinks where the `href` target of the link is within the app base path URI space. The Blazor router handles the internal navigation.

In many hosting scenarios, the relative URL path to the app is the root of the app. In these cases, the app's relative URL base path is a forward slash (`<base href="/" />` for Blazor WebAssembly or `<base href="~/" />` for Blazor Server), which is the default configuration for a Blazor app. In other hosting scenarios, such as GitHub Pages and IIS sub-apps, the app base path must be set to the server's relative URL path of the app.

For a Blazor WebAssembly app with a non-root relative URL path (for example, `<base href="/CoolApp/">`), the app fails to find its resources *when run locally*. To overcome this problem during local development and testing, you can supply a *path base* argument that matches the `href` value of the `<base>` tag at runtime. **Don't include a trailing slash.** To pass the path base argument when running the app locally, execute the `dotnet run` command from the app's directory with the `--pathbase` option:

```dotnetcli
dotnet run --pathbase=/{RELATIVE URL PATH (no trailing slash)}
```

For a Blazor WebAssembly app with a relative URL path of `/CoolApp/` (`<base href="/CoolApp/">`), the command is:

```dotnetcli
dotnet run --pathbase=/CoolApp
```

The Blazor WebAssembly app responds locally at `http://localhost:port/CoolApp`.

<!-- HOLD

### Blazor Server `MapFallbackToPage` configuration

Pass the following path to <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> in `Program.cs`:

```csharp
app.MapFallbackToPage("/{RELATIVE PATH}/{**path:nonfile}");
```

The placeholder `{RELATIVE PATH}` is the non-root path on the server. For example, `CoolApp` is the placeholder segment if the non-root URL to the app is `https://{HOST}:{PORT}/CoolApp/`):

```csharp
app.MapFallbackToPage("/CoolApp/{**path:nonfile}");
```

-->

### Host multiple Blazor WebAssembly apps

For more information on hosting multiple Blazor WebAssembly apps in a hosted Blazor solution, see <xref:blazor/host-and-deploy/webassembly#hosted-deployment-with-multiple-blazor-webassembly-apps>.

## Deployment

For deployment guidance, see the following topics:

* <xref:blazor/host-and-deploy/webassembly>
* <xref:blazor/host-and-deploy/server>

::: moniker-end

::: moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

## Publish the app

Apps are published for deployment in Release configuration.

# [Visual Studio](#tab/visual-studio)

1. Select **Build** > **Publish {APPLICATION}** from the navigation bar.
1. Select the *publish target*. To publish locally, select **Folder**.
1. Accept the default location in the **Choose a folder** field or specify a different location. Select the **`Publish`** button.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Select **Build** > **Publish to Folder**.
1. Confirm the folder to receive the published assets and select **`Publish`**.

# [.NET Core CLI](#tab/netcore-cli)

Use the [`dotnet publish`](/dotnet/core/tools/dotnet-publish) command to publish the app with a Release configuration:

```dotnetcli
dotnet publish -c Release
```

---

Publishing the app triggers a [restore](/dotnet/core/tools/dotnet-restore) of the project's dependencies and [builds](/dotnet/core/tools/dotnet-build) the project before creating the assets for deployment. As part of the build process, unused methods and assemblies are removed to reduce app download size and load times.

Publish locations:

* Blazor WebAssembly
  * Standalone: The app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder. To deploy the app as a static site, copy the contents of the `wwwroot` folder to the static site host.
  * Hosted: The client Blazor WebAssembly app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder of the server app, along with any other static web assets of the server app. Deploy the contents of the `publish` folder to the host.
* Blazor Server: The app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish` folder. Deploy the contents of the `publish` folder to the host.

The assets in the folder are deployed to the web server. Deployment might be a manual or automated process depending on the development tools in use.

## App base path

The *app base path* is the app's root URL path. Consider the following ASP.NET Core app and Blazor sub-app:

* The ASP.NET Core app is named `MyApp`:
  * The app physically resides at `d:/MyApp`.
  * Requests are received at `https://www.contoso.com/{MYAPP RESOURCE}`.
* A Blazor app named `CoolApp` is a sub-app of `MyApp`:
  * The sub-app physically resides at `d:/MyApp/CoolApp`.
  * Requests are received at `https://www.contoso.com/CoolApp/{COOLAPP RESOURCE}`.

Without specifying additional configuration for `CoolApp`, the sub-app in this scenario has no knowledge of where it resides on the server. For example, the app can't construct correct relative URLs to its resources without knowing that it resides at the relative URL path `/CoolApp/`.

To provide configuration for the Blazor app's base path of `https://www.contoso.com/CoolApp/`, set the relative root path.

Blazor WebAssembly (`wwwroot/index.html`):

```html
<base href="/CoolApp/">
```

**The trailing slash is required.**

In a Blazor Server app, use ***either*** of the following approaches:

* Option 1: Use the `<base>` tag in `Pages/_Host.cshtml` to set the app's base path:

  ```html
  <base href="/CoolApp/">
  ```
  
  **The trailing slash is required.**

* Option 2: Call <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A> in the app's request pipeline (`Program.cs`):

  ```csharp
  app.UsePathBase("/CoolApp");
  ```

By providing the relative URL path, a component that isn't in the root directory can construct URLs relative to the app's root path. Components at different levels of the directory structure can build links to other resources at locations throughout the app. The app base path is also used to intercept selected hyperlinks where the `href` target of the link is within the app base path URI space. The Blazor router handles the internal navigation.

In many hosting scenarios, the relative URL path to the app is the root of the app. In these cases, the app's relative URL base path is a forward slash (`<base href="/" />` for Blazor WebAssembly or `<base href="~/" />` for Blazor Server), which is the default configuration for a Blazor app. In other hosting scenarios, such as GitHub Pages and IIS sub-apps, the app base path must be set to the server's relative URL path of the app.

For a Blazor WebAssembly app with a non-root relative URL path (for example, `<base href="/CoolApp/">`), the app fails to find its resources *when run locally*. To overcome this problem during local development and testing, you can supply a *path base* argument that matches the `href` value of the `<base>` tag at runtime. **Don't include a trailing slash.** To pass the path base argument when running the app locally, execute the `dotnet run` command from the app's directory with the `--pathbase` option:

```dotnetcli
dotnet run --pathbase=/{RELATIVE URL PATH (no trailing slash)}
```

For a Blazor WebAssembly app with a relative URL path of `/CoolApp/` (`<base href="/CoolApp/">`), the command is:

```dotnetcli
dotnet run --pathbase=/CoolApp
```

The Blazor WebAssembly app responds locally at `http://localhost:port/CoolApp`.

<!-- HOLD

### Blazor Server `MapFallbackToPage` configuration

Pass the following path to <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> in `Program.cs`:

```csharp
app.MapFallbackToPage("/{RELATIVE PATH}/{**path:nonfile}");
```

The placeholder `{RELATIVE PATH}` is the non-root path on the server. For example, `CoolApp` is the placeholder segment if the non-root URL to the app is `https://{HOST}:{PORT}/CoolApp/`):

```csharp
app.MapFallbackToPage("/CoolApp/{**path:nonfile}");
```

-->

### Host multiple Blazor WebAssembly apps

For more information on hosting multiple Blazor WebAssembly apps in a hosted Blazor solution, see <xref:blazor/host-and-deploy/webassembly#hosted-deployment-with-multiple-blazor-webassembly-apps>.

## Deployment

For deployment guidance, see the following topics:

* <xref:blazor/host-and-deploy/webassembly>
* <xref:blazor/host-and-deploy/server>

::: moniker-end

::: moniker range="< aspnetcore-5.0"

## Publish the app

Apps are published for deployment in Release configuration.

# [Visual Studio](#tab/visual-studio)

1. Select **Build** > **Publish {APPLICATION}** from the navigation bar.
1. Select the *publish target*. To publish locally, select **Folder**.
1. Accept the default location in the **Choose a folder** field or specify a different location. Select the **`Publish`** button.

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. Select **Build** > **Publish to Folder**.
1. Confirm the folder to receive the published assets and select **`Publish`**.

# [.NET Core CLI](#tab/netcore-cli)

Use the [`dotnet publish`](/dotnet/core/tools/dotnet-publish) command to publish the app with a Release configuration:

```dotnetcli
dotnet publish -c Release
```

---

Publishing the app triggers a [restore](/dotnet/core/tools/dotnet-restore) of the project's dependencies and [builds](/dotnet/core/tools/dotnet-build) the project before creating the assets for deployment. As part of the build process, unused methods and assemblies are removed to reduce app download size and load times.

Publish locations:

* Blazor WebAssembly
  * Standalone: The app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder. To deploy the app as a static site, copy the contents of the `wwwroot` folder to the static site host.
  * Hosted: The client Blazor WebAssembly app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish/wwwroot` folder of the server app, along with any other static web assets of the server app. Deploy the contents of the `publish` folder to the host.
* Blazor Server: The app is published into the `/bin/Release/{TARGET FRAMEWORK}/publish` folder. Deploy the contents of the `publish` folder to the host.

The assets in the folder are deployed to the web server. Deployment might be a manual or automated process depending on the development tools in use.

## App base path

The *app base path* is the app's root URL path. Consider the following ASP.NET Core app and Blazor sub-app:

* The ASP.NET Core app is named `MyApp`:
  * The app physically resides at `d:/MyApp`.
  * Requests are received at `https://www.contoso.com/{MYAPP RESOURCE}`.
* A Blazor app named `CoolApp` is a sub-app of `MyApp`:
  * The sub-app physically resides at `d:/MyApp/CoolApp`.
  * Requests are received at `https://www.contoso.com/CoolApp/{COOLAPP RESOURCE}`.

Without specifying additional configuration for `CoolApp`, the sub-app in this scenario has no knowledge of where it resides on the server. For example, the app can't construct correct relative URLs to its resources without knowing that it resides at the relative URL path `/CoolApp/`.

To provide configuration for the Blazor app's base path of `https://www.contoso.com/CoolApp/`, set the relative root path.

Blazor WebAssembly (`wwwroot/index.html`):

```html
<base href="/CoolApp/">
```

**The trailing slash is required.**

In a Blazor Server app, use ***either*** of the following approaches:

* Option 1: Use the `<base>` tag in `Pages/_Host.cshtml` to set the app's base path:

  ```html
  <base href="/CoolApp/">
  ```
  
  **The trailing slash is required.**

* Option 2: Call <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A> in the app's request pipeline (`Program.cs`):

  ```csharp
  app.UsePathBase("/CoolApp");
  ```

By providing the relative URL path, a component that isn't in the root directory can construct URLs relative to the app's root path. Components at different levels of the directory structure can build links to other resources at locations throughout the app. The app base path is also used to intercept selected hyperlinks where the `href` target of the link is within the app base path URI space. The Blazor router handles the internal navigation.

In many hosting scenarios, the relative URL path to the app is the root of the app. In these cases, the app's relative URL base path is a forward slash (`<base href="/" />` for Blazor WebAssembly or `<base href="~/" />` for Blazor Server), which is the default configuration for a Blazor app. In other hosting scenarios, such as GitHub Pages and IIS sub-apps, the app base path must be set to the server's relative URL path of the app.

For a Blazor WebAssembly app with a non-root relative URL path (for example, `<base href="/CoolApp/">`), the app fails to find its resources *when run locally*. To overcome this problem during local development and testing, you can supply a *path base* argument that matches the `href` value of the `<base>` tag at runtime. **Don't include a trailing slash.** To pass the path base argument when running the app locally, execute the `dotnet run` command from the app's directory with the `--pathbase` option:

```dotnetcli
dotnet run --pathbase=/{RELATIVE URL PATH (no trailing slash)}
```

For a Blazor WebAssembly app with a relative URL path of `/CoolApp/` (`<base href="/CoolApp/">`), the command is:

```dotnetcli
dotnet run --pathbase=/CoolApp
```

The Blazor WebAssembly app responds locally at `http://localhost:port/CoolApp`.

<!-- HOLD

### Blazor Server `MapFallbackToPage` configuration

Pass the following path to <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapFallbackToPage%2A> in `Program.cs`:

```csharp
app.MapFallbackToPage("/{RELATIVE PATH}/{**path:nonfile}");
```

The placeholder `{RELATIVE PATH}` is the non-root path on the server. For example, `CoolApp` is the placeholder segment if the non-root URL to the app is `https://{HOST}:{PORT}/CoolApp/`):

```csharp
app.MapFallbackToPage("/CoolApp/{**path:nonfile}");
```

-->

### Host multiple Blazor WebAssembly apps

For more information on hosting multiple Blazor WebAssembly apps in a hosted Blazor solution, see <xref:blazor/host-and-deploy/webassembly#hosted-deployment-with-multiple-blazor-webassembly-apps>.

## Deployment

For deployment guidance, see the following topics:

* <xref:blazor/host-and-deploy/webassembly>
* <xref:blazor/host-and-deploy/server>

::: moniker-end
