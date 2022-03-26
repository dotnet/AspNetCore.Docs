---
title: Use Angular with ASP.NET Core
author: SteveSandersonMS
description: Learn how to get started with the ASP.NET Core Single Page Application (SPA) project template for Angular and the Angular CLI.
monikerRange: '>= aspnetcore-3.1'
ms.author: stevesa
ms.custom: mvc
ms.date: 03/16/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: spa/angular
---
# Use the Angular project template with ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

<!-- This section needs to be updated to 6.0 -->

The ASP.NET Core with Angular project template provides a convenient starting point for ASP.NET Core apps using Angular and the Angular CLI to implement a rich, client-side user interface (UI).

The project template is equivalent to creating both an ASP.NET Core project to act as a web API and an Angular CLI project to act as a UI. This project combination offers the convenience of hosting both projects in a single ASP.NET Core project that can be built and published as a single unit.

The project template isn't meant for server-side rendering (SSR).

## Create a new app

Create a new project from a command prompt using the command `dotnet new angular` in an empty directory. For example, the following commands create the app in a `my-new-app` directory and switch to that directory:

```dotnetcli
dotnet new angular -o my-new-app
cd my-new-app
```

Run the app from either Visual Studio or the .NET Core CLI:

# [Visual Studio](#tab/visual-studio/)

Open the generated `.csproj` file, and run the app as normal from there.

The build process restores npm dependencies on the first run, which can take several minutes. Subsequent builds are much faster.

# [.NET Core CLI](#tab/netcore-cli/)

Ensure you have an environment variable called `ASPNETCORE_ENVIRONMENT` with a value of `Development`. On Windows (in non-PowerShell prompts), run `SET ASPNETCORE_ENVIRONMENT=Development`. On Linux or macOS, run `export ASPNETCORE_ENVIRONMENT=Development`.

Run [dotnet build](/dotnet/core/tools/dotnet-build) to verify the app builds correctly. On the first run, the build process restores npm dependencies, which can take several minutes. Subsequent builds are much faster.

Run [dotnet run](/dotnet/core/tools/dotnet-run) to start the app.

---

The project template creates an ASP.NET Core app and an Angular app. The ASP.NET Core app is intended to be used for data access, authorization, and other server-side concerns. The Angular app, residing in the `ClientApp` subdirectory, is intended to be used for all UI concerns.

## Add pages, images, styles, modules, etc.

