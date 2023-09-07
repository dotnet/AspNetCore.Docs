---
title: Use Angular with ASP.NET Core
author: SteveSandersonMS
description: Learn how to get started with the ASP.NET Core Single Page Application (SPA) project template for Angular and the Angular CLI.
monikerRange: '>= aspnetcore-3.1'
ms.author: stevesa
ms.custom: mvc
ms.date: 03/16/2022
uid: spa/angular
---
# Use the Angular project template with ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

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

## Add pages, images, styles, and modules

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

When the proxy is launched, the target URL and port is inferred from the environment variables set by .NET, `ASPNETCORE_URLS` and `ASPNETCORE_HTTPS_PORT`. To set the URLs or HTTPS port, use one of the environment variables or change the value in `proxy.conf.json`.

[!INCLUDE[](~/includes/spa-proxy.md)]

## Additional resources

* <xref:security/authentication/identity/spa>
    
:::moniker-end

[!INCLUDE [](includes/angular3-7.md)]