---
title: Using SpaServices for Creating Universal Applications | Microsoft Docs
author: scottaddie
description: Learn about the benefits of using SpaServices to build a SPA with ASP.NET Core
keywords: ASP.NET Core, Angular, SPA, JavaScriptServices, SpaServices
ms.author: scaddie
manager: wpickett
ms.date: 6/19/2017
ms.topic: article
ms.assetid: 4b30576b-2718-4c39-9253-a59966747893
ms.technology: aspnet
ms.prod: asp.net-core
uid: client-side/spa-services
ms.custom: H1Hack27Feb2017
---
# Using SpaServices for Creating Universal Applications with ASP.NET Core

By [Scott Addie](https://github.com/scottaddie)

In this article, you will learn about the value proposition of [SpaServices](https://github.com/aspnet/JavaScriptServices/tree/dev/src/Microsoft.AspNetCore.SpaServices) in building a Single Page Application (SPA) with ASP.NET Core.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/client-side/spa-services/sample)

## Using SpaServices with ASP.NET Core

A SPA is a very popular breed of web application due to its inherent rich user experience. Alas, integrating client-side SPA frameworks or libraries, such as [Angular](https://angular.io/) or [React](https://facebook.github.io/react/), with server-side frameworks like ASP.NET Core can be daunting. The `Microsoft.AspNetCore.SpaServices` NuGet package, or SpaServices for short, was developed to reduce friction in the integration process. It enables seamless operation between the disparate client and server technology stacks.

## What is SpaServices?

SpaServices was created as a component of the larger [JavaScriptServices](https://github.com/aspnet/JavaScriptServices) project, whose goal is to make ASP.NET Core developers' preferred server-side platform for building SPAs. With that being said, SpaServices is not required to develop SPAs with ASP.NET Core. Because SpaServices is a nonopinionated, client framework-agnostic library, it doesn't lock you into a particular client framework, library, or coding style. It provides useful infrastructure such as server-side prerendering, Webpack Dev Middleware, Hot Module Replacement, and routing helpers.

## Server-side prerendering

A universal (also known as isomorphic) application is a JavaScript application capable of running both on the server and the client. Angular, React, and other popular frameworks provide a universal platform for this application development style. The idea is to first render the framework components on the server via Node.js and then delegate further execution to the client.

SpaServices' ASP.NET Core [Tag Helpers](xref:mvc/views/tag-helpers/intro) simplify the implementation of server-side prerendering by invoking the JavaScript functions on the server for you.

### Prerequisites

Install the following mutually inclusive prerequisites:
1. [Microsoft.AspNetCore.SpaServices](http://www.nuget.org/packages/Microsoft.AspNetCore.SpaServices/) NuGet package
1. [aspnet-prerendering](https://www.npmjs.com/package/aspnet-prerendering) npm package:

    ```console
    npm i -S aspnet-prerendering
    ```

### Configuration

The Tag Helpers are made discoverable via namespace registration in the project's *_ViewImports.cshtml* file:

[!code-csharp[Main](../client-side/spa-services/sample/SpaServicesSampleApp/Views/_ViewImports.cshtml?highlight=3)]

These Tag Helpers abstract away the intricacies of communicating directly with low-level APIs by leveraging an HTML-like syntax inside the Razor view:

[!code-html[Main](../client-side/spa-services/sample/SpaServicesSampleApp/Views/Home/Index.cshtml?range=5)]

### The `asp-prerender-module` Tag Helper

The `asp-prerender-module` Tag Helper, used in the previous example, executes *ClientApp/dist/main-server.js* on the server via Node.js. To clarify, *main-server.js* file is an artifact of the [Webpack](http://webpack.github.io/) build process' TypeScript-to-JavaScript transpilation task. Webpack defines an entry point alias of `main-server`; and, traversal of the dependency graph for this alias begins at the *ClientApp/boot-server.ts* file:

[!code-javascript[Main](../client-side/spa-services/sample/SpaServicesSampleApp/webpack.config.js?range=53)]

The *ClientApp/boot-server.ts* file utilizes the `createServerRenderer` function and `RenderResult` type of the `aspnet-prerendering` npm package to configure server rendering via Node.js. The HTML markup destined for server-side rendering is passed to a `resolve` function call, which is wrapped in a JavaScript `Promise` object of type `RenderResult`. The `Promise` object's significance is that it asynchronously supplies the HTML markup to the page for injection in the DOM's placeholder element.

[!code-javascript[Main](../client-side/spa-services/sample/SpaServicesSampleApp/ClientApp/boot-server.ts?range=6,10-34,79-)]

### The `asp-prerender-data` Tag Helper

Sometimes contextual information must be passed as arguments from the Razor view to the server-side JavaScript. To satisfy this requirement, the `asp-prerender-data` Tag Helper is used in conjunction with the aforementioned `asp-prerender-module` Tag Helper. For example, the following markup passes user data to the `main-server` module:

[!code-html[Main](../client-side/spa-services/sample/SpaServicesSampleApp/Views/Home/Index.cshtml?range=9-12)]

The received `UserName` argument is serialized using the built-in JSON serializer and is stored in the `params.data` object. The data is used to construct a personalized greeting within an `h1` element:

[!code-javascript[Main](../client-side/spa-services/sample/SpaServicesSampleApp/ClientApp/boot-server.ts?range=6,10-21,38-52,79-)]

> [!NOTE]
> Property names passed in Tag Helpers are represented with *PascalCase* notation. Contrast that to JavaScript, where the same property names are represented with *camelCase*. The default JSON serialization configuration is responsible for this difference.

Data can be passed from the server to the view by hydrating the `globals` property passed to the `resolve` function:

[!code-javascript[Main](../client-side/spa-services/sample/SpaServicesSampleApp/ClientApp/boot-server.ts?range=6,10-21,57-77,79-)]

The `postList` array defined inside the `globals` object is attached to the browser's global `window` object. This variable hoisting to global scope eliminates duplication of effort, particularly as it pertains to loading the same data once on the server and again on the client.

![global postList variable attached to window object](spa-services/_static/global_variable.png)

## Webpack Dev Middleware

[Webpack Dev Middleware](https://webpack.github.io/docs/webpack-dev-middleware.html) introduces a streamlined development workflow whereby Webpack builds resources on demand. The middleware automatically compiles and serves client-side resources when a page is reloaded in the browser. The alternate, less efficient approach is to manually invoke Webpack via the project's npm build script when a third-party dependency or the custom code changes. An example of said build script is:

[!code-json[Main](../client-side/spa-services/sample/SpaServicesSampleApp/package.json?range=5)]

### Prerequisites

Install the following mutually inclusive prerequisites:
1. [Microsoft.AspNetCore.SpaServices](http://www.nuget.org/packages/Microsoft.AspNetCore.SpaServices/) NuGet package
1. [aspnet-webpack](https://www.npmjs.com/package/aspnet-webpack) npm package:

    ```console
    npm i -D aspnet-webpack
    ```

### Configuration

Webpack Dev Middleware is registered into the HTTP request pipeline via the following code in the *Startup.cs* file's `Configure` method:

[!code-csharp[Main](../client-side/spa-services/sample/SpaServicesSampleApp/Startup.cs?name=webpack-middleware-registration&highlight=4)]

With regard to `UseWebpackDevMiddleware`, there are a few critical points:
1. It must be called before the `UseStaticFiles` extension method
1. It should be registered for use only when running the application in development mode

Finally, the *webpack.config.js* file's `output.publicPath` property tells the middleware to watch the `wwwroot/dist` folder for changes:

[!code-javascript[Main](../client-side/spa-services/sample/SpaServicesSampleApp/webpack.config.js?range=6,13-16)]

## Hot Module Replacement

Think of Webpack's [Hot Module Replacement](https://webpack.github.io/docs/hot-module-replacement-with-webpack.html) (HMR) feature as an evolution of Webpack Dev Middleware. HMR introduces all the same benefits; and, it streamlines the development workflow even further by automatically updating page content after compiling the changes. Don't confuse this with a refresh of the browser, which would interfere with the current in-memory state and debugging session of the SPA. Changes are simply pushed to the browser.

### Prerequisites

Install the following mutually inclusive prerequisites:
1. [Microsoft.AspNetCore.SpaServices](http://www.nuget.org/packages/Microsoft.AspNetCore.SpaServices/) NuGet package
1. [webpack-hot-middleware](https://www.npmjs.com/package/webpack-hot-middleware) npm package:

    ```console
    npm i -D webpack-hot-middleware
    ```

### Configuration

The HMR component must be registered into MVC's HTTP request pipeline. An overload of the `UseWebpackDevMiddleware` extension method must be used in the `Startup` class' `Configure` method:

```csharp
app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
    HotModuleReplacement = true
});
```

As was true with Webpack Dev Middleware, there are a few critical points when using `UseWebpackDevMiddleware`:
1. It must be called before the `UseStaticFiles` extension method
1. It should be registered for use only when running the application in development mode

Finally, the *webpack.config.js* file must define a `plugins` array, even if it's left empty:

[!code-javascript[Main](../client-side/spa-services/sample/SpaServicesSampleApp/webpack.config.js?range=6,25)]

After loading the application in the browser, the developer tools' Console tab provides confirmation of HMR activation:

![Hot Module Replacement connected message](spa-services/_static/hmr_connected.png)

## Routing helpers

In most SPAs using ASP.NET Core, you'll want client-side routing in addition to server-side routing. The SPA and MVC routing systems can work independently without interference. There is, however, one edge case posing challenges: identifying 404s.

Consider the scenario in which an extensionless route of `/some/page` is used. Assume the request doesn't pattern-match a server-side route, but its pattern does match a client-side route. Now consider an incoming request for `/images/user-512.png`, which undoubtedly expects to find an image file on the server. As such, if that requested resource path doesn't match any server-side route or static file, it's unlikely that the client-side application would handle it — you probably want to return a 404 HTTP status code.

To distinguish between these cases, a C# extension method named `MapSpaFallbackRoute` is used in the `Startup` class' `Configure` method:

[!code-csharp[Main](../client-side/spa-services/sample/SpaServicesSampleApp/Startup.cs?name=mvc-routing-table&highlight=7-9)]

> [!TIP]
> Routes are evaluated in the order in which they're configured. Consequently, the `default` route in the preceding code example will be consulted first for pattern matching.

## Prerequisites for using SpaServices

To work with SpaServices, install the following:
1. [Node.js](https://nodejs.org/), version 6 or later
    * To test this is installed and can be found, run `node -v` on a command line.
    * Note: If you're deploying to an Azure web site, you don't need to do anything here &mdash; Node is already installed and available in the server environments.
1. .NET Core, version 1.0 RC4 or later
    * If you're on Windows, you can install Visual Studio 2017, which includes it.

## Creating a new project

### Using the .NET Core CLI

### Using npm / Yarn

### What does it produce

### Web API

## Developing the project

### Create the Backend (Controller / REST)

### Create Angular Module & Components

### Add Lazy Loading

## Debugging the application

### Visual Studio Code

### Visual Studio

### Chrome

## Distribution

### Use Ahead of Time Compilation

### Use Tree Shaking with Webpack

## Deploying the application

### Azure

## Additional resources

* [Angular Docs](https://angular.io/docs)