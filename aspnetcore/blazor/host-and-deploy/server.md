---
title: Host and deploy ASP.NET Core server-side Blazor apps
author: guardrex
description: Learn how to host and deploy server-side Blazor apps using ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/host-and-deploy/server
---
# Host and deploy server-side Blazor apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy server-side Blazor apps using ASP.NET Core.

## Host configuration values

Server-side Blazor apps can accept [Generic Host configuration values](xref:fundamentals/host/generic-host#host-configuration).

## Deployment

Using a server-side hosting model, Blazor is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

A web server capable of hosting an ASP.NET Core app is required. Visual Studio includes a server-side app project template. For more information on Blazor project templates, see <xref:blazor/project-structure>.

## Scalability

When considering the scalability of a single server (scale up), the memory available to an app is likely the first resource that the app exhausts as user demands increase. The available memory on the server affects the:

* Number of active circuits that a server can support.
* UI latency on the client.

For guidance on building secure and scalable server-side Blazor apps, see <xref:blazor/security/server/threat-mitigation>.

Each circuit uses approximately 250 KB of memory for a minimal *Hello World*-style app. The size of a circuit depends on the app's code and the state maintenance requirements associated with each component. We recommend that you measure resource demands during development for your app and infrastructure, but the following baseline can be a starting point in planning your deployment target: If you expect your app to support 5,000 concurrent users, consider budgeting at least 1.3 GB of server memory to the app (or ~273 KB per user).

## SignalR configuration

[SignalR's hosting and scaling conditions](xref:signalr/publish-to-azure-web-app) apply to Blazor apps that use SignalR.

:::moniker range=">= aspnetcore-6.0"

### Transports

Blazor works best when using [WebSockets](xref:fundamentals/websockets) as the SignalR transport due to lower latency, better reliability, and improved [security](xref:signalr/security). [Long Polling](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/TransportProtocols.md#long-polling-server-to-client-only) is used by SignalR when WebSockets isn't available or when the app is explicitly configured to use Long Polling. When deploying to Azure App Service, configure the app to use WebSockets in the Azure portal settings for the service. For details on configuring the app for Azure App Service, see the [SignalR publishing guidelines](xref:signalr/publish-to-azure-web-app).

A console warning appears if Long Polling is utilized:

> :::no-loc text="Failed to connect via WebSockets, using the Long Polling fallback transport. This may be due to a VPN or proxy blocking the connection.":::

### Global deployment and connection failures

Recommendations for global deployments to geographical data centers:

* Deploy the app to the regions where most of the users reside.
* Take into consideration the increased latency for traffic across continents.
* For Azure hosting, use the [Azure SignalR Service](#azure-signalr-service).

If a deployed app frequently displays the reconnection UI due to ping timeouts caused by Internet latency, lengthen the server and client timeouts:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

* **Server**

  At least double the maximum roundtrip time expected between the client and the server. Test, monitor, and revise the timeouts as needed. For the SignalR hub, set the <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> (default: 30 seconds) and <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> (default: 15 seconds). The following example assumes that <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> uses the default value of 15 seconds.

  > [!IMPORTANT]
  > The <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> isn't directly related to the reconnection UI appearing. The Keep-Alive interval doesn't necessarily need to be changed. If the reconnection UI appearance issue is due to timeouts, the <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> and <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> can be increased and the Keep-Alive interval can remain the same. The important consideration is that if you change the Keep-Alive interval, make sure that the client timeout value is at least double the value of the Keep-Alive interval and that the Keep-Alive interval on the client matches the server setting.
  >
  > In the following example, the <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> is increased to 60 seconds, and the <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> is increased to 30 seconds.

  In the server project's `Program.cs` file:

  ```csharp
  builder.Services.AddRazorComponents().AddInteractiveServerComponents()
      .AddHubOptions(options =>
  {
      options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
      options.HandshakeTimeout = TimeSpan.FromSeconds(30);
  });
  ```

  For more information, see <xref:blazor/fundamentals/signalr#server-side-circuit-handler-options>.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

* **Server**

  At least double the maximum roundtrip time expected between the client and the server. Test, monitor, and revise the timeouts as needed. For the SignalR hub, set the <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> (default: 30 seconds) and <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> (default: 15 seconds). The following example assumes that <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> uses the default value of 15 seconds.

  > [!IMPORTANT]
  > The <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> isn't directly related to the reconnection UI appearing. The Keep-Alive interval doesn't necessarily need to be changed. If the reconnection UI appearance issue is due to timeouts, the <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> and <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> can be increased and the Keep-Alive interval can remain the same. The important consideration is that if you change the Keep-Alive interval, make sure that the client timeout value is at least double the value of the Keep-Alive interval and that the Keep-Alive interval on the client matches the server setting.
  >
  > In the following example, the <xref:Microsoft.AspNetCore.SignalR.HubOptions.ClientTimeoutInterval> is increased to 60 seconds, and the <xref:Microsoft.AspNetCore.SignalR.HubOptions.HandshakeTimeout> is increased to 30 seconds.

  In `Program.cs`:

  ```csharp
  builder.Services.AddServerSideBlazor()
      .AddHubOptions(options =>
      {
          options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
          options.HandshakeTimeout = TimeSpan.FromSeconds(30);
      });
  ```

  For more information, see <xref:blazor/fundamentals/signalr#server-side-circuit-handler-options>.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

* **Client**

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

  Typically, double the value used for the server's <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> to set the timeout for the client's server timeout (`withServerTimeout` or <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>, default: 30 seconds).

  > [!IMPORTANT]
  > The Keep-Alive interval (`withKeepAliveInterval` or <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>) isn't directly related to the reconnection UI appearing. The Keep-Alive interval doesn't necessarily need to be changed. If the reconnection UI appearance issue is due to timeouts, the server timeout can be increased and the Keep-Alive interval can remain the same. The important consideration is that if you change the Keep-Alive interval, make sure that the timeout value is at least double the value of the Keep-Alive interval and that the Keep-Alive interval on the server matches the client setting.
  >
  > In the following example, a custom value of 60 seconds is used for the server timeout.

  In the [startup configuration](xref:blazor/fundamentals/startup) of a server-side Blazor app after the Blazor script (`blazor.*.js`) `<script>` tag.

  Blazor Web App:

  ```html
  <script>
    Blazor.start({
      circuit: {
        configureSignalR: function (builder) {
          builder.withServerTimeout(60000);
        }
      }
    });
  </script>
  ```

  Blazor Server:

  ```html
  <script>
    Blazor.start({
      configureSignalR: function (builder) {
        builder.withServerTimeout(60000);
      }
    });
  </script>
  ```

  When creating a hub connection in a component, set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds) on the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds) on the built <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection>.
  
  The following example is based on the `Index` component in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor). The server timeout is increased to 60 seconds, and the handshake timeout is increased to 30 seconds:

  ```csharp
  protected override async Task OnInitializedAsync()
  {
      hubConnection = new HubConnectionBuilder()
          .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
          .WithServerTimeout(TimeSpan.FromSeconds(60))
          .Build();

      hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(30);

      hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

      await hubConnection.StartAsync();
  }
  ```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

  Typically, double the value used for the server's <xref:Microsoft.AspNetCore.SignalR.HubOptions.KeepAliveInterval> to set the timeout for the client's server timeout (`serverTimeoutInMilliseconds` or <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>, default: 30 seconds).

  > [!IMPORTANT]
  > The Keep-Alive interval (`keepAliveIntervalInMilliseconds` or <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>) isn't directly related to the reconnection UI appearing. The Keep-Alive interval doesn't necessarily need to be changed. If the reconnection UI appearance issue is due to timeouts, the server timeout can be increased and the Keep-Alive interval can remain the same. The important consideration is that if you change the Keep-Alive interval, make sure that the timeout value is at least double the value of the Keep-Alive interval and that the Keep-Alive interval on the server matches the client setting.
  >
  > In the following example, a custom value of 60 seconds is used for the server timeout.

  In `Pages/_Host.cshtml`:

  ```html
  <script src="_framework/blazor.server.js" autostart="false"></script>
  <script>
    Blazor.start({
      configureSignalR: function (builder) {
        let c = builder.build();
        c.serverTimeoutInMilliseconds = 60000;
        builder.build = () => {
          return c;
        };
      }
    });
  </script>
  ```

  When creating a hub connection in a component, set the <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds) and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.HandshakeTimeout> (default: 15 seconds) on the built <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection>.

  The following example is based on the `Index` component in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor). The server timeout is increased to 60 seconds, and the handshake timeout is increased to 30 seconds:

  ```csharp
  protected override async Task OnInitializedAsync()
  {
      hubConnection = new HubConnectionBuilder()
          .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
          .Build();

      hubConnection.ServerTimeout = TimeSpan.FromSeconds(60);
      hubConnection.HandshakeTimeout = TimeSpan.FromSeconds(30);

      hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

      await hubConnection.StartAsync();
  }
  ```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

  When changing the values of the server timeout (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout>) or the Keep-Alive interval (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval>:

  * The server timeout should be at least double the value assigned to the Keep-Alive interval.
  * The Keep-Alive interval should be less than or equal to half the value assigned to the server timeout.

For more information, see <xref:blazor/fundamentals/signalr#configure-signalr-timeouts-and-keep-alive-on-the-client>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Server-side apps use ASP.NET Core SignalR to communicate with the browser. [SignalR's hosting and scaling conditions](xref:signalr/publish-to-azure-web-app) apply to server-side apps.

Blazor works best when using WebSockets as the SignalR transport due to lower latency, reliability, and [security](xref:signalr/security). Long Polling is used by SignalR when WebSockets isn't available or when the app is explicitly configured to use Long Polling. When deploying to Azure App Service, configure the app to use WebSockets in the Azure portal settings for the service. For details on configuring the app for Azure App Service, see the [SignalR publishing guidelines](xref:signalr/publish-to-azure-web-app).

:::moniker-end

## Azure SignalR Service

We recommend using the [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) for server-side Blazor apps. The service works in conjunction with the app's Blazor Hub for scaling up a server-side Blazor app to a large number of concurrent SignalR connections. In addition, the SignalR Service's global reach and high-performance data centers significantly aid in reducing latency due to geography.

> [!IMPORTANT]
> When [WebSockets](https://wikipedia.org/wiki/WebSocket) are disabled, Azure App Service simulates a real-time connection using HTTP Long Polling. HTTP Long Polling is noticeably slower than running with WebSockets enabled, which doesn't use polling to simulate a client-server connection. In the event that Long Polling must be used, you may need to configure the maximum poll interval (`MaxPollIntervalInSeconds`), which defines the maximum poll interval allowed for Long Polling connections in [Azure SignalR Service](#azure-signalr-service) if the service ever falls back from WebSockets to Long Polling. If the next poll request does not come in within `MaxPollIntervalInSeconds`, Azure SignalR Service cleans up the client connection. Note that Azure SignalR Service also cleans up connections when cached waiting to write buffer size is greater than 1 MB to ensure service performance. Default value for `MaxPollIntervalInSeconds` is 5 seconds. The setting is limited to 1-300 seconds.
>
> **We recommend using WebSockets for server-side Blazor apps deployed to Azure App Service.** The [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) uses WebSockets by default. If the app doesn't use the Azure SignalR Service, see <xref:signalr/publish-to-azure-web-app#configure-the-app-in-azure-app-service>.
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
    "Azure:SignalR:ServerStickyMode": "Required"
    ```

  * The app service's **Configuration** > **Application settings** in the Azure portal (**Name**: `Azure__SignalR__ServerStickyMode`, **Value**: `Required`). This approach is adopted for the app automatically if you [provision the Azure SignalR Service](#provision-the-azure-signalr-service).

> [!NOTE]
> The following error is thrown by an app that hasn't enabled sticky sessions for Azure SignalR Service:
>
> > blazor.server.js:1 Uncaught (in promise) Error: Invocation canceled due to the underlying connection being closed.

### Provision the Azure SignalR Service

To provision the Azure SignalR Service for an app in Visual Studio:

1. Create an Azure Apps publish profile in Visual Studio for the app.
1. Add the **Azure SignalR Service** dependency to the profile. If the Azure subscription doesn't have a pre-existing Azure SignalR Service instance to assign to the app, select **Create a new Azure SignalR Service instance** to provision a new service instance.
1. Publish the app to Azure.

Provisioning the Azure SignalR Service in Visual Studio automatically [enables *sticky sessions*](#configuration) and adds the SignalR connection string to the app service's configuration.

:::moniker range=">= aspnetcore-6.0"

### Scalability on Azure Container Apps

Scaling server-side Blazor apps on Azure Container Apps requires specific considerations in addition to using the [Azure SignalR Service](#azure-signalr-service). Due to the way request routing is handled, the ASP.NET Core data protection service must be configured to persist keys in a centralized location that all container instances can access. The keys can be stored in Azure Blob Storage and protected with Azure Key Vault. The data protection service uses the keys to deserialize Razor components.

> [!NOTE]
> For a deeper exploration of this scenario and scaling container apps, see <xref:host-and-deploy/scaling-aspnet-apps/scaling-aspnet-apps>. The tutorial explains how to create and integrate the services required to host apps on Azure Container Apps. Basic steps are also provided in this section.

1. To configure the data protection service to use Azure Blob Storage and Azure Key Vault, reference the following NuGet packages:

   * [`Azure.Identity`](https://www.nuget.org/packages/Azure.Identity): Provides classes to work with the Azure identity and access management services.
   * [`Microsoft.Extensions.Azure`](https://www.nuget.org/packages/Microsoft.Extensions.Azure): Provides helpful extension methods to perform core Azure configurations.
   * [`Azure.Extensions.AspNetCore.DataProtection.Blobs`](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs): Allows storing ASP.NET Core Data Protection keys in Azure Blob Storage so that keys can be shared across several instances of a web app.
   * [`Azure.Extensions.AspNetCore.DataProtection.Keys`](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Keys): Enables protecting keys at rest using the Azure Key Vault Key Encryption/Wrapping feature.

   [!INCLUDE[](~/includes/package-reference.md)]

1. Update `Program.cs` with the following highlighted code:

   :::code language="csharp" source="~/../AspNetCore.Docs.Samples/tutorials/scalable-razor-apps/end/Program.cs" id="snippet_ProgramConfigurations" highlight="1-4,6-7,13-19":::    

   The preceding changes allow the app to manage data protection using a centralized, scalable architecture. <xref:Azure.Identity.DefaultAzureCredential> discovers the container app managed identity after the code is deployed to Azure and uses it to connect to blob storage and the app's key vault.

1. To create the container app managed identity and grant it access to blob storage and a key vault, complete the following steps:

   1. In the Azure Portal, navigate to the overview page of the container app.
   1. Select **Service Connector** from the left navigation.
   1. Select **+ Create** from the top navigation.
   1. In the **Create connection** flyout menu, enter the following values:
      * **Container**: Select the container app you created to host your app.
      * **Service type**: Select **Blob Storage**.
      * **Subscription**: Select the subscription that owns the container app.
      * **Connection name**: Enter a name of `scalablerazorstorage`.
      * **Client type**: Select **.NET** and then select **Next**.
   1. Select **System assigned managed identity** and select **Next**.
   1. Use the default network settings and select **Next**.
   1. After Azure validates the settings, select **Create**.

   Repeat the preceding settings for the key vault. Select the appropriate key vault service and key in the **Basics** tab.

:::moniker-end

## Azure App Service without the Azure SignalR Service

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
  * [ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

## Linux with Apache

To host a Blazor app behind Apache on Linux, configure `ProxyPass` for HTTP and WebSockets traffic.

In the following example:

* Kestrel server is running on the host machine.
* The app listens for traffic on port 5000.

```
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
  * [ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

## Measure network latency

[JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) can be used to measure network latency, as the following example demonstrates.

`Shared/MeasureLatency.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/host-and-deploy/MeasureLatency.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/host-and-deploy/MeasureLatency.razor":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

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

:::moniker-end

For a reasonable UI experience, we recommend a sustained UI latency of 250 ms or less.

## Memory management

On the server, a new circuit is created for each user session. Each user session corresponds to rendering a single document in the browser. For example, multiple tabs create multiple sessions.

Blazor maintains a constant connection to the browser, called a *circuit*, that initiated the session. Connections can be lost at any time for any of several reasons, such as when the user loses network connectivity or abruptly closes the browser. When a connection is lost, Blazor has a recovery mechanism that places a limited number of circuits in a "disconnected" pool, giving clients a limited amount of time to reconnect and re-establish the session (default: 3 minutes).

After that time, Blazor releases the circuit and discards the session. From that point on, the circuit is eligible for garbage collection (GC) and is claimed when a collection for the circuit's GC generation is triggered. One important aspect to understand is that circuits have a long lifetime, which means that most of the objects rooted by the circuit eventually reach Gen 2. As a result, you might not see those objects released until a Gen 2 collection happens.

### Measure memory usage in general

Prerequisites:

* The app must be published in **Release** configuration. **Debug** configuration measurements aren't relevant, as the generated code isn't representative of the code used for a production deployment.
* The app must run without a debugger attached, as this might also affect the behavior of the app and spoil the results. In Visual Studio, start the app without debugging by selecting **Debug** > **Start Without Debugging** from the menu bar or <kbd>Ctrl</kbd>+<kbd>F5</kbd> using the keyboard.
* Consider the different types of memory to understand how much memory is actually used by .NET. Generally, developers inspect app memory usage in Task Manager on Windows OS, which typically offers an upper bound of the actual memory in use. For more information, consult the following articles:
  * [.NET Memory Performance Analysis](https://github.com/Maoni0/mem-doc/blob/master/doc/.NETMemoryPerformanceAnalysis.md): In particular, see the section on [Memory Fundamentals](https://github.com/Maoni0/mem-doc/blob/master/doc/.NETMemoryPerformanceAnalysis.md#Memory-Fundamentals).
  * [Work flow of diagnosing memory performance issues (three-part series)](https://devblogs.microsoft.com/dotnet/work-flow-of-diagnosing-memory-performance-issues-part-0/): Links to the three articles of the series are at the top of each article in the series.

### Memory usage applied to Blazor

We compute the memory used by blazor as follows:

(**Active Circuits** × **Per-circuit Memory**) + (**Disconnected Circuits** × **Per-circuit Memory**)

The amount of memory a circuit uses and the maximum potential active circuits that an app can maintain is largely dependent on how the app is written. The maximum number of possible active circuits is roughly described by:

**Maximum Available Memory** / **Per-circuit Memory** = **Maximum Potential Active Circuits**

For a memory leak to occur in Blazor, the following must be true:

* The memory must be allocated by the framework, not the app. If you allocate a 1 GB array in the app, the app must manage the disposal of the array.
* The memory must not be actively used, which means the circuit isn't active and has been evicted from the disconnected circuits cache. If you have the maximum active circuits running, running out of memory is a scale issue, not a memory leak.
* A garbage collection (GC) for the circuit's GC generation has run, but the garbage collector hasn't been able to claim the circuit because another object in the framework is holding a strong reference to the circuit.

In other cases, there's no memory leak. If the circuit is active (connected or disconnected), the circuit is still in use.

If a collection for the circuit's GC generation doesn't run, the memory isn't released because the garbage collector doesn't need to free the memory at that time.

If a collection for a GC generation runs and frees the circuit, you must validate the memory against the GC stats, not the process, as .NET might decide to keep the virtual memory active.

If the memory isn't freed, you must find a circuit that isn't either active or disconnected and that's rooted by another object in the framework. In any other case, the inability to free memory is an app issue in developer code.

### Reduce memory usage

Adopt any of the following strategies to reduce an app's memory usage:

* Limit the total amount of memory used by the .NET process. For more information, see [Runtime configuration options for garbage collection](/dotnet/core/runtime-config/garbage-collector).
* Reduce the number of disconnected circuits.
* Reduce the time a circuit is allowed to be in the disconnected state.
* Trigger a garbage collection manually to perform a collection during downtime periods.
* Configure the garbage collection in Workstation mode, which aggressively triggers garbage collection, instead of Server mode.

###  Additional actions

* Capture a memory dump of the process when memory demands are high and identify the objects are taking the most memory and where are those objects are rooted (what holds a reference to them).
* .NET in Server mode doesn't release the memory to the OS immediately unless it must do so. For more information on project file (`.csproj`) settings to control this behavior, see [Runtime configuration options for garbage collection](/dotnet/core/runtime-config/garbage-collector).
* Server GC assumes that your app is the only one running on the system and can use all the system's resources. If the system has 50 GB, the garbage collector seeks to use the full 50 GB of available memory before it triggers a Gen 2 collection.

For information on disconnected circuit retention configuration, see <xref:blazor/fundamentals/signalr#server-side-circuit-handler-options>.
