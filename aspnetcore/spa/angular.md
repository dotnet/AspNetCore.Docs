---
title: Using the Angular project template
description: 
keywords: ASP.NET Core, SPA, Angular
uid: spa/angular
---
# Using the Angular project template (preview)

> [!NOTE]
> The existing .NET Core 2.0.x SDK includes an Angular project template. **This documentation is not about the existing Angular project template.** This documentation is about the next version of the Angular template which we will ship in early 2018.

The updated Angular project template provides a convenient starting point for ASP.NET Core applications using Angular 5 and the Angular CLI to implement a rich client-side user interface (UI).

The template is equivalent to creating both an ASP.NET Core project to act as an API backend, and a standard Angular CLI project to act as a UI, but with the convenience of hosting both in a single application project that can be built and published as a single unit.

## Creating a new application

To get started, first make sure you've [installed the updated Angular project template](xref:spa/index), because these instructions do not apply to the previous Angular project template that is included in the .NET Core 2.0.x SDK.

Next, create a new project from a command prompt using the command `dotnet new angular` in an empty directory. For example, run:

```text
mkdir my-new-app
cd my-new-app
dotnet new angular
```

You can run the application either from the command prompt, or from Visual Studio on Windows.

# [Running from Visual Studio](#tab/run-in-vs)

If you use Windows and want to use Visual Studio, you can simply open the generated `.csproj` file in Visual Studio and run the application as normal from there.

On the first run, the build process will restore NPM dependencies, which can take several minutes. Subsequent builds will be far faster.

# [Running from a Command Prompt](#tab/run-from-command-prompt)

First make sure you have an environment variable called `ASPNETCORE_Environment` with value `Development`. For example, on Windows (in non-PowerShell prompts), run `SET ASPNETCORE_Enviromnent=Development`, or on Linux/macOS, run `export ASPNETCORE_Environment=Development`.

Next run `dotnet build` to verify your application builds correctly and to see the progress as it does. On the first run, the build process will restore NPM dependencies, which can take several minutes. Subsequent builds will be far faster.

Finally run `dotnet run` to start the application. As the application starts up in development mode, it will log a message similar to the following:

```text
Now listening on: http://localhost:<port>
```

This is the URL you should open in a browser.

The application will also start up an instance of the Angular CLI server in the background, which will in turn log a message similar to *NG Live Development Server is listening on localhost:&lt;otherport&gt;, open your browser on http://localhost:&lt;otherport&gt;/*. You can ignore this &mdash; it's **not** the URL for the combined ASP.NET Core and Angular CLI application.

***

## Features

The project template gives you an ASP.NET Core application that runs on the server, which is intended to be used for data access, authorization, and other server-side concerns, and an Angular application (in the `ClientApp` subdirectory) which is intended to be used for all user-interface concerns.

### Adding pages, images, styles, modules, etc.

