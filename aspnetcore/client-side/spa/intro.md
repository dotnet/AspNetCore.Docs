---
title: Overview of Single Page Applications (SPA) in ASP.NET Core
author: rick-anderson
ms.author: jacalvar
monikerRange: '>= aspnetcore-6.0'
description: Overview of Single Page Applications (SPA) in ASP.NET Core
ms.date: 1/11/2023
uid: spa/intro
---
# Overview of Single Page Applications (SPA) in ASP.NET Core

## Architecture of Single Page Application templates

The Single Page Application (SPA] templates for [Angular](https://angular.io/) and [React](https://reactjs.org/) offer the ability to develop Angular and React applications that are hosted inside a .NET backend server.

At publish time, the files of the Angular and React app are copied to the `wwwroot` folder and are served via the [static files middleware](xref:fundamentals/static-files).

A fallback route handles unknown requests to the backend and serves the `index.html` for the SPA.

During development, the app is configured to use the frontend proxy provided by [React](https://reactjs.org/) and [Angular](https://angular.io/). React and Angular use the same frontend proxy.

When the app launches, the `index.html`page is opened in the browser. A special middleware that is only enabled in development:

* Intercepts the incoming requests.
* Checks whether the proxy is running.
* Redirects to the URL for the proxy if it's running or launches a new instance of the proxy.
* Returns a page to the browser that auto refreshes every few seconds until the proxy is up and the browser is redirected.

![Browser Proxy Server diagram](~/client-side/spa/intro/static/1_BPS.png)

The primary benefit the ASP.NET Core SPA templates provide:

* Launches a proxy if it's not already running.
* Setting up HTTPS.
* Configuring some requests to be proxied to the backend ASP.NET Core server.

When the browser sends a request for a backend endpoint, for example `/weatherforecast` in the templates. The SPA proxy receives the request and sends it back to the server transparently. The server responds and the SPA proxy sends the request back to the browser:



## Additional resources

* <xref:security/authentication/identity/spa>
* <xref:spa/angular>
* <xref:spa/react>
