---
title: Host and deploy ASP.NET Core Blazor Server
author: guardrex
description: Learn how to host and deploy a Blazor Server app using ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/13/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/host-and-deploy/server
---
# Host and deploy Blazor Server

This article explains how to host and deploy a Blazor Server app using ASP.NET Core.

:::moniker range=">= aspnetcore-6.0"

## Host configuration values

[Blazor Server apps](xref:blazor/hosting-models#blazor-server) can accept [Generic Host configuration values](xref:fundamentals/host/generic-host#host-configuration).

## Deployment

Using the [Blazor Server hosting model](xref:blazor/hosting-models#blazor-server), Blazor is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

A web server capable of hosting an ASP.NET Core app is required. Visual Studio includes the **Blazor Server App** project template (`blazorserver` template when using the [`dotnet new`](/dotnet/core/tools/dotnet-new) command). For more information on Blazor project templates, see <xref:blazor/project-structure>.

## Scalability

When considering the scalability of a single server (scale up), the memory available to an app is likely the first resource that the app will exhaust as user demands increase. The available memory on the server affects the:

* Number of active circuits that a server can support.
* UI latency on the client.

For guidance on building secure and scalable Blazor server apps, see <xref:blazor/security/server/threat-mitigation>.

Each circuit uses approximately 250 KB of memory for a minimal *Hello World*-style app. The size of a circuit depends on the app's code and the state maintenance requirements associated with each component. We recommend that you measure resource demands during development for your app and infrastructure, but the following baseline can be a starting point in planning your deployment target: If you expect your app to support 5,000 concurrent users, consider budgeting at least 1.3 GB of server memory to the app (or ~273 KB per user).

## SignalR configuration

Blazor Server apps use [ASP.NET Core SignalR](xref:signalr/introduction) to communicate with the browser. [SignalR's hosting and scaling conditions](xref:signalr/publish-to-azure-web-app) apply to Blazor Server apps.

Blazor works best when using [WebSockets](xref:fundamentals/websockets) as the SignalR transport due to lower latency, better reliability, and improved [security](xref:signalr/security). [Long Polling](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/TransportProtocols.md#long-polling-server-to-client-only) is used by SignalR when WebSockets isn't available or when the app is explicitly configured to use Long Polling. When deploying to Azure App Service, configure the app to use WebSockets in the Azure portal settings for the service. For details on configuring the app for Azure App Service, see the [SignalR publishing guidelines](xref:signalr/publish-to-azure-web-app).

Blazor Server emits a console warning if it detects Long Polling is utilized:

> Failed to connect via WebSockets, using the Long Polling fallback transport. This may be due to a VPN or proxy blocking the connection.

## Azure SignalR Service

We recommend using the [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) for Blazor Server apps. The service works in conjunction with the app's Blazor Hub for scaling up a Blazor Server app to a large number of concurrent SignalR connections. In addition, the SignalR Service's global reach and high-performance data centers significantly aid in reducing latency due to geography.

> [!IMPORTANT]
> When [WebSockets](https://wikipedia.org/wiki/WebSocket) are disabled, Azure App Service simulates a real-time connection using HTTP Long Polling. HTTP Long Polling is noticeably slower than running with WebSockets enabled, which doesn't use polling to simulate a client-server connection.
>
> We recommend using WebSockets for Blazor Server apps deployed to Azure App Service. The [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) uses WebSockets by default. If the app doesn't use the Azure SignalR Service, see <xref:signalr/publish-to-azure-web-app#configure-the-app-in-azure-app-service>.
>
> For more information, see:
>
> * [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview)
> * [Performance guide for Azure SignalR Service](/azure/azure-signalr/signalr-concept-performance#performance-factors)
> * <xref:signalr/publish-to-azure-web-app>

### Configuration

To configure an app for the Azure SignalR Service, the app must support *sticky sessions*, where clients are redirected back to the same server when prerendering. The `ServerStickyMode` option or configuration value is set to `Required`. Typically, an app creates the configuration using **one** of the following approaches:

* `Program.cs`:

  ```csharp
  builder.Services.AddSignalR().AddAzureSignalR(options =>
  {
      options.ServerStickyMode = 
          Microsoft.Azure.SignalR.ServerStickyMode.Required;
  });
  ```

* Configuration (use **one** of the following approaches):

  * In `appsettings.json`:

    ```json
    "Azure:SignalR:StickyServerMode": "Required"
    ```

  * The app service's **Configuration** > **Application settings** in the Azure portal (**Name**: `Azure__SignalR__StickyServerMode`, **Value**: `Required`). This approach is adopted for the app automatically if you [provision the Azure SignalR Service](#provision-the-azure-signalr-service).

> [!NOTE]
> The following error is thrown by an app that hasn't enabled sticky sessions for Azure SignalR Service:
>
> > blazor.server.js:1 Uncaught (in promise) Error: Invocation canceled due to the underlying connection being closed.

### Provision the Azure SignalR Service

To provision the Azure SignalR Service for an app in Visual Studio:

1. Create an Azure Apps publish profile in Visual Studio for the Blazor Server app.
1. Add the **Azure SignalR Service** dependency to the profile. If the Azure subscription doesn't have a pre-existing Azure SignalR Service instance to assign to the app, select **Create a new Azure SignalR Service instance** to provision a new service instance.
1. Publish the app to Azure.

Provisioning the Azure SignalR Service in Visual Studio automatically [enables *sticky sessions*](#configuration) and adds the SignalR connection string to the app service's configuration.

## Azure App Service

*This section only applies to apps not using the [Azure SignalR Service](#azure-signalr-service).*

When the Azure SignalR Service is ***not*** used, the App Service requires configuration for Application Request Routing (ARR) affinity and WebSockets. Clients connect their WebSockets directly to the app, not to the Azure SignalR Service.

Use the following guidance to configure the app:

* [Configure the app in Azure App Service](xref:signalr/publish-to-azure-web-app#configure-the-app-in-azure-app-service).
* [App Service Plan Limits](xref:signalr/publish-to-azure-web-app#app-service-plan-limits).

## IIS

When using IIS, enable:

* [WebSockets on IIS](xref:fundamentals/websockets#enabling-websockets-on-iis).
* [Sticky sessions with Application Request Routing](/iis/extensions/configuring-application-request-routing-arr/http-load-balancing-using-application-request-routing).

## Kubernetes

Create an ingress definition with the following [Kubernetes annotations for sticky sessions](https://kubernetes.github.io/ingress-nginx/examples/affinity/cookie/):

```yaml
apiVersion: extensions/v1beta1
kind: Ingress
metadata:
  name: <ingress-name>
  annotations:
    nginx.ingress.kubernetes.io/affinity: "cookie"
    nginx.ingress.kubernetes.io/session-cookie-name: "affinity"
    nginx.ingress.kubernetes.io/session-cookie-expires: "14400"
    nginx.ingress.kubernetes.io/session-cookie-max-age: "14400"
```

## Linux with Nginx

Follow the guidance for an [ASP.NET Core SignalR app](xref:signalr/scale#linux-with-nginx) with the following changes:

* Change the `location` path from `/hubroute` (`location /hubroute { ... }`) to the root path `/` (`location / { ... }`).
* Remove the configuration for proxy buffering (`proxy_buffering off;`) because the setting only applies to [Server-Sent Events (SSE)](https://developer.mozilla.org/docs/Web/API/Server-sent_events), which aren't relevant to Blazor app client-server interactions.

For more information and configuration guidance, consult the following resources:

* <xref:signalr/scale>
* <xref:host-and-deploy/linux-nginx>
* <xref:host-and-deploy/proxy-load-balancer>
* [NGINX as a WebSocket Proxy](https://www.nginx.com/blog/websocket-nginx/)
* [WebSocket proxying](http://nginx.org/docs/http/websocket.html)
* Consult developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](http://tattoocoder.com/aspnet-slack-sign-up/)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

## Linux with Apache

To host a Blazor app behind Apache on Linux, configure `ProxyPass` for HTTP and WebSockets traffic.

In the following example:

* Kestrel server is running on the host machine.
* The app listens for traffic on port 5000.

```
ProxyRequests       On
ProxyPreserveHost   On
ProxyPassMatch      ^/_blazor/(.*) http://localhost:5000/_blazor/$1
ProxyPass           /_blazor ws://localhost:5000/_blazor
ProxyPass           / http://localhost:5000/
ProxyPassReverse    / http://localhost:5000/
```

Enable the following modules:

```
a2enmod   proxy
a2enmod   proxy_wstunnel
```

Check the browser console for WebSockets errors. Example errors:

* Firefox can't establish a connection to the server at :::no-loc text="ws://the-domain-name.tld/_blazor?id=XXX":::
* Error: Failed to start the transport 'WebSockets': Error: There was an error with the transport.
* Error: Failed to start the transport 'LongPolling': TypeError: this.transport is undefined
* Error: Unable to connect to the server with any of the available transports. WebSockets failed
* Error: Cannot send data if the connection is not in the 'Connected' State.

For more information and configuration guidance, consult the following resources:

* <xref:host-and-deploy/linux-apache>
* <xref:host-and-deploy/proxy-load-balancer>
* [Apache documentation](https://httpd.apache.org/docs/current/mod/mod_proxy.html)
* Consult developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](http://tattoocoder.com/aspnet-slack-sign-up/)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

## Measure network latency

[JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) can be used to measure network latency, as the following example demonstrates.

`Shared/MeasureLatency.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/host-and-deploy/MeasureLatency.razor)]

For a reasonable UI experience, we recommend a sustained UI latency of 250 ms or less.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

## Host configuration values

[Blazor Server apps](xref:blazor/hosting-models#blazor-server) can accept [Generic Host configuration values](xref:fundamentals/host/generic-host#host-configuration).

## Deployment

Using the [Blazor Server hosting model](xref:blazor/hosting-models#blazor-server), Blazor is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

A web server capable of hosting an ASP.NET Core app is required. Visual Studio includes the **Blazor Server App** project template (`blazorserver` template when using the [`dotnet new`](/dotnet/core/tools/dotnet-new) command). For more information on Blazor project templates, see <xref:blazor/project-structure>.

## Scalability

When considering the scalability of a single server (scale up), the memory available to an app is likely the first resource that the app will exhaust as user demands increase. The available memory on the server affects the:

* Number of active circuits that a server can support.
* UI latency on the client.

For guidance on building secure and scalable Blazor server apps, see <xref:blazor/security/server/threat-mitigation>.

Each circuit uses approximately 250 KB of memory for a minimal *Hello World*-style app. The size of a circuit depends on the app's code and the state maintenance requirements associated with each component. We recommend that you measure resource demands during development for your app and infrastructure, but the following baseline can be a starting point in planning your deployment target: If you expect your app to support 5,000 concurrent users, consider budgeting at least 1.3 GB of server memory to the app (or ~273 KB per user).

## SignalR configuration

Blazor Server apps use ASP.NET Core SignalR to communicate with the browser. [SignalR's hosting and scaling conditions](xref:signalr/publish-to-azure-web-app) apply to Blazor Server apps.

Blazor works best when using WebSockets as the SignalR transport due to lower latency, reliability, and [security](xref:signalr/security). Long Polling is used by SignalR when WebSockets isn't available or when the app is explicitly configured to use Long Polling. When deploying to Azure App Service, configure the app to use WebSockets in the Azure portal settings for the service. For details on configuring the app for Azure App Service, see the [SignalR publishing guidelines](xref:signalr/publish-to-azure-web-app).

## Azure SignalR Service

We recommend using the [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) for Blazor Server apps. The service works in conjunction with the app's Blazor Hub for scaling up a Blazor Server app to a large number of concurrent SignalR connections. In addition, the SignalR Service's global reach and high-performance data centers significantly aid in reducing latency due to geography.

> [!IMPORTANT]
> When [WebSockets](https://wikipedia.org/wiki/WebSocket) are disabled, Azure App Service simulates a real-time connection using HTTP Long Polling. HTTP Long Polling is noticeably slower than running with WebSockets enabled, which doesn't use polling to simulate a client-server connection.
>
> We recommend using WebSockets for Blazor Server apps deployed to Azure App Service. The [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) uses WebSockets by default. If the app doesn't use the Azure SignalR Service, see <xref:signalr/publish-to-azure-web-app#configure-the-app-in-azure-app-service>.
>
> For more information, see:
>
> * [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview)
> * [Performance guide for Azure SignalR Service](/azure/azure-signalr/signalr-concept-performance#performance-factors)
> * <xref:signalr/publish-to-azure-web-app>

### Configuration

To configure an app for the Azure SignalR Service, the app must support *sticky sessions*, where clients are redirected back to the same server when prerendering. The `ServerStickyMode` option or configuration value is set to `Required`. Typically, an app creates the configuration using **one** of the following approaches:

* `Startup.ConfigureServices`:

  ```csharp
  services.AddSignalR().AddAzureSignalR(options =>
  {
      options.ServerStickyMode = 
          Microsoft.Azure.SignalR.ServerStickyMode.Required;
  });
  ```

* Configuration (use **one** of the following approaches):

  * In `appsettings.json`:

    ```json
    "Azure:SignalR:StickyServerMode": "Required"
    ```

  * The app service's **Configuration** > **Application settings** in the Azure portal (**Name**: `Azure__SignalR__StickyServerMode`, **Value**: `Required`). This approach is adopted for the app automatically if you [provision the Azure SignalR Service](#provision-the-azure-signalr-service).

> [!NOTE]
> The following error is thrown by an app that hasn't enabled sticky sessions for Azure SignalR Service:
>
> > blazor.server.js:1 Uncaught (in promise) Error: Invocation canceled due to the underlying connection being closed.

### Provision the Azure SignalR Service

To provision the Azure SignalR Service for an app in Visual Studio:

1. Create an Azure Apps publish profile in Visual Studio for the Blazor Server app.
1. Add the **Azure SignalR Service** dependency to the profile. If the Azure subscription doesn't have a pre-existing Azure SignalR Service instance to assign to the app, select **Create a new Azure SignalR Service instance** to provision a new service instance.
1. Publish the app to Azure.

Provisioning the Azure SignalR Service in Visual Studio automatically [enables *sticky sessions*](#configuration) and adds the SignalR connection string to the app service's configuration.

## Azure App Service

*This section only applies to apps not using the [Azure SignalR Service](#azure-signalr-service).*

When the Azure SignalR Service is ***not*** used, the App Service requires configuration for Application Request Routing (ARR) affinity and WebSockets. Clients connect their WebSockets directly to the app, not to the Azure SignalR Service.

Use the following guidance to configure the app:

* [Configure the app in Azure App Service](xref:signalr/publish-to-azure-web-app#configure-the-app-in-azure-app-service).
* [App Service Plan Limits](xref:signalr/publish-to-azure-web-app#app-service-plan-limits).

## IIS

When using IIS, enable:

* [WebSockets on IIS](xref:fundamentals/websockets#enabling-websockets-on-iis).
* [Sticky sessions with Application Request Routing](/iis/extensions/configuring-application-request-routing-arr/http-load-balancing-using-application-request-routing).

## Kubernetes

Create an ingress definition with the following [Kubernetes annotations for sticky sessions](https://kubernetes.github.io/ingress-nginx/examples/affinity/cookie/):

```yaml
apiVersion: extensions/v1beta1
kind: Ingress
metadata:
  name: <ingress-name>
  annotations:
    nginx.ingress.kubernetes.io/affinity: "cookie"
    nginx.ingress.kubernetes.io/session-cookie-name: "affinity"
    nginx.ingress.kubernetes.io/session-cookie-expires: "14400"
    nginx.ingress.kubernetes.io/session-cookie-max-age: "14400"
```

For additional Kubernetes host support, consult the following resources:

* [Kubernetes documentation](https://kubernetes.io/docs/home/)
* Developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](http://tattoocoder.com/aspnet-slack-sign-up/)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

## Linux with Nginx

For SignalR WebSockets to function properly, confirm that the proxy's `Upgrade` and `Connection` headers are set to the following values and that `$connection_upgrade` is mapped to either:

* The `Upgrade` header value by default.
* `close` when the `Upgrade` header is missing or empty.

```
http {
    map $http_upgrade $connection_upgrade {
        default Upgrade;
        ''      close;
    }

    server {
        listen      80;
        server_name example.com *.example.com;
        location / {
            proxy_pass         http://localhost:5000;
            proxy_http_version 1.1;
            proxy_set_header   Upgrade $http_upgrade;
            proxy_set_header   Connection $connection_upgrade;
            proxy_set_header   Host $host;
            proxy_cache_bypass $http_upgrade;
            proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
            proxy_set_header   X-Forwarded-Proto $scheme;
        }
    }
}
```

For additional Nginx host support, consult the following resources:

* <xref:host-and-deploy/linux-nginx>
* Nginx documentation:
  * [NGINX as a WebSocket Proxy](https://www.nginx.com/blog/websocket-nginx/)
  * [WebSocket proxying](http://nginx.org/docs/http/websocket.html)
* Developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](http://tattoocoder.com/aspnet-slack-sign-up/)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

## Linux with Apache

To host a Blazor app behind Apache on Linux, configure `ProxyPass` for HTTP and WebSockets traffic.

In the following example:

* Kestrel server is running on the host machine.
* The app listens for traffic on port 5000.

```
ProxyRequests       On
ProxyPreserveHost   On
ProxyPassMatch      ^/_blazor/(.*) http://localhost:5000/_blazor/$1
ProxyPass           /_blazor ws://localhost:5000/_blazor
ProxyPass           / http://localhost:5000/
ProxyPassReverse    / http://localhost:5000/
```

Enable the following modules:

```
a2enmod   proxy
a2enmod   proxy_wstunnel
```

Check the browser console for WebSockets errors. Example errors:

* Firefox can't establish a connection to the server at ws://the-domain-name.tld/_blazor?id=XXX.
* Error: Failed to start the transport 'WebSockets': Error: There was an error with the transport.
* Error: Failed to start the transport 'LongPolling': TypeError: this.transport is undefined
* Error: Unable to connect to the server with any of the available transports. WebSockets failed
* Error: Cannot send data if the connection is not in the 'Connected' State.

For additional Apache host support, consult the following resources:

* <xref:host-and-deploy/linux-apache>
* [Apache documentation](https://httpd.apache.org/docs/current/mod/mod_proxy.html)
* Developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](http://tattoocoder.com/aspnet-slack-sign-up/)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

## Measure network latency

[JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) can be used to measure network latency, as the following example demonstrates:

```razor
@inject IJSRuntime JS

@if (latency is null)
{
    <span>Calculating...</span>
}
else
{
    <span>@(latency.Value.TotalMilliseconds)ms</span>
}

@code {
    private DateTime startTime;
    private TimeSpan? latency;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            startTime = DateTime.UtcNow;
            var _ = await JS.InvokeAsync<string>("toString");
            latency = DateTime.UtcNow - startTime;
            StateHasChanged();
        }
    }
}
```

For a reasonable UI experience, we recommend a sustained UI latency of 250 ms or less.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

## Host configuration values

[Blazor Server apps](xref:blazor/hosting-models#blazor-server) can accept [Generic Host configuration values](xref:fundamentals/host/generic-host#host-configuration).

## Deployment

Using the [Blazor Server hosting model](xref:blazor/hosting-models#blazor-server), Blazor is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

A web server capable of hosting an ASP.NET Core app is required. Visual Studio includes the **Blazor Server App** project template (`blazorserver` template when using the [`dotnet new`](/dotnet/core/tools/dotnet-new) command). For more information on Blazor project templates, see <xref:blazor/project-structure>.

## Scalability

When considering the scalability of a single server (scale up), the memory available to an app is likely the first resource that the app will exhaust as user demands increase. The available memory on the server affects the:

* Number of active circuits that a server can support.
* UI latency on the client.

For guidance on building secure and scalable Blazor server apps, see <xref:blazor/security/server/threat-mitigation>.

Each circuit uses approximately 250 KB of memory for a minimal *Hello World*-style app. The size of a circuit depends on the app's code and the state maintenance requirements associated with each component. We recommend that you measure resource demands during development for your app and infrastructure, but the following baseline can be a starting point in planning your deployment target: If you expect your app to support 5,000 concurrent users, consider budgeting at least 1.3 GB of server memory to the app (or ~273 KB per user).

## SignalR configuration

Blazor Server apps use ASP.NET Core SignalR to communicate with the browser. [SignalR's hosting and scaling conditions](xref:signalr/publish-to-azure-web-app) apply to Blazor Server apps.

Blazor works best when using WebSockets as the SignalR transport due to lower latency, reliability, and [security](xref:signalr/security). Long Polling is used by SignalR when WebSockets isn't available or when the app is explicitly configured to use Long Polling. When deploying to Azure App Service, configure the app to use WebSockets in the Azure portal settings for the service. For details on configuring the app for Azure App Service, see the [SignalR publishing guidelines](xref:signalr/publish-to-azure-web-app).

## Azure SignalR Service

We recommend using the [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) for Blazor Server apps. The service works in conjunction with the app's Blazor Hub for scaling up a Blazor Server app to a large number of concurrent SignalR connections. In addition, the SignalR Service's global reach and high-performance data centers significantly aid in reducing latency due to geography.

> [!IMPORTANT]
> When [WebSockets](https://wikipedia.org/wiki/WebSocket) are disabled, Azure App Service simulates a real-time connection using HTTP Long Polling. HTTP Long Polling is noticeably slower than running with WebSockets enabled, which doesn't use polling to simulate a client-server connection.
>
> We recommend using WebSockets for Blazor Server apps deployed to Azure App Service. The [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) uses WebSockets by default. If the app doesn't use the Azure SignalR Service, see <xref:signalr/publish-to-azure-web-app#configure-the-app-in-azure-app-service>.
>
> For more information, see:
>
> * [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview)
> * [Performance guide for Azure SignalR Service](/azure/azure-signalr/signalr-concept-performance#performance-factors)
> * <xref:signalr/publish-to-azure-web-app>

### Configuration

To configure an app for the Azure SignalR Service, the app must support *sticky sessions*, where clients are redirected back to the same server when prerendering. The `ServerStickyMode` option or configuration value is set to `Required`. Typically, an app creates the configuration using **one** of the following approaches:

* `Startup.ConfigureServices`:

  ```csharp
  services.AddSignalR().AddAzureSignalR(options =>
  {
      options.ServerStickyMode = 
          Microsoft.Azure.SignalR.ServerStickyMode.Required;
  });
  ```

* Configuration (use **one** of the following approaches):

  * In `appsettings.json`:

    ```json
    "Azure:SignalR:StickyServerMode": "Required"
    ```

  * The app service's **Configuration** > **Application settings** in the Azure portal (**Name**: `Azure__SignalR__StickyServerMode`, **Value**: `Required`). This approach is adopted for the app automatically if you [provision the Azure SignalR Service](#provision-the-azure-signalr-service).

> [!NOTE]
> The following error is thrown by an app that hasn't enabled sticky sessions for Azure SignalR Service:
>
> > blazor.server.js:1 Uncaught (in promise) Error: Invocation canceled due to the underlying connection being closed.

### Provision the Azure SignalR Service

To provision the Azure SignalR Service for an app in Visual Studio:

1. Create an Azure Apps publish profile in Visual Studio for the Blazor Server app.
1. Add the **Azure SignalR Service** dependency to the profile. If the Azure subscription doesn't have a pre-existing Azure SignalR Service instance to assign to the app, select **Create a new Azure SignalR Service instance** to provision a new service instance.
1. Publish the app to Azure.

Provisioning the Azure SignalR Service in Visual Studio automatically [enables *sticky sessions*](#configuration) and adds the SignalR connection string to the app service's configuration.

## Azure App Service

*This section only applies to apps not using the [Azure SignalR Service](#azure-signalr-service).*

When the Azure SignalR Service is ***not*** used, the App Service requires configuration for Application Request Routing (ARR) affinity and WebSockets. Clients connect their WebSockets directly to the app, not to the Azure SignalR Service.

Use the following guidance to configure the app:

* [Configure the app in Azure App Service](xref:signalr/publish-to-azure-web-app#configure-the-app-in-azure-app-service).
* [App Service Plan Limits](xref:signalr/publish-to-azure-web-app#app-service-plan-limits).

## IIS

When using IIS, enable:

* [WebSockets on IIS](xref:fundamentals/websockets#enabling-websockets-on-iis).
* [Sticky sessions with Application Request Routing](/iis/extensions/configuring-application-request-routing-arr/http-load-balancing-using-application-request-routing).

## Kubernetes

Create an ingress definition with the following [Kubernetes annotations for sticky sessions](https://kubernetes.github.io/ingress-nginx/examples/affinity/cookie/):

```yaml
apiVersion: extensions/v1beta1
kind: Ingress
metadata:
  name: <ingress-name>
  annotations:
    nginx.ingress.kubernetes.io/affinity: "cookie"
    nginx.ingress.kubernetes.io/session-cookie-name: "affinity"
    nginx.ingress.kubernetes.io/session-cookie-expires: "14400"
    nginx.ingress.kubernetes.io/session-cookie-max-age: "14400"
```

## Linux with Nginx

For SignalR WebSockets to function properly, confirm that the proxy's `Upgrade` and `Connection` headers are set to the following values and that `$connection_upgrade` is mapped to either:

* The `Upgrade` header value by default.
* `close` when the `Upgrade` header is missing or empty.

```
http {
    map $http_upgrade $connection_upgrade {
        default Upgrade;
        ''      close;
    }

    server {
        listen      80;
        server_name example.com *.example.com
        location / {
            proxy_pass         http://localhost:5000;
            proxy_http_version 1.1;
            proxy_set_header   Upgrade $http_upgrade;
            proxy_set_header   Connection $connection_upgrade;
            proxy_set_header   Host $host;
            proxy_cache_bypass $http_upgrade;
            proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
            proxy_set_header   X-Forwarded-Proto $scheme;
        }
    }
}
```

For more information, see the following articles:

* [NGINX as a WebSocket Proxy](https://www.nginx.com/blog/websocket-nginx/)
* [WebSocket proxying](http://nginx.org/docs/http/websocket.html)
* <xref:host-and-deploy/linux-nginx>

## Linux with Apache

To host a Blazor app behind Apache on Linux, configure `ProxyPass` for HTTP and WebSockets traffic.

In the following example:

* Kestrel server is running on the host machine.
* The app listens for traffic on port 5000.

```
ProxyRequests       On
ProxyPreserveHost   On
ProxyPassMatch      ^/_blazor/(.*) http://localhost:5000/_blazor/$1
ProxyPass           /_blazor ws://localhost:5000/_blazor
ProxyPass           / http://localhost:5000/
ProxyPassReverse    / http://localhost:5000/
```

Enable the following modules:

```
a2enmod   proxy
a2enmod   proxy_wstunnel
```

Check the browser console for WebSockets errors. Example errors:

* Firefox can't establish a connection to the server at ws://the-domain-name.tld/_blazor?id=XXX.
* Error: Failed to start the transport 'WebSockets': Error: There was an error with the transport.
* Error: Failed to start the transport 'LongPolling': TypeError: this.transport is undefined
* Error: Unable to connect to the server with any of the available transports. WebSockets failed
* Error: Cannot send data if the connection is not in the 'Connected' State.

For more information, see the [Apache documentation](https://httpd.apache.org/docs/current/mod/mod_proxy.html).

## Measure network latency

[JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) can be used to measure network latency, as the following example demonstrates:

```razor
@inject IJSRuntime JS

@if (latency is null)
{
    <span>Calculating...</span>
}
else
{
    <span>@(latency.Value.TotalMilliseconds)ms</span>
}

@code {
    private DateTime startTime;
    private TimeSpan? latency;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            startTime = DateTime.UtcNow;
            var _ = await JS.InvokeAsync<string>("toString");
            latency = DateTime.UtcNow - startTime;
            StateHasChanged();
        }
    }
}
```

For a reasonable UI experience, we recommend a sustained UI latency of 250 ms or less.

:::moniker-end