The `ClientApp` directory is a standard Angular CLI application, so please see [Angular documentation](https://github.com/angular/angular-cli/wiki) for all information about building applications with Angular.

The difference between the Angular app created by this template and the one created by Angular CLI itself (via `ng new`) is that we've added a Bootstrap-based layout and a simple example of routing to this template. Its capabilities however are unchanged.

### Running ng commands

In a command prompt, switch to the `ClientApp` subdirectory:

```text
cd ClientApp
```

Now if you have the `ng` tool installed globally, you can run any of its commands. For example, you can run `ng lint`, `ng test`, or any of the other [Angular CLI commands](https://github.com/angular/angular-cli/wiki#additional-commands). There's no need to run `ng serve` though, because your ASP.NET Core application deals with serving both server-side and client-side parts of your application (and internally, it uses `ng serve` in development for you).

If you don't have the `ng` tool installed, then you can use `npm run ng` instead. For example, you can run `npm run ng lint`, or `npm run ng test`, etc.

### Installing NPM packages

To install third-party NPM packages, make sure you use a command prompt in the `ClientApp` subdirectory. For example,

```text
cd ClientApp
npm install --save <packagename>
```

### Publishing and Deploying

In development, the application runs in a mode optimized for developer convenience. For example, JavaScript bundles include source maps (so that when debugging, you can see your original TypeScript code), and the application watches for changes to TypeScript/HTML/CSS files on disk and will automatically recompile and reload when it sees those files change.

In production, you will want to serve a version of your application that is optimized for performance instead. This is configured to happen automatically: when you publish, the build configuration will emit a correctly minified, ahead-of-time compiled build of your client-side code. Unlike the development build, the production build does not require Node.js to be installed on the server (unless you have enabled [server-side prerendering](#server-side-rendering)).

You can use standard [ASP.NET Core publish and deployment methods](xref:publishing/index).

### Running "ng serve" independently

By default, the project is configured to start up its own instance of the Angular CLI server in the background whenever the ASP.NET Core application starts in development mode. This is convenient because it means you don't have to run a separate server manually.

A drawback to this default setup is that each time you modify your C# code and your ASP.NET Core application needs to restart, this will also restart the Angular CLI server, which takes around 10 seconds to start back up. If you're making frequent C# code edits and don't want to keep waiting for Angular CLI to restart, you can choose to run the Angular CLI server externally, independently of the ASP.NET Core process. To do so,

1. In a command prompt, switch to the `ClientApp` subdirectory, and launch the Angular CLI development server:

    ```text
    cd ClientApp
    npm start
    ```

    **Important:** Use `npm start` to launch the Angular CLI development server, not `ng serve`, so that the configuration in `package.json` is respected. If you want to pass additional parameters to the Angular CLI server, then add them to the relevant `scripts` line in your `package.json` file instead.

2. Modify your ASP.NET Core application to use the external Angular CLI instance instead of launching one of its own. In your `Startup.cs` file, find the line that calls `spa.UseAngularCliServer`, remove it entirely, and replace that line with the following:

    ```csharp
    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
    ```

Now when you start your ASP.NET Core application, it will not launch an Angular CLI server, but will instead use the instance that you started manually. This will enable it to start and restart much faster (because it's no longer waiting for Angular CLI to rebuild your client application each time).

### Server-side Rendering

As a performance feature, you can choose to prerender your Angular application on the server as well as running it on the client. This means that browsers will receive HTML markup representing your application's initial UI, so they will display it even before downloading and executing your JavaScript bundles. Most of the implementation of this comes from an Angular feature called [Angular Universal](https://universal.angular.io/).

> [!TIP]
> Enabling server-side rendering (SSR) introduces a number of extra complications both during development and deployment. Read about [drawbacks of SSR](#drawbacks-of-ssr) below to make a judgement about whether this is a good fit for your requirements.

To enable server-side rendering (SSR), you need to make a number of additions to your project.

In `Startup.cs`, *after* the line that configures `spa.Options.SourcePath`, and *before* the call to `UseAngularCliServer` or `UseProxyToSpaDevelopmentServer`, add the following:

[!code-csharp[Main](sample/AngularServerSideRendering/Startup.cs?name=Call_UseSpa&highlight=5-12)]

In development mode, this code attempts to build the SSR bundle by running the script `build:ssr`, which is defined in `ClientApp\package.json`. In turn, this builds an Angular app named `ssr`, which is not yet defined. 

So next you must edit the `.angular-cli.json` file in `ClientApp`. At the end of its `apps` array, define an extra app with name `ssr`, with options as follows:

[!code-json[Main](sample/AngularServerSideRendering/ClientApp/.angular-cli.json?range=24-41)]

This new SSR-enabled app configuration requires two further files, `tsconfig.server.json` (which specifies options for TypeScript compilation), and `main.server.ts` (which is the code entrypoint used during SSR).

Add a new file called `tsconfig.server.json` inside `ClientApp` (alongside the existing `tsconfig.json`), containing the following:

[!code-json[Main](sample/AngularServerSideRendering/ClientApp/tsconfig.server.json)]

This file configures Angular's ahead-of-time (AoT) compiler to look for a module called `app.server.module`. Add this by creating a new file at `ClientApp/src/app/app.server.module.ts` (alongside the existing `app.module.ts`) containing the following: 

[!code-typescript[Main](sample/AngularServerSideRendering/ClientApp/src/app/app.server.module.ts)]

This module inherits from your client-side `app.module` and defines which extra Angular modules will be available during SSR.

Next, remember that the new `ssr` entry in `.angular-cli.json` referenced an entry point file called `main.server.ts`. You haven't yet added that file, and now is time to do so. Create a new file at `ClientApp/src/main.server.ts` (alongside the existing `main.ts`), containing the following:

[!code-typescript[Main](sample/AngularServerSideRendering/ClientApp/src/main.server.ts)]

The code in this file is what ASP.NET Core executes for each request when it runs the `UseSpaPrerendering` middleware that you added to `Startup.cs`. It deals with receiving `params` from the .NET code (such as the URL being requested), and making calls to Angular server-side rendering APIs to get the resulting HTML. 

Strictly speaking this is sufficient to enable server-side rendering in development mode. But it's essential to make one final change so that your application works correctly when published, too. In your application's main `.csproj` file, find the property `BuildServerSideRenderer` and set its value to `true`:

[!code-xml[Main](sample/AngularServerSideRendering/AngularServerSideRendering.csproj?name=sample_EnableBuildServerSideRenderer)]

This configures the build process to run `build:ssr` during publishing and deploy the SSR files to the server. If you don't enable this, SSR will fail in production.

Now when you run your application in either development or production mode, your Angular code will be prerendered as HTML on the server, and then will also execute client-side as normal.

#### Passing data from .NET code into TypeScript code

During SSR, you might want to pass per-request data from your ASP.NET Core application into your Angular application. For example, you could pass cookie information or something read from a database. To do this, edit your `Startup.cs` file. In the callback for `UseSpaPrerendering`, set a value for `options.SupplyData` such as the following:

```csharp
options.SupplyData = (context, data) =>
{
    // Creates a new value called isHttpsRequest that will be passed to TypeScript code
    data["isHttpsRequest"] = context.Request.IsHttps;
};
```

The `SupplyData` callback lets you pass arbitrary per-request JSON-serializable data (for example, strings, booleans, or numbers). Your `main.server.ts` code will receive this as `params.data`. For example, the preceding code sample would pass a boolean value as `params.data.isHttpsRequest` into the `createServerRenderer` callback. You can then pass this to other parts of your application in any way supported by Angular (for example, see how that file passes a value called `BASE_URL` to any component whose constructor is declared to receive it).

#### Drawbacks of SSR

Not all applications benefit from server-side rendering (SSR). The primary benefit is to do with perceived performance: vistors reaching your app over a slow network connection or on slow mobile devices will see the inital UI quickly, even if it takes a while to fetch or parse the JavaScript bundles. However, many SPAs are mainly used over fast internal company networks on fast computers where the app will appear more or less instantly anyway.

At the same time there are significant drawbacks to enabling SSR. It will make your development process more complex. Fundamentally this is because it requires your code to run in two different environments - client-side in the browser, and server-side in a Node.js environment invoked from ASP.NET Core. Here are some things you should bear in mind:

 * SSR means you need to have Node.js installed on your production servers. This is automatically the case for some deployment scenarios, such as Azure App Services, but not for others, such as Azure Service Fabric. 
 * Enabling the `BuildServerSideRenderer` build flag means that your `node_modules` directory will be published: this contains 20,000+ files and will make deployment take longer.
 * For your code to run in a Node.js environment, it cannot rely on the existence of browser-specific JavaScript APIs such as `window` or `localStorage`. If your code (or some third-party library you reference) tries to use these APIs, you'll get an error during SSR. For example, you must not use jQuery, because it references browser-specific APIs in many places. To avoid errors you must either not use SSR, or not use browser-specific APIs or libraries, or wrap any calls to such APIs in checks to ensure they aren't invoked during SSR. For example, in JavaScript or TypeScript code you could use a check such as:

    ```javascript
    if (typeof window !== 'undefined') {
        // Call browser-specific APIs here
    }
    ```
