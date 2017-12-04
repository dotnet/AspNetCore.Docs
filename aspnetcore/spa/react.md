---
title: Using the React project template
description: 
keywords: ASP.NET Core, SPA, React
uid: spa/react
---
# Using the React project template (preview)

> [!NOTE]
> The existing .NET Core 2.0.x SDK includes a React project template. **This documentation is not about the existing React project template.** This documentation is about the next version of the React template which we will ship in early 2018.

The updated React project template provides a convenient starting point for ASP.NET Core applications using React and *create-react-app* (CRA) conventions to implement a rich client-side user interface (UI).

The template is equivalent to creating both an ASP.NET Core project to act as an API backend, and a standard CRA React project to act as a UI, but with the convenience of hosting both in a single application project that can be built and published as a single unit.

## Creating a new application

To get started, first make sure you've [installed the updated React project template](xref:spa/index), because these instructions do not apply to the previous React project template that is included in the .NET Core 2.0.x SDK.

Next, create a new project from a command prompt using the command `dotnet new react` in an empty directory. For example, run:

```text
mkdir my-new-app
cd my-new-app
dotnet new react
```

You can run the application either from the command prompt, or from Visual Studio on Windows.

# [Running from Visual Studio](#tab/run-in-vs)

If you use Windows and want to use Visual Studio, you can simply open the generated `.csproj` file in Visual Studio and run the application as normal from there.

On the first run, the build process will restore NPM dependencies, which can take several minutes. Subsequent builds will be far faster.

# [Running from a Command Prompt](#tab/run-from-command-prompt)

First make sure you have an environment variable called `ASPNETCORE_Environment` with value `Development`. For example, on Windows (in non-PowerShell prompts), run `SET ASPNETCORE_Enviromnent=Development`, or on Linux/macOS, run `export ASPNETCORE_Environment=Development`.

Next run `dotnet build` to verify your application builds correctly and to see the progress as it does. On the first run, the build process will restore NPM dependencies, which can take several minutes. Subsequent builds will be far faster.

Finally run `dotnet run` to start the application.

***

## Features

The project template gives you an ASP.NET Core application that runs on the server, which is intended to be used for data access, authorization, and other server-side concerns, and a React application (in the `ClientApp` subdirectory) which is intended to be used for all user-interface concerns.

### Adding pages, images, styles, modules, etc.

The `ClientApp` directory is a standard create-react-app (CRA) React application, so please see [create-react-app documentation](https://github.com/facebookincubator/create-react-app/blob/master/packages/react-scripts/template/README.md) for all information about building applications with CRA.

The difference between the React app created by this template and the one created by CRA itself is that we've added a Bootstrap-based layout and a simple example of routing to this template. Its capabilities however are unchanged.

### Installing NPM packages

To install third-party NPM packages, make sure you use a command prompt in the `ClientApp` subdirectory. For example,

```text
cd ClientApp
npm install --save <packagename>
```

### Publishing and Deploying

In development, the application runs in a mode optimized for developer convenience. For example, JavaScript bundles include source maps (so that when debugging, you can see your original source code), and the application watches for changes to JavaScript/HTML/CSS files on disk and will automatically recompile and reload when it sees those files change.

In production, you will want to serve a version of your application that is optimized for performance instead. This is configured to happen automatically: when you publish, the build configuration will emit a correctly minified, transpiled build of your client-side code. Unlike the development build, the production build does not require Node.js to be installed on the server.

You can use standard [ASP.NET Core publish and deployment methods](xref:publishing/index).

### Running the CRA server independently

By default, the project is configured to start up its own instance of the create-react-app (CRA) development server in the background whenever the ASP.NET Core application starts in development mode. This is convenient because it means you don't have to run a separate server manually.

A drawback to this default setup is that each time you modify your C# code and your ASP.NET Core application needs to restart, this will also restart the CRA server, which takes a few seconds to start back up. If you're making frequent C# code edits and don't want to keep waiting for the CRA server to restart, you can choose to run the CRA server externally, independently of the ASP.NET Core process. To do so,

1. In a command prompt, switch to the `ClientApp` subdirectory, and launch the CRA development server:

    ```text
    cd ClientApp
    npm start
    ```

2. Modify your ASP.NET Core application to use the external CRA server instance instead of launching one of its own. In your `Startup.cs` file, find the line that calls `spa.UseReactDevelopmentServer`, remove it entirely, and replace that line with the following:

    ```csharp
    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
    ```

Now when you start your ASP.NET Core application, it will not launch a CRA server, but will instead use the instance that you started manually. This will enable it to start and restart faster (because it's no longer waiting for your React application to rebuild each time).
