---
title: Use the React project template
author: SteveSandersonMS
description: Learn how to get started with the ASP.NET Core Single-Page Application (SPA) release candidate project template for React and create-react-app.
manager: wpickett
ms.author: scaddie
ms.custom: mvc
ms.date: 12/06/2017
ms.devlang: csharp
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: spa/react
---
# Use the React project template (release candidate)

> [!NOTE]
> This documentation is not about the released React project template. **This documentation is about the release candidate of the React template.** We hope to ship the released version in early 2018.

The updated React project template provides a convenient starting point for ASP.NET Core apps using React and [create-react-app](https://github.com/facebookincubator/create-react-app) (CRA) conventions to implement a rich, client-side user interface (UI).

The template is equivalent to creating both an ASP.NET Core project to act as an API backend, and a standard CRA React project to act as a UI, but with the convenience of hosting both in a single app project that can be built and published as a single unit.

## Create a new app

To get started, ensure you've [installed the updated React project template](xref:spa/index#installation). These instructions don't apply to the previous React project template included in the .NET Core 2.0.x SDK.

Create a new project from a command prompt using the command `dotnet new react` in an empty directory. For example, the following commands create the app in a *my-new-app* directory and switch to that directory:

```console
dotnet new react -o my-new-app
cd my-new-app
```

Run the app from either Visual Studio or the .NET Core CLI:

# [Visual Studio](#tab/visual-studio)

Open the generated *.csproj* file, and run the app as normal from there.

The build process restores npm dependencies on the first run, which can take several minutes. Subsequent builds are much faster.

# [.NET Core CLI](#tab/netcore-cli)

Ensure you have an environment variable called `ASPNETCORE_Environment` with value of `Development`. On Windows (in non-PowerShell prompts), run `SET ASPNETCORE_Environment=Development`. On Linux or macOS, run `export ASPNETCORE_Environment=Development`.

Run `dotnet build` to verify your app builds correctly. On the first run, the build process restores npm dependencies, which can take several minutes. Subsequent builds are much faster.

Run `dotnet run` to start the app.

---

The project template creates an ASP.NET Core app and a React app. The ASP.NET Core app is intended to be used for data access, authorization, and other server-side concerns. The React app, residing in the *ClientApp* subdirectory, is intended to be used for all UI concerns.

## Add pages, images, styles, modules, etc.

The *ClientApp* directory is a standard CRA React app. See the official [CRA documentation](https://github.com/facebookincubator/create-react-app/blob/master/packages/react-scripts/template/README.md) for more information.

There are slight differences between the React app created by this template and the one created by CRA itself; however, the app's capabilities are unchanged. The app created by the template contains a [Bootstrap](https://getbootstrap.com/)-based layout and a basic routing example.

## Install npm packages

To install third-party npm packages, use a command prompt in the *ClientApp* subdirectory. For example:

```console
cd ClientApp
npm install --save <package_name>
```

## Publish and deploy

In development, the app runs in a mode optimized for developer convenience. For example, JavaScript bundles include source maps (so that when debugging, you can see your original source code). The app watches JavaScript, HTML, and CSS file changes on disk and automatically recompiles and reloads when it sees those files change.

In production, serve a version of your app that is optimized for performance. This is configured to happen automatically. When you publish, the build configuration emits a minified, transpiled build of your client-side code. Unlike the development build, the production build doesn't require Node.js to be installed on the server.

You can use standard [ASP.NET Core hosting and deployment methods](xref:host-and-deploy/index).

## Run the CRA server independently

The project is configured to start its own instance of the CRA development server in the background when the ASP.NET Core app starts in development mode. This is convenient because it means you don't have to run a separate server manually.

There is a drawback to this default setup. Each time you modify your C# code and your ASP.NET Core app needs to restart, the CRA server restarts. A few seconds are required to start back up. If you're making frequent C# code edits and don't want to wait for the CRA server to restart, run the CRA server externally, independently of the ASP.NET Core process. To do so:

1. In a command prompt, switch to the *ClientApp* subdirectory, and launch the CRA development server:

    ```console
    cd ClientApp
    npm start
    ```

2. Modify your ASP.NET Core app to use the external CRA server instance instead of launching one of its own. In your *Startup* class, replace the `spa.UseReactDevelopmentServer` invocation with the following:

    ```csharp
    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
    ```

When you start your ASP.NET Core app, it won't launch a CRA server. The instance you started manually is used instead. This enables it to start and restart faster. It's no longer waiting for your React app to rebuild each time.
