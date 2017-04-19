# Using ASP.NET Core with Angular 2


By [Fiyaz Hasan](http://fiyazhasan.me/)

In this article, you will learn how to build a SPA-style ASP.NET with AngularJS 2 using SpaServices.

## Using SpaServices for Angular and ASP.NET Core

SPAs (Single-Page Applications) are very popular these days and also great for rich end user experience when it comes to building web applications. But integrating client side SPA frameworks such as Angular 2 / React with server-side framework like ASP.NET Core can be challenging. To ease up the process of integration and keep the client side and server side in-harmony with each other, ASP.NET Core team shipped [SpaServices](https://github.com/aspnet/JavaScriptServices/tree/dev/src/Microsoft.AspNetCore.SpaServices) as a Nuget package which can be used while building applications using SPA frameworks. 

## What is SpaServices

`SpaServices` (Microsoft.AspNetCore.SpaServices) is one of the packages included in the [JavaScriptServices] (https://github.com/aspnet/JavaScriptServices) project. It provides infrastructure that's generally useful when building single page applications with technologies such as [Angular 2] (https://angular.io/) or [React] (https://facebook.github.io/react/). 

It is not mandatory to use the package as a part of developing SPA application with ASP.NET Core. However, while using it you can get access to features like,

`Server-side prerendering` for universal (a.k.a. isomorphic i.e. an javascript app that can run both on server and client-side) applications. In frameworks such as Angular 2, components are first rendered in the server side and then sent to the client for further execution.

`SpaServices` offers some ASP.NET Core APIs that know how to invoke JavaScript function on the server-side. Context information can also be passed as arguments to the function if needed. Under the hood this is all done by the [NodeServices](https://github.com/aspnet/JavaScriptServices/tree/dev/src/Microsoft.AspNetCore.NodeServices) package. 

> [!NOTE]
> `Microsoft.AspNetCore.SpaServices` package is built on top of `Microsoft.AspNetCore.NodeServices` package. Whether you are building SPAs or not the `NodeServices` package can come in handy if you want to execute javascript code on the server-side. 

Server-side prerendering happens exactly the same way. For example, to pre-render Angular 2 or React components on the server-side, `NodeServices` creates a hidden instance of `Node.js` which executes the javascript code on the server-side.