The `ClientApp` directory contains a standard Angular CLI app. See the official [Angular documentation](https://angular.io) for more information.

There are slight differences between the Angular app created by this template and the one created by Angular CLI itself (via `ng new`); however, the app's capabilities are unchanged. The app created by the template contains a [Bootstrap](https://getbootstrap.com/)-based layout and a basic routing example.

## Run ng commands

In a command prompt, switch to the `ClientApp` subdirectory:

```console
cd ClientApp
```

If you have the `ng` tool installed globally, you can run any of its commands. For example, you can run `ng lint`, `ng test`, or any of the other [Angular CLI commands](https://angular.io/cli). There's no need to run `ng serve` though, because your ASP.NET Core app deals with serving both server-side and client-side parts of your app. Internally, it uses `ng serve` in development.

If you don't have the `ng` tool installed, run `npm run ng` instead. For example, you can run `npm run ng lint` or `npm run ng test`.

## Install npm packages

To install third-party npm packages, use a command prompt in the `ClientApp` subdirectory. For example:

```console
cd ClientApp
npm install <package_name>
```

## Publish and deploy

In development, the app runs in a mode optimized for developer convenience. For example, JavaScript bundles include source maps (so that when debugging, you can see your original TypeScript code). The app watches for TypeScript, HTML, and CSS file changes on disk and automatically recompiles and reloads when it sees those files change.

In production, serve a version of your app that's optimized for performance. This is configured to happen automatically. When you publish, the build configuration emits a minified, ahead-of-time (AoT) compiled build of your client-side code. Unlike the development build, the production build doesn't require Node.js to be installed on the server (unless you have enabled server-side rendering (SSR)).

You can use standard [ASP.NET Core hosting and deployment methods](xref:host-and-deploy/index).

## Run "ng serve" independently

The project is configured to start its own instance of the Angular CLI server in the background when the ASP.NET Core app starts in development mode. This is convenient because you don't have to run a separate server manually.

There's a drawback to this default setup. Each time you modify your C# code and your ASP.NET Core app needs to restart, the Angular CLI server restarts. Around 10 seconds is required to start back up. If you're making frequent C# code edits and don't want to wait for Angular CLI to restart, run the Angular CLI server externally, independently of the ASP.NET Core process.

To run the Angular CLI server externally, switch to the `ClientApp` subdirectory in a command prompt and launch the Angular CLI development server:

```console
cd ClientApp
npm start
```

When you start your ASP.NET Core app, it won't launch an Angular CLI server. The instance you started manually is used instead. This enables it to start and restart faster. It's no longer waiting for Angular CLI to rebuild your client app each time.

[!INCLUDE[](~/includes/spa-proxy.md)]

## Additional resources

* <xref:security/authentication/identity/spa>
    
:::moniker-end

:::moniker range="< aspnetcore-6.0"

The updated Angular project template provides a convenient starting point for ASP.NET Core apps using Angular and the Angular CLI to implement a rich, client-side user interface (UI).

The template is equivalent to creating an ASP.NET Core project to act as an API backend and an Angular CLI project to act as a UI. The template offers the convenience of hosting both project types in a single app project. Consequently, the app project can be built and published as a single unit.

## Create a new app

Create a new project from a command prompt using the command `dotnet new angular` in an empty directory. For example, the following commands create the app in a `my-new-app` directory and switch to that directory:

```dotnetcli
dotnet new angular -o my-new-app
cd my-new-app
```

Run the app from either Visual Studio or the .NET Core CLI:

# [Visual Studio](#tab/visual-studio/)

Open the generated `.csproj` file, and run the app as normal from there.

The build process restores npm dependencies on the first run, which can take several minutes. Subsequent builds are much faster.

# [.NET Core CLI](#tab/netcore-cli/)

Ensure you have an environment variable called `ASPNETCORE_ENVIRONMENT` with a value of `Development`. On Windows (in non-PowerShell prompts), run `SET ASPNETCORE_ENVIRONMENT=Development`. On Linux or macOS, run `export ASPNETCORE_ENVIRONMENT=Development`.

Run [dotnet build](/dotnet/core/tools/dotnet-build) to verify the app builds correctly. On the first run, the build process restores npm dependencies, which can take several minutes. Subsequent builds are much faster.

Run [dotnet run](/dotnet/core/tools/dotnet-run) to start the app. A message similar to the following is logged:

```console
Now listening on: http://localhost:<port>
```

Navigate to this URL in a browser.

> [!WARNING]
> The app starts up an instance of the Angular CLI server in the background. A message similar to the following is logged:
> *NG Live Development Server is listening on localhost:&lt;otherport&gt;, open a browser to http://localhost:&lt;otherport&gt;/*. Ignore this message&mdash;it's **not** the URL for the combined ASP.NET Core and Angular CLI app.

---

The project template creates an ASP.NET Core app and an Angular app. The ASP.NET Core app is intended to be used for data access, authorization, and other server-side concerns. The Angular app, residing in the `ClientApp` subdirectory, is intended to be used for all UI concerns.

## Add pages, images, styles, modules, etc.

The `ClientApp` directory contains a standard Angular CLI app. See the official [Angular documentation](https://angular.io) for more information.

There are slight differences between the Angular app created by this template and the one created by Angular CLI itself (via `ng new`); however, the app's capabilities are unchanged. The app created by the template contains a [Bootstrap](https://getbootstrap.com/)-based layout and a basic routing example.

## Run ng commands

In a command prompt, switch to the `ClientApp` subdirectory:

```console
cd ClientApp
```

If you have the `ng` tool installed globally, you can run any of its commands. For example, you can run `ng lint`, `ng test`, or any of the other [Angular CLI commands](https://angular.io/cli). There's no need to run `ng serve` though, because your ASP.NET Core app deals with serving both server-side and client-side parts of your app. Internally, it uses `ng serve` in development.

If you don't have the `ng` tool installed, run `npm run ng` instead. For example, you can run `npm run ng lint` or `npm run ng test`.

## Install npm packages

To install third-party npm packages, use a command prompt in the `ClientApp` subdirectory. For example:

```console
cd ClientApp
npm install --save <package_name>
```

## Publish and deploy

In development, the app runs in a mode optimized for developer convenience. For example, JavaScript bundles include source maps (so that when debugging, you can see your original TypeScript code). The app watches for TypeScript, HTML, and CSS file changes on disk and automatically recompiles and reloads when it sees those files change.

In production, serve a version of your app that's optimized for performance. This is configured to happen automatically. When you publish, the build configuration emits a minified, ahead-of-time (AoT) compiled build of your client-side code. Unlike the development build, the production build doesn't require Node.js to be installed on the server (unless you have enabled server-side rendering (SSR)).

You can use standard [ASP.NET Core hosting and deployment methods](xref:host-and-deploy/index).

## Run "ng serve" independently

The project is configured to start its own instance of the Angular CLI server in the background when the ASP.NET Core app starts in development mode. This is convenient because you don't have to run a separate server manually.

There's a drawback to this default setup. Each time you modify your C# code and your ASP.NET Core app needs to restart, the Angular CLI server restarts. Around 10 seconds is required to start back up. If you're making frequent C# code edits and don't want to wait for Angular CLI to restart, run the Angular CLI server externally, independently of the ASP.NET Core process. To do so:

1. In a command prompt, switch to the `ClientApp` subdirectory, and launch the Angular CLI development server:

    ```console
    cd ClientApp
    npm start
    ```

    > [!IMPORTANT]
    > Use `npm start` to launch the Angular CLI development server, not `ng serve`, so that the configuration in `package.json` is respected. To pass additional parameters to the Angular CLI server, add them to the relevant `scripts` line in your `package.json` file.

2. Modify your ASP.NET Core app to use the external Angular CLI instance instead of launching one of its own. In your *Startup* class, replace the `spa.UseAngularCliServer` invocation with the following:

    ```csharp
    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
    ```

When you start your ASP.NET Core app, it won't launch an Angular CLI server. The instance you started manually is used instead. This enables it to start and restart faster. It's no longer waiting for Angular CLI to rebuild your client app each time.

### Pass data from .NET code into TypeScript code

During SSR, you might want to pass per-request data from your ASP.NET Core app into your Angular app. For example, you could pass cookie information or something read from a database. To do this, edit your *Startup* class. In the callback for `UseSpaPrerendering`, set a value for `options.SupplyData` such as the following:

```csharp
options.SupplyData = (context, data) =>
{
    // Creates a new value called isHttpsRequest that's passed to TypeScript code
    data["isHttpsRequest"] = context.Request.IsHttps;
};
```

The `SupplyData` callback lets you pass arbitrary, per-request, JSON-serializable data (for example, strings, booleans, or numbers). Your `main.server.ts` code receives this as `params.data`. For example, the preceding code sample passes a boolean value as `params.data.isHttpsRequest` into the `createServerRenderer` callback. You can pass this to other parts of your app in any way supported by Angular. For example, see how `main.server.ts` passes the `BASE_URL` value to any component whose constructor is declared to receive it.

### Drawbacks of SSR

Not all apps benefit from SSR. The primary benefit is perceived performance. Visitors reaching your app over a slow network connection or on slow mobile devices see the initial UI quickly, even if it takes a while to fetch or parse the JavaScript bundles. However, many SPAs are mainly used over fast, internal company networks on fast computers where the app appears almost instantly.

At the same time, there are significant drawbacks to enabling SSR. It adds complexity to your development process. Your code must run in two different environments: client-side and server-side (in a Node.js environment invoked from ASP.NET Core). Here are some things to bear in mind:

* SSR requires a Node.js installation on your production servers. This is automatically the case for some deployment scenarios, such as Azure App Services, but not for others, such as Azure Service Fabric.
* Enabling the `BuildServerSideRenderer` build flag causes your *node_modules* directory to publish. This folder contains 20,000+ files, which increases deployment time.
* To run your code in a Node.js environment, it can't rely on the existence of browser-specific JavaScript APIs such as `window` or `localStorage`. If your code (or some third-party library you reference) tries to use these APIs, you'll get an error during SSR. For example, don't use jQuery because it references browser-specific APIs in many places. To prevent errors, you must either avoid SSR or avoid browser-specific APIs or libraries. You can wrap any calls to such APIs in checks to ensure they aren't invoked during SSR. For example, use a check such as the following in JavaScript or TypeScript code:

```javascript
if (typeof window !== 'undefined') {
    // Call browser-specific APIs here
}
```

[!INCLUDE[](~/includes/spa-proxy.md)]

## Additional resources

* <xref:security/authentication/identity/spa>

:::moniker-end
