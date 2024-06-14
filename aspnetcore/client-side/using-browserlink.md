---
title: Browser link in ASP.NET Core
author: tdykstra
description: Explains how browser link is a Visual Studio feature that links the development environment with one or more web browsers.
monikerRange: '>= aspnetcore-1.1'
ms.author: tdykstra
ms.date: 06/05/2024
uid: client-side/using-browserlink
---
# Browser link in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-6.0"

By [Nicolò Carandini](https://github.com/ncarandini) and [Tom Dykstra](https://github.com/tdykstra)

Browser link is a Visual Studio feature. It creates a communication channel between the development environment and one or more web browsers. Use browser link to:

* Refresh your web app in several browsers at once.
* Test across multiple browsers with specific settings such as screen sizes.
* Select UI elements in browsers in real-time, see what markup and source it's correlated to in Visual Studio.
* Conduct real-time browser test automation.

## Runtime compilation vs. hot reload

Use browser Link with [runtime compilation](xref:mvc/views/view-compilation) or [hot reload](xref:test/hot-reload) to see the effect of run-time changes in Razor (`.cshtml`) files. We recommend hot reload.

## How to use browser link

When you have an ASP.NET Core project open, Visual Studio shows the browser link toolbar control next to the **Debug Type** toolbar control:

![browser link drop-down menu](~/client-side/using-browserlink/_static/browserLink-dropdown-menu.png)

From the browser link toolbar control, you can:

* Refresh the web app in several browsers at once.
* Open the **Browser Link Dashboard**.
* Enable or disable **Browser Link**.
* Enable or disable **CSS Hot Reload**.

## Refresh the web app in several browsers at once

To choose a single web browser to launch when starting the project, use the drop-down menu in the **Debug Target** toolbar control:

![F5 drop-down menu](~/client-side/using-browserlink/_static/debug-target-dropdown-menu.png)

To open multiple browsers at once, choose **Browse with...** from the same drop-down. Hold down the <kbd>Ctrl</kbd> key to select the browsers you want, and then click **Browse**:

![Open many browsers at once](~/client-side/using-browserlink/_static/open-many-browsers-at-once.png)

The following screenshot shows Visual Studio with the Index view open and two open browsers:

![Sync with two browsers example](~/client-side/using-browserlink/_static/sync-with-two-browsers-example.png)

Hover over the browser link toolbar control to see the browsers that are connected to the project:

![Hover tip](~/client-side/using-browserlink/_static/hoover-tip.png)

Change the Index view, and all connected browsers are updated when you click the browser link refresh button:

![Browsers sync to changes](~/client-side/using-browserlink/_static/browsers-sync-to-changes.png)

browser link also works with browsers that you launch from outside Visual Studio and navigate to the app URL.

## The browser link dashboard

Open the **browser link dashboard** window from the browser link drop down menu to manage the connection with open browsers:

![how-to-open-browserlink-dashboard](~/client-side/using-browserlink/_static/open-browserlink-dashboard.png)

The connected browsers are shown with the path to the page that each browser is showing:

![Browser link dashboard two connections](~/client-side/using-browserlink/_static/browserlink-dashboard-two-connections.png)

You can also click on an individual browser name to refresh only that browser.

## Enable or disable browser link

When you re-enable browser link after disabling it, you must refresh the browsers to reconnect them.

## Enable or disable CSS hot reload

When CSS hot reload is enabled, connected browsers are automatically refreshed when you make any change to CSS files.

## How it works

browser link uses [SignalR](xref:signalr/introduction) to create a communication channel between Visual Studio and the browser. When browser link is enabled, Visual Studio acts as a SignalR server that multiple clients (browsers) can connect to. browser link also registers a middleware component in the ASP.NET Core request pipeline. This component injects special `<script>` references into every page request from the server. You can see the script references by selecting **View source** in the browser and scrolling to the end of the `<body>` tag content:

```html
    <!-- Visual Studio browser link -->
    <script type="application/json" id="__browserLink_initializationData">
        {"requestId":"a717d5a07c1741949a7cefd6fa2bad08","requestMappingFromServer":false}
    </script>
    <script type="text/javascript" src="http://localhost:54139/b6e36e429d034f578ebccd6a79bf19bf/browserLink" async="async"></script>
    <!-- End browser link -->
</body>
```

Your source files aren't modified. The middleware component injects the script references dynamically.

Because the browser-side code is all JavaScript, it works on all browsers that SignalR supports without requiring a browser plug-in.

:::moniker-end

[!INCLUDE[](~/client-side/using-browserlink/includes/using-browserlink-1-5.md)]
